import type { Metadata } from "next"
import type { GameCompact } from "@/features/shared/types/game"
import { GameDetails } from "@/features/games/components/GameDetails"
import { GameGallery } from "@/features/games/components/GameGallery"
import { fetchGameById } from "@/features/games/service/games.service"
import "./styles.scss"

interface Props {
  params: Promise<{ id: string }>
}

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const { id } = await params
  const game: GameCompact | undefined = await fetchGameById(id)
  if (!game) {
    return {
      title: "Game Not Found",
      description: "The requested game does not exist.",
    }
  }
  return {
    title: game.title,
    description: game.description,
  }
}

export default async function GameDetailPage(props: Props) {
  const { id } = await props.params

  return (
    <main className="game-page">
      <GameGallery id={id} />
      <GameDetails id={id} />
    </main>
  )
}
