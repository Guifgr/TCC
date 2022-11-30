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
import Constants from "../../Constants";
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Copyright from "../../Components/copyright";
import Grid from '@mui/material/Grid';
import { useNavigate } from 'react-router-dom';

const theme = createTheme();

export default function SignIn() {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const onReturn = (event) => {
        event.preventDefault();
        localStorage.removeItem("@tccToken");
        window.location.href = '/'
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        if (data.get("email") == '' || data.get("email") == null) {
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

        try {

            setLoading(true);

            const email = data.get("email")

            const resp = await axios.post("https://9d7d-2804-431-cfc3-5e42-3de6-1e68-1f4a-2d38.sa.ngrok.io/Users/RequestAccountPasswordChange", {
                email
            });

            toast.info(resp.data, {
                position: "bottom-center",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });

            setLoading(false)

            navigate("/definir-senha");
        } catch (err) {
            setLoading(false)
            toast.error("Não foi possível enviar o link", {
                position: "bottom-center",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }
    };

    const notify = () => toast.success('Email enviado para sua caixa de entrada com sucesso!', {
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