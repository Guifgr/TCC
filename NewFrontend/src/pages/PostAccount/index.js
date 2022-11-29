import React, { useState, useEffect, useContext } from 'react'
import Logo from '../../assets/img/logo-c-nome.svg'
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Grid from '@mui/material/Grid';
import FormControlLabel from '@mui/material/FormControlLabel';
import TextField from '@mui/material/TextField';
import AccountCircle from '@mui/icons-material/AccountCircle';
import LocationOn from '@mui/icons-material/LocationOn';
import Radio from '@mui/material/Radio';
import RadioGroup from '@mui/material/RadioGroup';
import FormControl from '@mui/material/FormControl';
import FormLabel from '@mui/material/FormLabel';
import InputAdornment from '@mui/material/InputAdornment';
import axios from "axios";
import { toast, ToastContainer } from 'react-toastify';
import { postAccountSet } from '../../services/auth';
import UserContext from '../../context/userContext';
import Constants from "../../Constants";
import { useNavigate } from 'react-router-dom';


function Copyright(props) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
    >
      {"TCC UMC © "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

export default function PersonalForm() {
  const [userInfo, setUserInfo] = useContext(UserContext).state;
  const [cpf, setCpf] = useState();
  const [email, setEmail] = useState();
  const [loading, setLoading] = useState(false);
  const [toastConfig] = useState({
    position: "bottom-center",
    autoClose: 5000,
    hideProgBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    prog: undefined,
  });

  const navigate = useNavigate();

  const onReturn = (event) => {
    event.preventDefault();
    localStorage.removeItem("@tccToken");
    window.location.href = '/'
  };

  useEffect(() => {
    if (userInfo.token) axios
      .get(`${Constants.url.route}/Users/GetUserEmailAndDocument`, {
        headers: {
          'authorization': `Bearer ${userInfo.token}`
        }
      })
      .then(({ data }) => {
        if (!data.cpf || !data.email) throw Error;
        setCpf(data.cpf);
        setEmail(data.email);
      }).catch(() => toast.error('Erro ao consultar dados do usuário', toastConfig))
  }, [userInfo, toastConfig]);

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

    if (!name || !street || !number || !complement || !neighborhood ||
      !city || !state || !country || !zipCode) {
      return toast.info('Preencha todos os campos do formulário!', toastConfig);
    }

    setLoading(true);

    var body = {
      name: name,

      add: {
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
    axios
      .put(`${Constants.url.route}/Users/ContinueAccountRegister`, body, {
        headers: {
          'authorization': userInfo.token
        }
      })
      .then(() => {
        notify();
        setLoading(false);
        setUserInfo({...userInfo, wasPostRegistered: true});
        setTimeout(function () {
          navigate('/');
        }, 5000);
      })
      .catch((err) => {
        setLoading(false);
        var message = JSON.parse(err.request.onse).Message;
        toast.error(message, {
          position: "bottom-center",
          autoClose: 5000,
          hideProgBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          prog: undefined,
        });
      });

  };

  const notify = () => toast.success('Dados cadastrados com sucesso!', {
    position: "bottom-left",
    autoClose: 5000,
    hideProgBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    prog: undefined,
  });

  return (
    <React.Fragment>
      <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%', position: 'absolute' }}>
      <div style={{ height: '100%', width: '20%', background: "#04cfd1", borderTopRightRadius: 10, borderBottomRightRadius: 10, padding: 25 }}>
        <img src={Logo} alt="Logo" style={{ width: '75%' }} />
        <hr />

        <div style={{ width: "100%", marginLeft: 25, height: '82%' }}>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/')}>
            INICIO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            CONSULTAS
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/exame')}>
            EXAMES
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/financeiro')}>
            FINANCEIRO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'not-allowed' }}>
            PROFISSIONAL
          </p>
          <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/perfil')}>
            PERFIL
          </h1>
        </div >
        <hr />
        <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => navigate('/login')}>
          SAIR
        </p>
      </div>
      </div>
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
                value={email}
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
                value={cpf}
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
