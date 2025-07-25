import type { Genre } from "@/features/shared/types/game"
import { randomUUID } from "node:crypto"
import { logger } from "@/features/shared/logger"

export const adaptGenres = (genre: string): Genre[] => {
  logger.debug("Adapting genres:", genre)

  return genre.split("|").map((name) => ({
    id: randomUUID(),
    name: name.trim(),
  }))
}
