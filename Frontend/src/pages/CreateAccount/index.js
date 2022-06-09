import React, { useState } from 'react'
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Constants from "../../Constants";
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Copyright from "../../Components/copyright";
import ValidateCpf from "../../services/validateCpf";
import Grid from '@mui/material/Grid';
import api from '../../services/api';

const theme = createTheme();

export default function SignIn() {
    const [loading, setLoading] = useState(false);

    const onReturn = (event) => {
        event.preventDefault();
        localStorage.removeItem("@tccToken");
        window.location.href = '/'
      };

    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        var email = data.get("email");
        var password = data.get("password");
        var passwordConfirmation = data.get("password-confirmation");
        var cpf = data.get("cpf");

        if (email == '' ||
            password == '' ||
            passwordConfirmation == '' ||
            email == null ||
            password == null ||
            passwordConfirmation == null) {
            return toast.info('Preencha todos os campos!', {
                position: "bottom-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }

        if (password !== passwordConfirmation) {
            setLoading(false);
            return toast.error('Senhas não conferem!', {
                position: "bottom-center",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }

        if (password.length < 8) {
            setLoading(false);
            return toast.error('Senha deve conter 8 ou mais caracteres!', {
                position: "bottom-center",
                autoClose: 5000,
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
            password: password,
            cpf: cpf,
        }

        axios
            .post(`${Constants.url.route}/Users/PreRegisterAccount`, body)
            .then((res) => {
                notify();
                setLoading(false);
                setTimeout(function () {
                    window.location.href = '/';
                }, 3000);
            })
            .catch((err) => {
                setLoading(false);
                var message = JSON.parse(err.request.response).Message;
                toast.error(message, {
                    position: "bottom-center",
                    autoClose: 5000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                });
            });

    };

    const notify = () => toast.success('Conta pré cadastrada com sucesso!', {
        position: "bottom-left",
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
    });

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
                        Criar conta
                    </Typography>
                    <Box
                        component="form"
                        onSubmit={handleSubmit}
                        noValidate
                        sx={{ mt: 1 }}
                    >
                        <Grid container spacing={1}>
                            <Grid item xs={10} sm={12}>
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    id="cpf"
                                    label="CPF:"
                                    name="cpf"
                                    autoComplete="cpf"
                                    autoFocus
                                /></Grid>
                            <Grid item xs={10} sm={12}>
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    id="email"
                                    label="Email"
                                    name="email"
                                    autoComplete="email"
                                    autoFocus
                                />
                            </Grid>
                            <Grid item xs={10} sm={12}>
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="password"
                                    label="Senha"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                />
                            </Grid>
                            <Grid item xs={10} sm={12}>
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="password-confirmation"
                                    label="Confirme a Senha:"
                                    type="password"
                                    id="password-confirmation"
                                    autoComplete="current-password-confirmation"
                                />
                            </Grid>
                            <Grid item xs={10} sm={4}>
                                <Button
                                    onClick={onReturn}
                                    type="submit"
                                    color="error"
                                    variant="contained"
                                    fullWidth
                                    sx={{ mt: 3, mb: 2 }}>Voltar
                                </Button>
                            </Grid>
                            <Grid item xs={10} sm={4}></Grid>
                            <Grid item xs={10} sm={4}>
                                <Button

                                    type="submit"
                                    color="primary"
                                    variant="contained"
                                    fullWidth
                                    sx={{ mt: 3, mb: 2 }}>Salvar
                                </Button>
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