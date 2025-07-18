import type { UserDTO } from "@/features/shared/types/user"
import { NextResponse } from "next/server"
import { logger } from "@/features/shared/logger"
import { fetchUsers } from "@/features/users/service/users.service"

export async function GET(): Promise<
  NextResponse<UserDTO[] | { error: string }>
> {
  try {
    const users = await fetchUsers()
    return NextResponse.json(users)
  } catch (error) {
    logger.fatal("Failed to fetch users", error)
    return NextResponse.json(
      { error: "Failed to fetch users" },
      { status: 500 }
    )
  }
}
