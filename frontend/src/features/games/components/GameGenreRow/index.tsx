import type { Genre } from "@/features/shared/types/game"
import { GameGenre } from "@/features/games/components/GameGenre"
import "./styles.scss"

export const GameGenreRow = ({ genres }: { genres: Genre[] }) => {
  return (
    <div className="game-genre-row">
      {genres.map((genre) => (
        <GameGenre key={genre.id} {...genre} />
      ))}
    </div>
  )
}
