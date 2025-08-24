import {
  useInfiniteQuery,
  useMutation,
  useQuery,
  useQueryClient,
} from "@tanstack/react-query"
import {
  fetchGames,
  fetchGamesWithPagination,
  purchaseGame,
} from "@/features/games/service/games.service"

export const GAMES_QUERY_KEY = {
  root: ["games"],
  infinite: (limit: number) => ["games", "infinite", limit],
}

const STALE_TIME_5_MIN = 5 * 60 * 1000

export const useGames = () => {
  return useQuery({
    queryKey: GAMES_QUERY_KEY.root,
    queryFn: fetchGames,
    staleTime: STALE_TIME_5_MIN,
  })
}

export const useInfiniteGames = (limit = 9) => {
  return useInfiniteQuery({
    queryKey: GAMES_QUERY_KEY.infinite(limit),
    queryFn: ({ pageParam = 1 }) =>
      fetchGamesWithPagination({ page: pageParam, limit }),
    getNextPageParam: (lastPage) => lastPage.nextPage,
    initialPageParam: 1,
    staleTime: STALE_TIME_5_MIN,
  })
}

export const usePurchaseGame = () => {
  const queryClient = useQueryClient()

  return useMutation({
    mutationFn: ({ gameId }: { gameId: string }) =>
      purchaseGame(gameId)
    ,
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: GAMES_QUERY_KEY.root,
      })
    },
  })
}
