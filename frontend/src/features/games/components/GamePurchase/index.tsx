"use client"
import { usePurchaseGame } from "@/features/games/hooks/useGames"
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

  const { mutate: purchaseGame, isPending } = usePurchaseGame()

  const handlePurchase = () => {
    purchaseGame({ gameId: id })
  }

  return (
    <div className="game-purchase">
      <p>{formatPrice(price)}</p>
      <button
        type="button"
        onClick={handlePurchase}
        className="purchase-button"
        disabled={isPending}
      >
        Buy Now
      </button>
    </div>
  )
}
