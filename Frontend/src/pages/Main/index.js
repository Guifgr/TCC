import React, { useState } from 'react'
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Grid from '@mui/material/Grid';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import TextField from '@mui/material/TextField';
import AccountCircle from '@mui/icons-material/AccountCircle';
import LocationOn from '@mui/icons-material/LocationOn';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
import InputAdornment from '@mui/material/InputAdornment';
import Stack from '@mui/material/Stack';
import { createTheme, ThemeProvider } from "@mui/material/styles";
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import Constants from "../../Constants";
import api from '../../services/api';

const theme = createTheme();

function Copyright(props) {
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

export default function PersonalForm() {

  const [loading, setLoading] = useState(false);

  const onReturn = (event) => {
    event.preventDefault();
    localStorage.removeItem("@tccToken");
    window.location.href = '/'
  };
  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    var name = data.get("name");
    var street = data.get("street");
    var number = data.get("number");
    var complement = data.get("complement");
    var neighborhood = data.get("neighborhood");
    var city = data.get("city");
    var state = data.get("state");
    var country = data.get("country");
    var zipCode = data.get("zipCode");
    var reference = data.get("reference");

    if (name == '' || street == '' || number == '' || complement == '' || neighborhood == '' ||
      city == '' || state == '' || country == '' || zipCode == '' ||
      name == null || street == null || number == null || complement == null || neighborhood == null ||
      city == null || state == null || country == null || zipCode == null) {
      return toast.info('Preencha todos os campos do formulário!', {
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
      name: name,

      address: {
        street: street,
        number: number,
        complement: complement,
        neighborhood: neighborhood,
        city: city,
        state: state,
        country: country,
        zipCode: zipCode,
        reference: reference
      }
    }
    api
      .put(`${Constants.url.route}/Users/ContinueAccountRegister`, body)
      .then((res) => {
        notify();
        setLoading(false);
        setTimeout(function () {
          window.location.href = '/';
        }, 5000);
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

  const notify = () => toast.success('Conta cadastrada com sucesso!', {
    position: "bottom-left",
    autoClose: 5000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  });

  return (
    <React.Fragment>
      <Container>
        <Typography variant="body1"
          color="text.warning"
          align="center" gutterBottom>
          Pré-Cadastro Paciente
        </Typography>
        <Box
          component="form"
          onSubmit={handleSubmit}
          noValidate
          sx={{ mt: 1 }}
        >
          <Grid container spacing={3}>
            <Grid item xs={10} sm={6}>
              <TextField
                disabled
                id="firstName"
                name="firstName"
                label="Email"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={6}>
              <TextField
                disabled
                id="firstName"
                name="firstName"
                label="CPF"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={12}>
              <TextField
                required
                id="name"
                name="name"
                label="Nome Completo"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={4}>
              <TextField
                id="firstName"
                name="firstName"
                label="Data de Nascimento:"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={4}>
              <TextField
                id="firstName"
                name="firstName"
                label="Naturalidade:"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <AccountCircle />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={4}>
              <FormControl>
                <FormLabel id="radio-buttons-genero" focused>Gênero:</FormLabel>
                <RadioGroup
                  row
                  aria-labelledby="demo-row-radio-buttons-group-label"
                  name="row-radio-buttons-group"
                >
                  <FormControlLabel value="female" control={<Radio />} label="Feminino" />
                  <FormControlLabel value="male" control={<Radio />} label="Masculino" />
                  <FormControlLabel value="other" control={<Radio />} label="Outros" />
                </RadioGroup>
              </FormControl>
            </Grid>

            <Grid item xs={10} sm={8}>
              <TextField
                required
                id="street"
                name="street"
                label="Rua"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={4}>
              <TextField
                required
                id="number"
                name="number"
                label="Número"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="complement"
                name="complement"
                label="Complemento"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="neighborhood"
                name="neighborhood"
                label="Bairro"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="city"
                name="city"
                label="Cidade"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="state"
                name="state"
                label="Estado"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>


            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="country"
                name="country"
                label="País"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={6}>
              <TextField
                required
                id="zipCode"
                name="zipCode"
                label="CEP"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={12}>
              <TextField
                id="reference"
                name="reference"
                label="Referência"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LocationOn />
                    </InputAdornment>
                  ),
                }}
                fullWidth
                autoComplete="given-name"
                variant="outlined"
              />
            </Grid>

            <Grid item xs={10} sm={4}>
              <Button
                onClick={onReturn}
                type="submit"
                color="error"
                variant="contained"
                fullWidth
                sx={{ mt: 3, mb: 2 }}>Voltar para login
              </Button>
            </Grid>
            <Grid item xs={10} sm={4}></Grid>
            <Grid item xs={10} sm={4}>
              <Button

                type="submit"
                color="primary"
                variant="contained"
                fullWidth
                sx={{ mt: 3, mb: 2 }}>Salvar Dados
              </Button>
            </Grid>

          </Grid>
        </Box>
      </Container>
      <ToastContainer />
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

    </React.Fragment>

  );

}
