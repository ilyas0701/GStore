import { GameCard } from "@/features/games/components/GameCard";
import { GameCompact } from "@/features/shared/types/game";


export const GameListGrid = ({ games }: { games: GameCompact[] }) => {
  return (
    <div className="game-list">
      {games.map((game: GameCompact) => (
        <GameCard key={game.id} game={game} />
      ))}
    </div>
  )
}
