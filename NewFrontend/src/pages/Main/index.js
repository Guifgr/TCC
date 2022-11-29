import React, { useEffect, useState, useContext } from "react";
import { useNavigate } from 'react-router-dom';
import UserContext from "../../context/userContext";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Sidebar from "../../Components/Sidebar/Sidebar";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { getWasPostRegistered } from '../../services/auth';
import { toast, ToastContainer } from "react-toastify";
import axios from "axios";
import Constants from '../../Constants';
import Logo from '../../assets/img/logo-c-nome.svg'

import {
  Card,
  CardBody,
  CardFooter,
  CardTitle,
  Row,
  Col
} from "reactstrap";

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

export default function Main() {
  const [userData] = useContext(UserContext).state;
  const [queryed, setQueryed] = useState(false);
  const [debts, setDebts] = useState([]);
  const [totalDebts, setTotalDebts] = useState(0);
  const [pendingPersonalInfo, setPendingPersonalInfo] = useState([]);
  const [pendingConsults, setPendingConsults] = useState([]);
  const [pendingExams, setPendingExams] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    axios.get(`${Constants.url.route}/Dashbard/GetDashboardInfo`, {
      headers: {
        'authorization': `Bearer ${userData.token}`
      }
    }).then(({ data }) => {
      console.log(data);
      if (!queryed) {
        console.log(data.debtsList);
        setDebts(data.debtsList.debts);
        setTotalDebts(data.debtsList.total);
        setPendingPersonalInfo(data.pendingPersonalInfo);
        setPendingConsults(data.pendingConsults);
        setPendingExams(data.pendingExams);
        setQueryed(true);
      }
    }).catch((e) => {
      console.log(e.message);
      toast.error(`Erro ao consultar dados`, {
        position: "bottom-center",
        autoClose: 4000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        allowHtml: true
      });
    });
  }, [userData]);
  if (!userData.wasPostRegistered) {
    navigate('/pos-cadastro');
  }

  return (
    <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%' }}>
      <div style={{ height: '100%', width: '20%', background: "#04cfd1", borderTopRightRadius: 10, borderBottomRightRadius: 10, padding: 25 }}>
        <img src={Logo} alt="Logo" style={{ width: '75%' }} />
        <hr />

        <div style={{ width: "100%", marginLeft: 25, height: '82%' }}>
          <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/')}>
            INICIO
          </h1>
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
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/perfil')}>
            PERFIL
          </p>
        </div>
        <hr />
        <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => navigate('/login')}>
          SAIR
        </p>
      </div>

      <div style={{ width: '80%', padding: 20, height: '100%' }}>
        <p style={{ marginBottom: '5%', fontSize: 32 }}>
          Dashboard
          <hr></hr>
        </p>


        <div className="content">
          <Row>

            <Col lg="6" md="8" sm="8">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="8" xs="7">
                      <p style={{ color: 'green', fontSize: 24 }}>Financeiro</p>
                      <CardTitle tag="p">MOSTRAR DÉBITOS</CardTitle>
                      <p />
                      <ul>
                        {debts.length > 0 ? debts.map(({ procedureName, procedurePrice }, key) =>
                          (<li key={key}>{procedureName}: {procedurePrice?.toLocaleString('pt-br')} </li>))
                          : 'Nenhum débito encontrado.'}

                        <div className="stats">
                          Saldo: R$ {totalDebts.toLocaleString('pt-br')}
                        </div>
                      </ul>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                </CardFooter>
              </Card>
            </Col>


            <Col lg="6" md="8" sm="8">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p style={{ color: 'green', fontSize: 24 }}>Perfil</p>
                        <CardTitle tag="p">INFORMAÇÕES PENDENTES</CardTitle>
                        <p />
                        <ul>
                          {pendingPersonalInfo.length > 0 ? pendingPersonalInfo.map((info, key) =>
                            (<li key={key}>{info}</li>))
                            : 'Parabéns, não há nenhuma informação pendente.'}
                        </ul>
                        <div className="stats">
                          <br></br>
                        </div>
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                </CardFooter>
              </Card>
            </Col>
          </Row>
          <div className="stats">
            <br></br>
            <br></br>
          </div>

          <Row>
            <Col lg="6" md="8" sm="8">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p style={{ color: 'green', fontSize: 24 }}>Consultas</p>
                        <CardTitle tag="p">CONSULTAS PENDENTES</CardTitle>
                        <p />
                        <ul>
                          {pendingConsults.length > 0 ? pendingConsults.map(({ procedureName, date }, key) =>
                            (<li key={key}>{procedureName} - {new Date(date).toLocaleDateString("pt-br")}</li>))
                            : 'Não há nenhuma consulta pendente'}
                        </ul>
                        <div className="stats">
                          <br></br>
                        </div>
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                </CardFooter>
              </Card>
            </Col>

            <Col lg="6" md="8" sm="8">
              <Card className="card-stats">
                <CardBody>
                  <Row>
                    <Col md="8" xs="7">
                      <div className="numbers">
                        <p style={{ color: 'green', fontSize: 24 }}>Exames</p>
                        <CardTitle tag="p">EXAMES PENDENTES</CardTitle>
                        <p />
                        <ul>
                          {pendingExams.length > 0 ? pendingExams.map(({ procedureName }, key) =>
                            (<li key={key}>{procedureName}</li>)) : "Não há nenhum exame pendente"}
                        </ul>
                        <div className="stats">
                          <br></br>
                        </div>
                      </div>
                    </Col>
                  </Row>
                </CardBody>
                <CardFooter>
                </CardFooter>
              </Card>
            </Col>
          </Row>


        </div>

        <ToastContainer />
      </div>
    </div>
  );

}



