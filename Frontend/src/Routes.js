import React, { Fragment, Outlet } from "react";
import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import { isAuthenticated } from "./services/auth";
import Login from "./pages/loginPage";
import NavBar from "./Components/navbar";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

const PrivateRoute = () => {
    const auth = isAuthenticated(); // determine if authorized, from context or however you're doing it

    // If authorized, return an outlet that will render child elements
    // If not, return element that will navigate to login page
    return auth ? <Outlet /> : <Navigate to="/" />;
};

const AppRoutes = () => (
    <BrowserRouter>
        <Fragment>
            <NavBar />
            <Routes>
                <Route path="/" element={<Login />} />

                <Route exact path="/" element={<PrivateRoute />}>
                    <Route path="/services" element={<h1>TESTE</h1>} />
                </Route>

                <Route path="*" element={<h1>Pagina não encontrada</h1>} />
            </Routes>
        </Fragment>
    </BrowserRouter>
);

export default AppRoutes;
