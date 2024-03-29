import React, { useState } from 'react'
import Avatar from "@mui/material/Avatar";
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import Button from '@mui/material/Button';
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Grid from '@mui/material/Grid';
import Constants from '../../../Constants';
import Copyright from '../../../Components/copyright';

const theme = createTheme();

export default function SignIn() {
    const [loading, setLoading] = useState(false);

    const onReturn = (event) => {
        event.preventDefault();
        localStorage.removeItem("@tccToken");
        window.location.href = '/'
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        if (data.get("email") == '' || data.get("email") == null) {
            return toast.warning('Preecha todos os campos', {
                position: "bottom-right",
                autoClose: 2000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
                allowHtml: true
            });
        }

        await setLoading(true);
        var body = {
            email: data.get("email")
        }
        axios
            .post(`${Constants.url.route}/Users/RequestAccountPasswordChange`, body)
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
                    position: "bottom-right",
                    autoClose: 3000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: true,
                    progress: undefined,
                    allowHtml: true
                });
                setLoading(false);
            });
    };

    const notify = () => toast.success('Email enviado para sua caixa de entrada com sucesso!', {
        position: "bottom-right",
        autoClose: 2000,
        hideProgressBar: true,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        allowHtml: true
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
                        <Grid container spacing={2}>
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
                            <Grid item xs={10} sm={5}>
                                <Button
                                    onClick={onReturn}
                                    type="submit"
                                    color="error"
                                    variant="contained"
                                    fullWidth
                                    sx={{ mt: 3, mb: 2 }}>Voltar
                                </Button>
                            </Grid>
                            <Grid item xs={10} sm={2}></Grid>
                            <Grid item xs={10} sm={5}>
                                <Button

                                    type="submit"
                                    color="primary"
                                    variant="contained"
                                    fullWidth
                                    sx={{ mt: 3, mb: 2 }}>Enviar link
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