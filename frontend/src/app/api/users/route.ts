import { NextResponse } from "next/server"
import { fetchUsers } from "@/features/users/service/users.service"

export async function GET() {
  try {
    const users = await fetchUsers()
    return NextResponse.json(users)
  } catch (error) {
    console.error("Failed to fetch users:", error)
    return NextResponse.json(
      { error: "Failed to fetch users" },
      { status: 500 }
    )
  }
}
