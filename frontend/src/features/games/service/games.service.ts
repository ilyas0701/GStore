import type { GameCompact } from "@/features/shared/types/game"
import { games } from "@/data/games.json"
import { adaptGame } from "@/features/games/service/mappers/adaptGame"
import { API_URL, DEFAULT_IMAGE_URL } from "@/features/shared/constants"

interface FetchGamesParams {
  page?: number
  limit?: number
}

interface PaginatedGamesResponse {
  games: GameCompact[]
  nextPage: number | null
  hasNextPage: boolean
  totalCount: number
}

export const fetchGamesWithPagination = async ({
  page = 1,
  limit = 20,
}: FetchGamesParams = {}): Promise<PaginatedGamesResponse> => {
  if (!API_URL) {
    await new Promise((resolve) => setTimeout(resolve, 500))

    const startIndex = (page - 1) * limit
    const endIndex = startIndex + limit

    const gamesMap = games.map(adaptGame)

    const gamesPaginated = gamesMap.slice(startIndex, endIndex)
    const hasNextPage = endIndex < gamesMap.length

    return {
      games: gamesPaginated,
      nextPage: hasNextPage ? page + 1 : null,
      hasNextPage,
      totalCount: gamesMap.length,
    }
  } else {
    // TODO: actual backend api can be different.
    const response = await fetch(
      `${API_URL}/games?page=${page}&limit=${limit}`,
      {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
        cache: "no-store",
      }
    )

    if (!response.ok) {
      throw new Error("Failed to fetch games")
    }

    return response.json()
  }
}

export const fetchGames = async (): Promise<GameCompact[]> => {
  const result = await fetchGamesWithPagination({ page: 1, limit: 9 })
  return result.games
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
    if (!game) {
      throw new Error("Game not found")
    }

    return game.image_url || DEFAULT_IMAGE_URL
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
  gameId: string
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
