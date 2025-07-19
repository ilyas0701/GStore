import { NextResponse } from "next/server"
import { logger } from "@/features/shared/logger"

export async function POST(request: Request) {
  const { id, price } = await request.json()

  logger.info(`Purchase request for game with id: ${id}, price: ${price}`)

  return NextResponse.json({ success: true })
}
