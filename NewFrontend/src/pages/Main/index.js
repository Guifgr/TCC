import React, { useEffect, useState, useContext } from "react";
import { useNavigate } from 'react-router-dom';
import UserContext from "../../context/userContext";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { getWasPostRegistered } from '../../services/auth';
import { toast, ToastContainer } from "react-toastify";
import axios from "axios";
import Constants from '../../Constants';


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
    <>
      <div className="content">
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


      </div>
      <ToastContainer />
    </>
  );

}



