import * as React from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { getWasPostRegistered } from '../../services/auth'

function Copyright(props) {

    if(!getWasPostRegistered){
        window.location.href = '/pos-cadastro'
    }

    return (
        <Typography
            variant="body2"
            color="text.secondary"
            align="center"
            {...props}
        >
            {"TCC UMC © "}
            {new Date().getFullYear()}
            {"."}
        </Typography>
    );
}

export default function SignOut() {
    const handleSubmit = (event) => {
        event.preventDefault();
        localStorage.removeItem("@tccToken");
        window.location.href = '/'
    };

    return (
        <Box
            sx={{
                display: 'flex',
                flexDirection: 'column',
                minHeight: '100vh',
            }}
        >
            <CssBaseline />
            <Container component="main" sx={{ mt: 8, mb: 2 }} maxWidth="sm">
                <Typography variant="h3" component="h1" gutterBottom>
                    MENU EM MANUTENÇÃO!!
                </Typography>
                <br />
                <Typography variant="h5" component="h2" gutterBottom>
                    Agora poderia testar o logout? kkkk :D
                </Typography>
                <Typography variant="body1"></Typography>

                <Button
                    onClick={handleSubmit}
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    Logout
                </Button>

            </Container>
            <Box
                component="footer"
                sx={{
                    py: 3,
                    px: 2,
                    mt: 'auto',
                    backgroundColor: (theme) =>
                        theme.palette.mode === 'light'
                            ? theme.palette.grey[200]
                            : theme.palette.grey[800],
                }}
            >
                <Container maxWidth="sm">
                    <Copyright />
                </Container>
            </Box>
        </Box>
    );
}