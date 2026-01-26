"use client"

import type { GameCompact } from "@/features/shared/types/game"
import { useEffect } from "react"
import { useInView } from "react-intersection-observer"
import { GameCard } from "@/features/games/components/GameCard"
import { useInfiniteGames } from "@/features/games/hooks/useGames"
import { LoadingGrid } from "@/features/store/components/GameList/LoadingGrid"
import "./styles.scss"
import { useInfiniteScroll } from "@/features/games/hooks/useInfiniteScroll"
import { ErrorState } from "./ErrorState"
import { EmptyState } from "./EmptyState"
import { GameListGrid } from "./GameListGrid"

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

  const { ref } = useInfiniteScroll({
    onLoadMore: fetchNextPage,
    canLoad: Boolean(hasNextPage && !isFetchingNextPage)
  })

  if (status === "pending") {
    return <LoadingGrid pageSize={pageSize} />
  }

  if (status === "error" || error) {
    return <ErrorState error={error} onRetry={() => window.location.reload()} />
  }

  const gamesList = data.pages.flatMap((page) => page.games) ?? []

  if (gamesList.length === 0) {
    return <EmptyState />
  }

  return (
    <div className="game-list-container">
      <GameListGrid games={gamesList} />
      <div ref={ref} className="infinite-scroll-trigger">
        {isFetchingNextPage && <LoadingGrid pageSize={pageSize} />}
      </div>
    </div>
  )
}
