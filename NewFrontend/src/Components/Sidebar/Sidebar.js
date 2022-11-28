import React, { useEffect } from "react";
import { NavLink, useLocation, useNavigate } from "react-router-dom";
import { Nav } from "reactstrap";
// javascript plugin used to create scrollbars on windows
import PerfectScrollbar from "perfect-scrollbar";

import logo from "../../assets/img/Logo.svg";

var ps;

function Sidebar({routes, bgColor, activeColor}) {
  const sidebar = React.useRef();
  const location = useLocation();
  const navigate = useNavigate();
  const activeRoute = (routeName) => {
    return location.pathname == routeName ? "active" : "";
  };
  useEffect(() => {
    if (navigator.platform.indexOf("Win") > -1) {
      ps = new PerfectScrollbar(sidebar.current, {
        suppressScrollX: true,
        suppressScrollY: false
      });
    }
    return function cleanup() {
      if (navigator.platform.indexOf("Win") > -1) {
        ps.destroy();
      }
    };
  });
  return (
    <div
      className="sidebar"
      data-color={bgColor}
      data-active-color={activeColor}
    >
      <div className="logo">
        <a
          href="/admin/home"
          className="simple-text logo-mini"
        >
          <div className="logo-img">
            <img src={logo} alt="react-logo" />
          </div>
        </a>
        <a
          href="/admin/home"
          className="simple-text logo-normal"
        >
          AgenDonto
        </a>
      </div>
      <div className="sidebar-wrapper" ref={sidebar}>
        <Nav>
          {routes.map(({ path, name }, key) => (
              <li
                className={
                  activeRoute(path) + (name ? " active-pro" : "")
                }
                key={key}
              >
                <NavLink
                  to={path}
                  className="nav-link"
                >
                  <p>{name}</p>
                </NavLink>
              </li>
            ))}
        </Nav>
      </div>
    </div>
  );
}

export default Sidebar;
