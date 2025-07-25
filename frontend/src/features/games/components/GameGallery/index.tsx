import Image from "next/image"
import { GameRow } from "@/features/games/components/GameRow"
import { fetchGameMediaById } from "@/features/games/service/games.service"
import "./styles.scss"

interface GameGalleryProps {
  id: string
}
/*
 * Expected that we will have endpoint to fetch game media to show it like in Steam.
 */
export const GameGallery = async ({ id }: GameGalleryProps) => {
  // TODO: should be as array of images fetched from API
  const mainImageUrl = await fetchGameMediaById(id)

  if (!mainImageUrl) {
    throw new Error(`No media found for game with id: ${id}`)
  }

  return (
    <div className="game-gallery">
      <Image
        src={mainImageUrl}
        alt={`Game Gallery for ${id}`}
        width={600}
        height={300}
        priority
        draggable={false}
        className="game-gallery-image"
      />
      <GameRow id={id} size={5} />
    </div>
  )
}
