import Image from "next/image"
import { memo } from "react"

interface GameImageProps {
  imageUrl: string
  title: string
}

export const GameImageComponent = ({ imageUrl, title }: GameImageProps) => {
  return (
    <div className="game-image">
      <Image
        src={imageUrl}
        alt={title}
        fill
        sizes="(260px)"
        priority={true}
        draggable={false}
        style={{ objectFit: "cover" }}
      />
    </div>
  )
}

export const GameImage = memo(GameImageComponent)
