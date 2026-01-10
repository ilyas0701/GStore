interface ErrorStateProps {
  error: unknown
  onRetry?: () => void
}

export const ErrorState = ({ error, onRetry }: ErrorStateProps) => {
  return (
    <div role="alert">
      <p>Something went wrong.</p>
      <pre>{String(error)}</pre>
      {onRetry && <button onClick={onRetry} />}
    </div>
  )
}
