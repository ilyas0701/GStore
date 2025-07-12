import { fetchGames } from "@/features/games/service/games.service"
import { GameList } from "@/features/store/components/GameList"
import "./styles.scss"

export default async function StorePage() {
  const games = await fetchGames()

  return (
    <div className="store-page">
      <GameList games={games} />
    </div>
  )
}
