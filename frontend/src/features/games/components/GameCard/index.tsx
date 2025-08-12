import type { GameCompact } from "@/features/shared/types/game"
import Link from "next/link"
import { GameImage } from "@/features/games/components/GameCard/GameImage"
import { formatPrice } from "@/features/games/utils/price"
import { Badge } from "@/features/shared/components/Badge"
import "./styles/styles.scss"

export const GameCard = ({ game }: { game: GameCompact }) => {
  const price = formatPrice(game.price || 0)

  return (
    <Link href={`/store/${game.id}`}>
      <div className="store-card">
        <GameImage imageUrl={game.image_url} title={game.title} />
        <h2>{game.title}</h2>
        <p>{game.description}</p>
        <Badge text={price} />
      </div>
    </Link>
  )
}
