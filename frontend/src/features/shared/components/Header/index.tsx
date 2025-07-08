import Link from "next/link"
import "./styles.scss"

export const Header = () => {
  return (
    <header>
      <ul>
        <Link href="/store">Store</Link>
        <Link href="/library">Library</Link>
        <Link href="/users">Users</Link>
        <Link href="/profile">Profile</Link>
      </ul>
    </header>
  )
}
