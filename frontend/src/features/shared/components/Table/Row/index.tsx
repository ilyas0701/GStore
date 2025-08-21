import type { ComponentType } from "react"
import React from "react"

interface WithId {
  id: string | number
}

interface RowProps<T extends WithId> {
  items: T[]
  component: ComponentType<T>
  className?: string
}
// TODO: remain such 'component: Component' for consistency (component naming)
// or change?
export const Row = <T extends WithId>({
  items,
  component: Component,
  className,
}: RowProps<T>) => {
  return (
    <div className={className}>
      {items.map((item) => (
        <Component key={item.id} {...item} />
      ))}
    </div>
  )
}
