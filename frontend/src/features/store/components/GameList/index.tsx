import type { GameCompact } from "@/features/shared/types/game"
import { GameCard } from "@/features/games/components/GameCard"
import "./styles.scss"

export const GameList = ({ games }: { games: GameCompact[] }) => {
  return (
    <div className="game-list">
      {games.map((game) => (
        <GameCard game={game} key={game.id} />
      ))}
    </div>
  )
}
