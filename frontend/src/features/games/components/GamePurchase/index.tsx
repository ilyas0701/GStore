"use client"
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
    // FIXME: replace with ts-log
    console.warn(`Purchasing game with ID: ${id}`)
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
