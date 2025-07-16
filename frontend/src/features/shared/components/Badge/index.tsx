interface BadgeProps {
  text: string
  className?: string
}

export const Badge = ({ text, className }: BadgeProps) => {
  return <span className={`badge ${className || ""}`}>{text}</span>
}
