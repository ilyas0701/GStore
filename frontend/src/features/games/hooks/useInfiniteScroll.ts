import { useEffect } from "react"
import { useInView } from "react-intersection-observer"



export const useInfiniteScroll = ({
  onLoadMore,
  canLoad,
  rootMargin = "100px"
}: {
  onLoadMore: () => void
  canLoad: boolean
  rootMargin?: string
}) => {
  const { ref, inView } = useInView({ threshold: 0, rootMargin })

  useEffect(() => {
    if (inView && canLoad) {
      onLoadMore()
    }
  }, [inView, canLoad, onLoadMore])

  return { ref }
}
