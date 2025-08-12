import type { Metadata } from "next"
import { fetchGames } from "@/features/games/service/games.service"
import { GameList } from "@/features/store/components/GameList"
import "./styles.scss"

export async function generateMetadata(): Promise<Metadata> {
  return {
    title: "Store",
    description: "Browse and discover new games",
  }
}

export default async function StorePage() {
  const games = await fetchGames()

  return (
    <div className="store-page">
      <GameList games={games} />
    </div>
  )
}
