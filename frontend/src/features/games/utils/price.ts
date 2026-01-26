export const formatPrice = (price: number | null | undefined): string => {
  if (price === null || price === undefined || price === 0) {
    return "FREE"
  }
  return `$${price.toFixed(2)}`
}
