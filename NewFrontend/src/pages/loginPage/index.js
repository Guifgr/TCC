import React, { useState, useContext } from 'react'
import UserContext from '../../context/userContext';
import { useNavigate } from 'react-router-dom';
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Constants from "../../Constants";
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import Copyright from "../../Components/copyright";

const theme = createTheme();

export default function SignIn() {
    const [loading, setLoading] = useState(false);
    const [userState, setUserState] = useContext(UserContext).state;
    const navigate = useNavigate();
    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        var email = data.get("email");
        var password = data.get("password");


        if (!email || !password) {
            return toast.info('Preecha todos os campos', {
                position: "bottom-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }

        setLoading(true);

        var body = {
            email: email,
            password: password
        };
        axios
            .post(`${Constants.url.route}/Auth/Login`, body)
            .then((res) => {
                if (!res.data.token) throw Error;
                setUserState(res.data);
                setLoading(false);
                navigate('/');
            })
            .catch((err) => {
                var error = JSON.parse(err.request.response).Message
                setLoading(false);
                toast.error(error, {
                    position: "bottom-center",
                    autoClose: 4000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    allowHtml: true
                });
                if (error == 'Usuário ainda não confirmou a conta por email!') {
                    toast.error('Não se preocupe já enviamos um novo email para você!', {
                        position: "bottom-center",
                        autoClose: 6000,
                        hideProgressBar: false,
                        closeOnClick: true,
                        pauseOnHover: true,
                        draggable: true,
                        progress: undefined,
                        allowHtml: true
                    });
                }
            });
    };

    return (
        <ThemeProvider theme={theme}>
            <Container component="main" maxWidth="xs">
                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: "flex",
                        flexDirection: "column",
                        alignItems: "center",
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Entrar
                    </Typography>
                    <Box
                        component="form"
                        onSubmit={handleSubmit}
                        noValidate
                        sx={{ mt: 1 }}
                    >
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Email:"
                            name="email"
                            autoComplete="email"
                            autoFocus
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Senha:"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                        />
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Logar
                        </Button>
                        <Grid container>
                            <Grid item xs>
                                <Link href="redefinir-senha" variant="body2">
                                {"Esqueceu a senha?"}
                                </Link>
                            </Grid>
                            <Grid item>
                                <Link href="criar-conta" variant="body2">
                                    {"Não tem conta? Se cadastre"}
                                </Link>
                            </Grid>
                        </Grid>
                    </Box>
                </Box>
                <Copyright sx={{ mt: 8, mb: 4 }} />
            </Container>
            <ToastContainer />
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={loading}
            >
                <CircularProgress color="inherit" />
            </Backdrop>
        </ThemeProvider>
    );
}
