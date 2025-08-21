import type { UserDTO } from "@/features/shared/types/user"
import users from "@/data/MOCK_DATA.json"

// TODO: replace with env
const API_URL = null

export const fetchUsers = async (): Promise<UserDTO[]> => {
  if (!API_URL) {
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
      const errorDetails = `Status: ${response.status} ${response.statusText}`
      throw new Error(`Failed to fetch users. ${errorDetails}`)
    }

    return response.json()
  }
}
