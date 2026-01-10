import type { GameCompact } from "@/features/shared/types/game"
import { notFound } from "next/navigation"
import { GameGenreRow } from "@/features/games/components/GameGenreRow"
import { GamePurchase } from "@/features/games/components/GamePurchase"
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
      <GameGenreRow genres={game.genre} />
      <p>{game.description}</p>
      <GamePurchase id={game.id} price={game.price} />
    </div>
  )
}
