import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import {
  fetchGames,
  purchaseGame,
} from "@/features/games/service/games.service"

const STALE_TIME_5_MIN = 5 * 60 * 1000

export const useGames = () => {
  return useQuery({
    queryKey: ["games"],
    queryFn: fetchGames,
    staleTime: STALE_TIME_5_MIN,
  })
}

export const usePurchaseGame = () => {
  const queryClient = useQueryClient()

  return useMutation({
    mutationFn: ({ gameId }: { gameId: string }) => {
      return purchaseGame(gameId)
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["games"],
      })
    },
  })
}
