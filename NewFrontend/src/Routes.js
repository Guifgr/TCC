import React, { useEffect, useContext } from "react";
import {
    BrowserRouter,
    Route,
    Routes,
    useNavigate
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
import Dashboard from "./Admin";
import Professional from "../src/views/Professional/Professional.js";
import Contact from "../src/views/Contact/Contact"
import Consulta from "../src/views/Consultation/Consulta";
import Exams from "../src/views/Exams/Exams";
import Finance from "../src/views/Finance/Finance";
import UserContext, { UserProvider } from './context/userContext';
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";

const ProtectedRoute = ({ children }) => {
    const navigate = useNavigate();
    const userContext = useContext(UserContext);
    const [data] = userContext.state;
    useEffect(() => {
        // if (!data.token) navigate('/login');
    },[data, navigate]);
    window.logout = () => {
        userContext.logout();
        navigate('/login');
    }
    return children;
};

const AppRoutes = () => (
    <BrowserRouter>
        <UserProvider>
            <NavBar />
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/redefinir-senha" element={<RequestChangePassword />} />
                {/* Não existe */}
                <Route path="/definir-senha" element={<ChangePassword />} />
                <Route path="/criar-conta" element={<CreateAccount />} />
                <Route path="/validar-conta" element={<ValidateAccount />} />
                {/* Não existe */}
                <Route path="/finalizar-cadastro" element={<Main />} />

                <Route path="/financeiro" element={<Finance />} />

                <Route path="/profissional" element={<Professional />} />

                <Route path="/contato" element={<Contact />} />
                <Route path="/consulta" element={
                    <ProtectedRoute>
                        <Consulta />
                    </ProtectedRoute>
                } />
                <Route path="/exame" element={<Exams />} />


                <Route path="/" element={
                    <ProtectedRoute>
                        <Main />
                    </ProtectedRoute>}
                />

                <Route path="/perfil" element={
                    <ProtectedRoute>
                        <PostAccount />
                    </ProtectedRoute>}
                />

                <Route path="/dashboard" element={
                    <ProtectedRoute>
                        <Dashboard />
                    </ProtectedRoute>}
                />

                <Route path="*" element={<h1>Pagina não encontrada</h1>} />
            </Routes>
        </UserProvider>
    </BrowserRouter>
);

export default AppRoutes;
