import type { Genre } from "@/features/shared/types/game"

export const adaptGenres = (genre: string): Genre[] => {
  return genre.split("|").map((name) => ({
    id: crypto.randomUUID(),
    name: name.trim(),
  }))
}
