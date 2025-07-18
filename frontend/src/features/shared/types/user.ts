export interface User {
  id: string
  username: string
  email: string
  password: string
  image_url?: string | null
  role: string
  created_at: string
}

export interface UserDTO {
  id: string
  username: string
  email: string
  image_url?: string | null
  role?: string
  created_at: string
}

export interface UserCreationDTO {
  username: string
  email: string
  password: string
}

export interface UserUpdateDTO {
  username?: string
  email?: string
  password?: string
  image_url?: string
}
