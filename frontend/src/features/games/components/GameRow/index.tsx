import Image from "next/image"
import { fetchGameById } from "@/features/games/service/games.service"
import "./styles.scss"

interface GameRowProps {
  id: string
  size?: number
}

export const GameRow = async ({ id, size = 1 }: GameRowProps) => {
  const game = await fetchGameById(id)

  if (!game) {
    return <div>Game not found</div>
  }

  return (
    <div className="game-row">
      {Array.from({ length: size }).map(() => (
        <Image
          key={Math.random()}
          className="game-row-image"
          src={game.image_url || "/placeholder.png"}
          alt={game.title}
          width={150}
          height={100}
          priority
        />
      ))}
    </div>
  )
}
