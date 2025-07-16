import clsx from "clsx"
import "./styles.scss"

interface BadgeProps {
  text: string
  className?: string
}

export const Badge = ({ text, className }: BadgeProps) => {
  return <span className={clsx("badge", className)}>{text}</span>
}
