import { GameCardSkeleton } from "@/features/games/components/GameCard/skeleton"
import "./styles.scss"

interface LoadingGridProps {
  pageSize: number
}

export const LoadingGrid = ({ pageSize }: LoadingGridProps) => {
  return (
    <div className="game-list loading-grid">
      {Array.from({ length: pageSize }, (_, index) => (
        <GameCardSkeleton key={index} />
      ))}
    </div>
  )
}
