import type { GameCompact, GameRaw } from "@/features/shared/types/game"
import { adaptGenres } from "@/features/games/service/adapters/mock"
import { DEFAULT_IMAGE_URL } from "@/features/shared/constants"

export const adaptGame = (
  game: Omit<GameRaw, "genre"> & {
    genre: string
  }
): GameCompact => {
  return {
    ...game,
    id: String(game.id),
    genre: adaptGenres(game.genre as string),
    price: Number(game.price) || 0,
    image_url: game.image_url || DEFAULT_IMAGE_URL,
  }
}
