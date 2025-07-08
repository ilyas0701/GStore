import type { UserDTO } from "@/features/auth/types/user"
import users from "@/data/MOCK_DATA.json"

// TODO: replace with env
const API_URL = null

export const fetchUsers = async (): Promise<UserDTO[]> => {
  if (!API_URL) {
    await new Promise((resolve) => setTimeout(resolve, 100))
    return users
  } else {
    const response = await fetch(`${API_URL}/users`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      cache: "no-store",
    })

    if (!response.ok) {
      throw new Error("Failed to fetch users")
    }

    return response.json()
  }
}
