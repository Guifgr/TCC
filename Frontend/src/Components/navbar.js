import { Link } from "react-router-dom";
import Logo from "../assets/logo.png";

function NavBar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light">
            <div className="container">
                <ul className="navbar-nav mx-auto">
                    <li className="nav-item active">
                        <Link to="/">
                            <img
                                style={{ height: "80px" }}
                                alt="scgas"
                                src={Logo}
                            />
                        </Link>
                    </li>
                </ul>
            </div>
        </nav>
    );
}

export default NavBar;
