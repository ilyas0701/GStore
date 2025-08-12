export interface Genre {
  id: string
  name: string
}

export interface PlatformType {
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
  image_url: string
  released_at: Date
}

export interface GameRaw {
  id: number | string
  title: string
  description: string
  genre: string
  price: string | number | null
  image_url: string | null
}

export interface GameCompact
  extends Omit<Game, "platform" | "developer" | "released_at"> {}
