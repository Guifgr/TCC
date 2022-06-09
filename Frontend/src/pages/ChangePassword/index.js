import React, { useState } from 'react'
import { useSearchParams } from "react-router-dom";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import { toast, ToastContainer } from 'react-toastify';
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
import Copyright from "../../Components/copyright";

const theme = createTheme();

export default function SignIn() {
    let [searchParams, setSearchParams] = useSearchParams();

    if (searchParams.get("token") == null || searchParams.get("token") == '') {
        window.location.href = '/';
    }

    const [loading, setLoading] = useState(false);
    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        var email = data.get("email");
        var password = data.get("password");
        var passwordConfirmation = data.get("password-confirmation");

        if (email == '' || password == '' || passwordConfirmation == '' || email == null || password == null || passwordConfirmation == null) {
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
            newPassword: password,
            token: searchParams.get("token")
        };
        axios
            .patch(`${Constants.url.route}/Users/ChangeAccountPassword`, body)
            .then((res) => {
                setLoading(false);
                notify();
                setTimeout(function () {
                    window.location.href = '/';
                }, 3000);

            })
            .catch((err) => {
                var message = JSON.parse(err.request.response).Message;
                toast.error(message, {
                    position: "bottom-center",
                    autoClose: 3000,
                    hideProgressBar: false,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                });
                setLoading(false);
            });
    };

    const notify = () => toast.success('Senha alterada com sucesso!', {
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
                        Troque sua senha
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
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password-confirmation"
                            label="Confirme a senha:"
                            type="password"
                            id="password-confirmation"
                            autoComplete="current-password-confirmation"
                        />
                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                        >
                            Trocar senha
                        </Button>
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
