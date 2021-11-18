import { Link } from "react-router-dom";
import "./Navbar.css";

export function Navbar() {
    return (
        <div className="navbar">
            <Link to="/">Shop</Link>
            <Link to="/Orders">Orders</Link>
        </div>
    )
}