import type { GameCompact } from "@/features/shared/types/game"
import { notFound } from "next/navigation"
import { fetchGameById } from "@/features/games/service/games.service"

interface GameDetailsProps {
  id: string
}

export const GameDetails = async ({ id }: GameDetailsProps) => {
  const game: GameCompact | undefined = await fetchGameById(id)

  if (!game) {
    return notFound()
  }

  return (
    <div className="game-details">
      <h1>{game.title}</h1>
      <p>{game.description}</p>
    </div>
  )
}
