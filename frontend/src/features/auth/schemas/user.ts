import z from "zod"

export const roleEnum = z.enum(["user", "admin"])

export const id = z.string().uuid("Invalid UUID format")
export const username = z.string().min(1, "Username is required")
export const email = z.string().email("Invalid email address")
export const password = z
  .string()
  .min(6, "Password must be at least 6 characters")
export const imageUrl = z.string().url("Invalid URL format").optional()
export const role = roleEnum.default("user")
export const createdAt = z.string().datetime("Invalid date format")

export const userSchema = z.object({
  id,
  username,
  email,
  password,
  imageUrl,
  role,
  createdAt,
})

export const userCreationSchema = z.object({
  username,
  email,
  password,
})

export const userUpdateSchema = z
  .object({
    username: username.optional(),
    email: email.optional(),
    password: password.optional(),
    imageUrl: imageUrl.optional(),
  })
  .partial()
