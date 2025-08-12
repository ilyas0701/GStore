import Image from "next/image"

interface GameImageProps {
  imageUrl: string
  title: string
}

export const GameImage = ({ imageUrl, title }: GameImageProps) => {
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
