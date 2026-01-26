import type { Metadata } from "next"
import { GameList } from "@/features/store/components/GameList"
import "./styles.scss"

export async function generateMetadata(): Promise<Metadata> {
  return {
    title: "Store",
    description: "Browse and discover new games",
  }
}

export default async function StorePage() {
  return (
    <div className="store-page">
      <GameList />
    </div>
  )
}
