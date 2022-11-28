import React, { useState, useRef, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { Collapse, Navbar, NavbarToggler, NavbarBrand, Nav, Dropdown, Container } from "reactstrap";
import { routes } from '../../Constants';

function Header() {
  const [isOpen, setIsOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const sidebarToggle = useRef();
  const location = useLocation();
  const dropdownToggle = (e) => {
    setDropdownOpen(!dropdownOpen);
  };
  const getBrand = () => {
    let brandName = "Default Brand";
    routes.forEach(({ name, path }) => {
      if (location.pathname == path) brandName = name;
    });
    return brandName;
  };
  useEffect(() => {
    if (
      window.innerWidth < 993 &&
      document.documentElement.className.indexOf("nav-open") !== -1
    ) {
      document.documentElement.classList.toggle("nav-open");
      sidebarToggle.current.classList.toggle("toggled");
    }
  }, [location, routes]);
  return (
    // add or remove classes depending if we are on full-screen-maps page or not
    <Navbar expand="lg" >
      <Container fluid>
        <div className="navbar-wrapper">
          <div className="navbar-toggle">
          </div>
          <NavbarBrand>{getBrand()}</NavbarBrand>
        </div>
        <NavbarToggler>
          <span className="navbar-toggler-bar navbar-kebab" />
          <span className="navbar-toggler-bar navbar-kebab" />
          <span className="navbar-toggler-bar navbar-kebab" />
        </NavbarToggler>
        <Collapse isOpen={isOpen} navbar className="justify-content-end">
          <Nav navbar>
            <Dropdown
              nav
              isOpen={dropdownOpen}
              toggle={(e) => dropdownToggle(e)}
            >
            </Dropdown>
          </Nav>
        </Collapse>
      </Container>
    </Navbar>
  );
}

export default Header;
