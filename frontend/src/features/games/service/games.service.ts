import type { GameCompact, GameRaw } from "@/features/shared/types/game"
import { games } from "@/data/games.json"
import { adaptGenres } from "@/features/games/service/adapters/mock"

// TODO: replace with env
const API_URL = null

const adaptGame = (
  game: Omit<GameRaw, "genre"> & {
    genre: string
  }
): GameCompact => {
  return {
    ...game,
    id: String(game.id),
    genre: adaptGenres(game.genre as string),
    price: Number(game.price) || 0,
  }
}

export const fetchGames = async (): Promise<GameCompact[]> => {
  if (!API_URL) {
    await new Promise((resolve) => setTimeout(resolve, 100))
    const response = games.map(adaptGame)

    return response
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
  id: string
): Promise<GameCompact | undefined> => {
  const game = games.find((game) => String(game.id) === String(id))
  return game ? adaptGame(game) : undefined
}

export const fetchGameMediaById = async (id: string): Promise<string> => {
  if (!API_URL) {
    const game = games.find((game) => String(game.id) === String(id))

    if (!game?.image_url) {
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

export const purchaseGame = async (
  gameId: string | number | null
): Promise<{ success: boolean }> => {
  const response = await fetch(`/api/purchase-game/${gameId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  })

  if (!response.ok) {
    throw new Error("Failed to purchase game")
  }

  return response.json()
}
