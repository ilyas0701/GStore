import { describe, expect, it } from "vitest"
import { adaptGenres } from "./mock"

describe("mock genres adapter", () => {
  it("should split a single genre string into one Genre object", () => {
    const genres = adaptGenres("Action")
    expect(genres).toHaveLength(1)
    expect(genres[0].name).toBe("Action")
    expect(typeof genres[0].id).toBe("string")
  })

  it("should split multiple genres separated by | into Genre objects", () => {
    const genres = adaptGenres("Action|Adventure|Puzzle")
    expect(genres).toHaveLength(3)
    expect(genres.map((game) => game.name)).toEqual([
      "Action",
      "Adventure",
      "Puzzle",
    ])
    genres.forEach((game) => expect(typeof game.id).toBe("string"))
  })

  it("should return an empty array for an empty string", () => {
    const genres = adaptGenres("")
    expect(genres).toEqual([{ id: expect.any(String), name: "" }])
  })

  it("should trim whitespace around genre names", () => {
    const genres = adaptGenres(" Action | Adventure | Puzzle ")
    expect(genres.map((game) => game.name)).toEqual([
      "Action",
      "Adventure",
      "Puzzle",
    ])
  })

  it("should generate unique ids for each genre", () => {
    const genres = adaptGenres("Action|Adventure")
    expect(genres[0].id).not.toBe(genres[1].id)
  })
})
