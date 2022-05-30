import * as React from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";


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
                <Typography variant="h2" component="h1" gutterBottom>
                    Calma lá campeão era 30% segura ai kkjjj
                </Typography>
                <br />
                <Typography variant="h5" component="h2" gutterBottom>
                    Agora volta pro login meu parça kkkkk
                </Typography>
                <Typography variant="body1"></Typography>

                <Button
                    onClick={handleSubmit}
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    Clique aqui e caia fora meu chapa
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
            </Box>
        </Box>
    );
}
