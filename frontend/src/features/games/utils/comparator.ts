import type { GameCompact } from "@/features/shared/types/game"

export const areEqual = (
  prev: { game: GameCompact },
  next: { game: GameCompact }
) => {
  const a = prev.game
  const b = next.game
  return (
    a.id === b.id &&
    a.title === b.title &&
    a.description === b.description &&
    Number(a.price) === Number(b.price) &&
    a.image_url === b.image_url
  )
}
