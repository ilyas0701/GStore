import type { GameCompact } from "@/features/shared/types/game"
import Image from "next/image"
import Link from "next/link"
import { Badge } from "@/features/shared/components/Badge"
import "./styles.scss"

export const GameCard = ({ game }: { game: GameCompact }) => {
  return (
    <Link href={`/store/${game.id}`}>
      <div className="store-card">
        <div className="game-image">
          <Image
            src={game.image_url || "/placeholder.png"}
            alt={game.title}
            width={260}
            height={160}
            priority
            draggable={false}
          />
        </div>
        <h2>{game.title}</h2>
        <p>{game.description}</p>
        <Badge text={`$${game.price}`} />
      </div>
    </Link>
  )
}
