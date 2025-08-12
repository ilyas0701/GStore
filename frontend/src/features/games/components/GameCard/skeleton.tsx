import "./styles/skeleton.scss"

export const GameCardSkeleton = () => {
  return (
    <div className="game-card-skeleton">
      <div className="skeleton-image" />
      <div className="skeleton-content">
        <div className="skeleton-title" />
        <div className="skeleton-description" />
        <div className="skeleton-price" />
      </div>
    </div>
  )
}
