import type { GameCompact } from "@/features/shared/types/game"
import Link from "next/link"
import { memo, useMemo } from "react"
import { GameImage } from "@/features/games/components/GameCard/GameImage"
import { areEqual } from "@/features/games/utils/comparator"
import { formatPrice } from "@/features/games/utils/price"
import { Badge } from "@/features/shared/components/Badge"
import "./styles/styles.scss"

interface GameCardProps {
  game: GameCompact
}

export const GameCardComponent = ({ game }: GameCardProps) => {
  const price = useMemo(() => formatPrice(game.price || 0), [game.price])

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

export const GameCard = memo<GameCardProps>(GameCardComponent, areEqual)
