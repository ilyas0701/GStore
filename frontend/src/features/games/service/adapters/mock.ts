import type { Genre } from "@/features/shared/types/game"
import { randomUUID } from "node:crypto"

export const adaptGenres = (genre: string): Genre[] => {
  return genre.split("|").map((name) => ({
    id: randomUUID(),
    name: name.trim(),
  }))
}
