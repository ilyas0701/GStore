"use client"
import { logger } from "@/features/shared/logger"
import "./styles.scss"

interface GamePurchaseProps {
  id: string
  price: number
}

export const GamePurchase = ({ id, price }: GamePurchaseProps) => {
  const formatPrice = (value: number) => {
    return new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    }).format(value)
  }

  const handlePurchase = () => {
    logger.info(`Purchasing game with ID: ${id} by price ${formatPrice(price)}`)
  }

  return (
    <div className="game-purchase">
      <p>{formatPrice(price)}</p>
      <button
        type="button"
        onClick={handlePurchase}
        className="purchase-button"
      >
        Buy Now
      </button>
    </div>
  )
}
