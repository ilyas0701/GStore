"use client"
import { usePurchaseGame } from "@/features/games/hooks/useGames"
import { formatPrice } from "@/features/games/utils/price"
import "./styles.scss"

interface GamePurchaseProps {
  id: string
  price: number
}

export const GamePurchase = ({ id, price }: GamePurchaseProps) => {
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
        {isPending ? "Processing..." : price ? "Buy Now" : "Grab now"}
      </button>
    </div>
  )
}
