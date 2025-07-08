import type { GameCompact } from "@/features/shared/types/game"
import Image from "next/image"
import "./styles.scss"

export const GameCard = ({ game }: { game: GameCompact }) => {
  console.warn("StoreCard rendered", game)
  return (
    <div className="store-card">
      <div className="game-image">
        <Image
          src={game.image_url || "/placeholder.png"}
          alt={game.title}
          width={200}
          height={300}
          priority
        />
      </div>
      <h2>{game.title}</h2>
      <p>{game.description}</p>
      <p>Price: ${game.price}</p>
    </div>
  )
}
