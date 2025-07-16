import Link from "next/link"
import "./styles.scss"

export const Header = () => {
  return (
    <header>
      <ul>
        <li>
          <Link href="/store">Store</Link>
        </li>
        <li>
          <Link href="/library">Library</Link>
        </li>
        <li>
          <Link href="/users">Users</Link>
        </li>
        <li>
          <Link href="/profile">Profile</Link>
        </li>
      </ul>
    </header>
  )
}
