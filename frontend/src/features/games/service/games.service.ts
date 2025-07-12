import type { GameCompact } from "@/features/shared/types/game"
import { games } from "@/data/games.json"

// TODO: replace with env
const API_URL = null

export const fetchGames = async (): Promise<GameCompact[]> => {
  if (!API_URL) {
    await new Promise((resolve) => setTimeout(resolve, 100))
    return games
  } else {
    const response = await fetch(`${API_URL}/games`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      cache: "no-store",
    })

    if (!response.ok) {
      throw new Error("Failed to fetch games")
    }

    return response.json()
  }
}
