interface Genre {
  id: string
  name: string
}

interface PlatformType {
  id: string
  type: string
}

export interface Game {
  id: string
  title: string
  description: string
  developer: string
  price: number
  genre: Genre[]
  platform: PlatformType[]
  image_url?: string | null
  released_at: Date
}

export interface GameCompact
  extends Omit<Game, "genre" | "platform" | "developer" | "released_at"> {}
