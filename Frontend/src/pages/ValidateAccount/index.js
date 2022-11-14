import React, { useState, useEffect } from 'react'
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
import CheckIcon from '@mui/icons-material/Check';
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Constants from "../../Constants";
import axios from "axios";
import Copyright from "../../Components/copyright";

const theme = createTheme();

export default function SignIn() {
    let [searchParams, setSearchParams] = useSearchParams();
    let [text, setText] = useState('Validando a sua conta!');
    const [loading, setLoading] = useState(false);

    // if (searchParams.get("token") == null || searchParams.get("token") == '') {
    //     window.location.href = '/';
    // }


    useEffect(() => {
        setLoading(true);
        axios
            .post(`${Constants.url.route}/Users/ValidateUserEmailAccount?token=${searchParams.get("token")}`)
            .then((res) => {
                setTimeout(function () {
                    setLoading(false);
                    notify();
                    setText('Conta validada!');
                    setTimeout(function () {
                        window.location.href = '/';
                    }, 3000);
                }, 2000);
            })
            .catch((err) => {
                var message = JSON.parse(err.request.response).Message;
                setTimeout(function () {
                    setLoading(false);
                    toast.error(message, {
                        position: "bottom-center",
                        autoClose: 5000,
                        hideProgressBar: false,
                        closeOnClick: true,
                        pauseOnHover: true,
                        draggable: true,
                        progress: undefined,
                    });
                }, 2000);
            });
    }, []);

    const notify = () => toast.success('Conta validada com sucesso!', {
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
                    <Avatar sx={{ m: 1, bgcolor: "success.main" }}>
                        <CheckIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        {text}
                    </Typography>
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
