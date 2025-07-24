import { NextResponse } from "next/server"
import { fetchGameById } from "@/features/games/service/games.service"
import { logger } from "@/features/shared/logger"

// eslint-disable-next-line node/prefer-global/process
const API_URL = process.env.API_URL ?? null

export async function POST(
  request: Request,
  { params }: { params: { gameId: string } }
) {
  const { gameId } = await params
  const game = await fetchGameById(gameId)

  if (!game) {
    logger.fatal(`Game with id: ${params.gameId} not found`)
    return NextResponse.json(
      {
        success: false,
        error: "Game Not Found",
      },
      { status: 404 }
    )
  }

  if (API_URL) {
    const response = await fetch(`${API_URL}/purchase-game/${params.gameId}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
    })

    if (!response.ok) {
      logger.fatal(`Server purchase failed for game ${params.gameId}`)

      return NextResponse.json(
        {
          success: false,
          error: "Server Error",
        },
        { status: 500 }
      )
    }

    return NextResponse.json(await response.json())
  } else {
    logger.info(
      `Purchase request for game ${game.title}\nid: ${game.id}\nprice: ${game.price}`
    )
    return NextResponse.json({ success: true })
  }
}
