export interface Genre {
  id: string
  name: string
}

export interface PlatformType {
  id: string
  type: string
}

export interface Game {
  id: string | number
  title: string
  description: string
  developer: string
  price: number | null
  genre: Genre[]
  platform: PlatformType[]
  image_url?: string | null
  released_at: Date
}

export interface GameCompact
  extends Omit<Game, "platform" | "developer" | "released_at"> {}
