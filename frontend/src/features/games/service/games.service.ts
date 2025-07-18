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

export const fetchGameById = async (
  id: string | number
): Promise<GameCompact | undefined> => {
  return games.find((game) => game.id === id)
}

export const fetchGameMediaById = async (
  id: string | number
): Promise<string> => {
  if (!API_URL) {
    const game = games.find((game) => game.id === id)

    if (!game) {
      throw new Error(`No media found for game with id: ${id}`)
    }

    return game.image_url
  } else {
    const response = await fetch(`${API_URL}/game-media/${id}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      cache: "no-store",
    })

    if (!response.ok) {
      throw new Error(
        `Failed to fetch game media. Status: ${response.status} ${response.statusText}`
      )
    }

    return response.json()
  }
}
