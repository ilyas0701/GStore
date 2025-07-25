import type { GameCompact } from "@/features/shared/types/game"
import Image from "next/image"
import Link from "next/link"
import { formatPrice } from "@/features/games/utils/price"
import { Badge } from "@/features/shared/components/Badge"
import "./styles.scss"

export const GameCard = ({ game }: { game: GameCompact }) => {
  const price = formatPrice(game.price || 0)

  return (
    <Link href={`/store/${game.id}`}>
      <div className="store-card">
        <div className="game-image">
          <Image
            src={game.image_url || "/placeholder.png"}
            alt={game.title}
            fill
            sizes="(260px)"
            priority={true}
            draggable={false}
            style={{ objectFit: "cover" }}
          />
        </div>
        <h2>{game.title}</h2>
        <p>{game.description}</p>
        <Badge text={price} />
      </div>
    </Link>
  )
}
