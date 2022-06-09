import React, { Fragment } from "react";
import {
    BrowserRouter,
    Route,
    Routes,
    Navigate,
    Outlet,
} from "react-router-dom";
import { isAuthenticated } from "./services/auth";
import Login from "./pages/loginPage";
import RequestChangePassword from "./pages/RequestChangePassword";
import ChangePassword from "./pages/ChangePassword";
import CreateAccount from "./pages/CreateAccount";
import Main from "./pages/Main";
import ValidateAccount from "./pages/ValidateAccount";
import NavBar from "./Components/navbar";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

const PrivateRoute = () => {
    const auth = isAuthenticated(); // determine if authorized, from context or however you're doing it
    // If authorized, return an outlet that will render child elements
    // If not, return element that will navigate to login page
    return auth ? <Outlet /> : <Navigate to="/login" />;
};

const AppRoutes = () => (
    <BrowserRouter>
        <Fragment>
            <NavBar />
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/redefinir-senha" element={<RequestChangePassword />} />
                <Route path="/definir-senha" element={<ChangePassword />} />
                <Route path="/criar-conta" element={<CreateAccount />} />
                <Route path="/validar-conta" element={<ValidateAccount />} />
                <Route path="/finalizar-cadastro" element={<Main />} />

                <Route exact path="/" element={<PrivateRoute />}>
                    <Route path="/" element={<Main />} />
                </Route>

                <Route path="*" element={<h1>Pagina não encontrada</h1>} />
            </Routes>
        </Fragment>
    </BrowserRouter>
);

export default AppRoutes;
