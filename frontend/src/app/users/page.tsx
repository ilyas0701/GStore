import type { UserDTO } from "@/features/auth/types/user"
import Image from "next/image"
import { fetchUsers } from "@/features/users/service/users.service"

export default async function UsersPage() {
  const users = await fetchUsers()

  return (
    <main>
      <h1>Users List</h1>
      <div>
        {users.map((user: UserDTO) => (
          <div
            key={user.id}
            style={{
              border: "1px solid #ccc",
              margin: "10px",
              padding: "10px",
            }}
          >
            <h3>{user.username}</h3>
            <p>Email: {user.email}</p>
            <p>Role: {user.role}</p>
            {user.image_url && (
              <Image
                src={user.image_url}
                alt={user.username}
                width={50}
                height={50}
              />
            )}
            <p>Created: {new Date(user.created_at).toLocaleDateString()}</p>
          </div>
        ))}
      </div>
    </main>
  )
}
