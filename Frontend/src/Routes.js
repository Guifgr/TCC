import React, { Fragment } from "react";
import {
    BrowserRouter,
    Route,
    Routes,
    Navigate,
    Outlet,
} from "react-router-dom";
import { getToken, isAuthenticated } from "./services/auth";
import Login from "./pages/loginPage";
import RequestChangePassword from "./pages/RequestChangePassword";
import ChangePassword from "./pages/ChangePassword";
import CreateAccount from "./pages/CreateAccount";
import PostAccount from "./pages/PostAccount";
import Main from "./pages/Main";
import ValidateAccount from "./pages/ValidateAccount";
import NavBar from "./Components/navbar";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

const ProtectedRoute = ({ children }) => {
    if (!isAuthenticated()) {
        return <Navigate to="/login" replace />;
    }

    return children;
};

const AppRoutes = () => (
    <BrowserRouter>
        <NavBar />
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/redefinir-senha" element={<RequestChangePassword />} />
            <Route path="/definir-senha" element={<ChangePassword />} />
            <Route path="/criar-conta" element={<CreateAccount />} />
            <Route path="/validar-conta" element={<ValidateAccount />} />
            <Route path="/finalizar-cadastro" element={<Main />} />

            <Route path="/" element={
                <ProtectedRoute>
                    <Main />
                </ProtectedRoute>}
            />

            <Route path="/pos-cadastro" element={
                <ProtectedRoute>
                    <PostAccount />
                </ProtectedRoute>}
            />

            <Route path="*" element={<h1>Pagina não encontrada</h1>} />
        </Routes>
    </BrowserRouter>
);

export default AppRoutes;
