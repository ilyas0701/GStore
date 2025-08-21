import type { Genre } from "@/features/shared/types/game"
import { GameGenre } from "@/features/games/components/GameGenre"
import { Row } from "@/features/shared/components/Table/Row"
import "./styles.scss"

export const GameGenreRow = ({ genres }: { genres: Genre[] }) => (
  <Row items={genres} component={GameGenre} className="game-genre-row" />
)
