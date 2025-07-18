import type { Metadata } from "next"
import type { GameCompact } from "@/features/shared/types/game"
import { notFound } from "next/navigation"
import { GameGallery } from "@/features/games/components/GameGallery"
import { fetchGameById } from "@/features/games/service/games.service"
import "./styles.scss"

interface Props {
  params: Promise<{ id: string }>
}

export async function generateMetadata({
  params,
}: {
  params: { id: string }
}): Promise<Metadata> {
  const game: GameCompact | undefined = await fetchGameById(params.id)
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
  const params = await props.params
  const game: GameCompact | undefined = await fetchGameById(params.id)

  if (!game) notFound()

  return (
    <main className="game-page">
      <GameGallery id={params.id} />
      <div className="game-details">
        <h1>{game.title}</h1>
        <p>{game.description}</p>
      </div>
    </main>
  )
}
