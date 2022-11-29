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
  // useEffect(() => {
  //   axios.get(`${Constants.url.route}/Dashbard/GetDashboardInfo`, {
  //     headers: {
  //       'authorization': `Bearer ${userData.token}`
  //     }
  //   }).then(({ data }) => {
  //     console.log(data);
  //     if (!queryed) {
  //       console.log(data.debtsList);
  //       setDebts(data.debtsList.debts);
  //       setTotalDebts(data.debtsList.total);
  //       setPendingPersonalInfo(data.pendingPersonalInfo);
  //       setPendingConsults(data.pendingConsults);
  //       setPendingExams(data.pendingExams);
  //       setQueryed(true);
  //     }
  //   }).catch((e) => {
  //     console.log(e.message);
  //     toast.error(`Erro ao consultar dados`, {
  //       position: "bottom-center",
  //       autoClose: 4000,
  //       hideProgressBar: false,
  //       closeOnClick: true,
  //       pauseOnHover: true,
  //       draggable: true,
  //       progress: undefined,
  //       allowHtml: true
  //     });
  //   });
  // }, [userData]);
  // if (!userData.wasPostRegistered) {
  //   navigate('/pos-cadastro');
  // }

  return (
    <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%' }}>
      <div style={{ height: '100%', width: '20%', background: "#03ACAE", borderTopRightRadius: 20, borderBottomRightRadius: 20, padding: 10 }}>
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
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            FINANCEIRO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            PROFISSIONAL
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            PERFIL
          </p>
        </div>
        <hr />
        <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => navigate('/login')}>
          SAIR
        </p>
      </div>

      <div style={{ width: '60%', padding: 20, height: '100%' }}>
        <p style={{ marginBottom: '5%', fontSize: 32 }}>
          Início
        </p>

        <div style={{ display: 'flex', flexDirection: 'row', justifyContent: 'space-between' }}>
          <div style={{ width: '49%', background: "#03ACAE", borderRadius: 20, textAlign: 'center', padding: 5 }}>
            <p style={{ color: 'white', fontSize: 24 }}>Débitos Pendentes</p>
            <p style={{ color: "#FF0000", fontSize: 18 }}>Possui débitos em aberto</p>
          </div>
          <div style={{ width: '49%', background: "#03ACAE", borderRadius: 20, textAlign: 'center', padding: 5 }}>
            <p style={{ color: 'white', fontSize: 24 }}>Informações Pendentes</p>
            <p style={{ fontSize: 18 }}>Seu cadastro está OK</p>
          </div>
        </div>

        <div style={{ marginTop: 30, display: 'flex', flexDirection: 'row', justifyContent: 'space-between' }}>
          <div style={{ width: '49%', background: "#03ACAE", borderRadius: 20, textAlign: 'center', padding: 5 }}>
            <p style={{ color: 'white', fontSize: 24 }}>Consultas Pendentes</p>
            <p style={{ fontSize: 18 }}>Não possui consultas</p>
          </div>
          <div style={{ width: '49%', background: "#03ACAE", borderRadius: 20, textAlign: 'center', padding: 5 }}>
            <p style={{ color: 'white', fontSize: 24 }}>Exames Pendentes</p>
            <p style={{ color: "#FF0000", fontSize: 18 }}>Possui exames em aberto</p>
          </div>
        </div>

      </div>
      {/* <div className="content">
        <Row>

          <Col lg="6" md="8" sm="8">
            <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="5">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-money-coins text-success" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Financeiro</p>
                      <CardTitle tag="p">MOSTRAR DÉBITOS</CardTitle>
                      <p />
                      <ul>
                        {debts.length > 0 ? debts.map(({ procedureName, procedurePrice }, key) =>
                          (<li key={key}>{procedureName}: {procedurePrice?.toLocaleString('pt-br')} </li>))
                        : 'Nenhum débito encontrado.'}
                      </ul>
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats">
                  Saldo: {totalDebts.toLocaleString('pt-br')}
                </div>
              </CardFooter>
            </Card>
          </Col>


          <Col lg="6" md="8" sm="8">
            <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="6">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-satisfied text-warning" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Perfil</p>
                      <CardTitle tag="p">INFORMAÇÕES PENDENTES</CardTitle>
                      <p />
                      <ul>
                        {pendingPersonalInfo.length > 0 ? pendingPersonalInfo.map((info, key) =>
                          (<li key={key}>{info}</li>))
                        : 'Parabéns, não há nenhuma informação pendente.'}
                      </ul>
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats"> Dados Pessoais
                </div>
              </CardFooter>
            </Card>
          </Col>
        </Row>
        <Row>

          <Col lg="6" md="8" sm="8">
            <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="5">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-ambulance text-danger" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Consultas</p>
                      <CardTitle tag="p">CONSULTAS PENDENTES</CardTitle>
                      <p />
                      <ul>
                        {pendingConsults.length > 0 ? pendingConsults.map(({ procedureName, date }, key) =>
                          (<li key={key}>{procedureName} - {new Date(date).toLocaleDateString("pt-br")}</li>))
                        : 'Não há nenhuma consulta pendente'}
                      </ul>
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats">
                  <i className="far fa-calendar" /> Calendário
                </div>
              </CardFooter>
            </Card>
          </Col>

          <Col lg="6" md="8" sm="8">
            <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="6">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-favourite-28 text-primary" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Exames</p>
                      <CardTitle tag="p">EXAMES PENDENTES</CardTitle>
                      <p />
                      <ul>
                        {pendingExams.length > 0 ? pendingExams.map(({ procedureName }, key) =>
                          (<li key={key}>{procedureName}</li>)) : "Não há nenhum exame pendente"}
                      </ul>
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats">
                  <i className="far fa-calendar" /> Calendário
                </div>
              </CardFooter>
            </Card>
          </Col>
        </Row>


      </div> */}
      <ToastContainer />
    </div>
  );

}



