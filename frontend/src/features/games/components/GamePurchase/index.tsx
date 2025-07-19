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

  const handlePurchase = async () => {
    await fetch("/api/purchase-game", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ id, price }),
    })
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
