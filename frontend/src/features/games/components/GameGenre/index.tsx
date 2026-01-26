"use client"
import type { Genre } from "@/features/shared/types/game"
import { useCallback } from "react"
import { logger } from "@/features/shared/logger"
import "./styles.scss"

export const GameGenre = ({ id, name }: Genre) => {
  const handleClick = useCallback(() => {
    logger.info(`Genre clicked: ${name}`, { genreId: id })
  }, [id, name])

  return (
    <div className="game-genre">
      <button type="button" onClick={handleClick} className="game-genre-button">
        <h3>{name}</h3>
      </button>
    </div>
  )
}
