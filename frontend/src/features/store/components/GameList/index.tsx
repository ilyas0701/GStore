"use client"

import type { GameCompact } from "@/features/shared/types/game"
import { useEffect } from "react"
import { useInView } from "react-intersection-observer"
import { GameCard } from "@/features/games/components/GameCard"
import { useInfiniteGames } from "@/features/games/hooks/useGames"
import { LoadingGrid } from "@/features/store/components/GameList/LoadingGrid"
import "./styles.scss"

interface GameListProps {
  pageSize?: number
}

export const GameList = ({ pageSize = 9 }: GameListProps) => {
  const {
    data,
    error,
    fetchNextPage,
    hasNextPage,
    isFetchingNextPage,
    status,
  } = useInfiniteGames(pageSize)

  const { inView, ref } = useInView({
    threshold: 0,
    rootMargin: "100px",
  })

  useEffect(() => {
    if (inView && hasNextPage && !isFetchingNextPage) {
      fetchNextPage()
    }
  }, [inView, hasNextPage, isFetchingNextPage, fetchNextPage])

  if (status === "pending") {
    return <LoadingGrid pageSize={pageSize} />
  }

  if (status === "error" || error) {
    // TODO
    throw new Error("This component is not implemented yet.")
  }

  const gamesList = data.pages.flatMap((page) => page.games) ?? []

  return (
    <div className="game-list-container">
      <div className="game-list">
        {gamesList.map((game: GameCompact) => (
          <GameCard game={game} key={game.id} />
        ))}
      </div>
      <div ref={ref} className="infinite-scroll-trigger">
        {isFetchingNextPage && <LoadingGrid pageSize={pageSize} />}
      </div>
    </div>
  )
}
