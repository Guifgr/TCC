import React, { useContext, useState, useEffect } from "react";
// import ListConsultaPatient from "./ConsultaPatient";
// import ListConsultAdm from "./ConsultaAdm";
import UserContext from "../../context/userContext";
import Logo from '../../assets/img/logo-c-nome.svg'
import { useNavigate } from 'react-router-dom';
import {
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Input,
  CardTitle,
  Form,
  FormGroup,
  Table,
  Row,
  Button,
  Col
} from "reactstrap";

function Exams() {
  const [userInfo] = useContext(UserContext).state;
  const navigate = useNavigate();
  const [data, setData] = useState("");
  const [exam, setExam] = useState("");
  const [price, setPrice] = useState("");

  const getExams = async () => {
    const exams = await fetch("https://9d7d-2804-431-cfc3-5e42-3de6-1e68-1f4a-2d38.sa.ngrok.io/Procedures/GetClinicProcedure", {
      method: "get",
      headers: new Headers({
        "Authorization": `Bearer ${localStorage.getItem("token")}`,
        'Content-Type': 'text/plain'
      })
    });


    const final = await exams.json();

    setData(final)
  }

  useEffect(() => {
    getExams();
  }, [])

  const translatePaymentStatus = (status) => {
    switch (status) {
      case 'Open':
        return 'Aberto';
      case 'Paid':
        return 'Pago';
      case 'Pendency':
        return 'Pendente';
      default:
        return '?';
    }
  }

  const sendData = async () => {
    try {
      if (exam === '' || price === '') {

      } else {
        fetch('https://9d7d-2804-431-cfc3-5e42-3de6-1e68-1f4a-2d38.sa.ngrok.io/Procedures/CreateClinicProcedure', {
          method: "post",
          body: {
            name: exam,
            procedureMinutes: 0,
            price,
            qualifieldProfessionals: {}
          },
          headers: new Headers({
            "Authorization": `Bearer ${localStorage.getItem("token")}`,
            'Content-Type': 'text/plain'
          })
        })
      }
    } catch (err) {

    }
  };



  const translateConsultStatus = (status) => {
    switch (status) {
      case 'Open':
        return 'Aberto';
      case 'Closed':
        return 'Fechado';
      case 'Canceled':
        return 'Cancelado';
      default:
        return '?';
    }
  }
  return (
    <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%' }}>
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
          <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/exame')}>
            EXAMES
          </h1>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/financeiro')}>
            FINANCEIRO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/profissional')}>
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

      <div className="content" style={{ width: '80%', padding: 10 }}>
        <div style={{ width: '100%', padding: 20, height: '100%' }}>
          <p style={{ marginBottom: '5%', fontSize: 32 }}>
            Exames
            <hr></hr>
          </p>
          <Row>
            <Col md="12">
              <Card>
                <CardHeader>
                  <CardTitle tag="h4">Agendar Exame</CardTitle>
                </CardHeader>
                <CardBody>
                  <Form>
                    <Row>
                      <Col className="pr-1" md="4">
                        <FormGroup>
                          <label>Nome do exame</label>
                          <Input
                            onChange={(e) => setExam(e.target.value)}
                            id="exame"
                            name="exame"
                            label="exame"
                          />
                        </FormGroup>
                      </Col>
                      <Col className="px-1" md="4">
                        <FormGroup>
                          <label>Preço</label>
                          <Input
                            onChange={(e) => setPrice(e.target.value)}
                            id="preco"
                            name="preco"
                            label="preco"
                          />
                        </FormGroup>
                      </Col>
                    </Row>
                    <Row>
                      <Col md="12">
                        <FormGroup>
                          <label>Médico:</label>
                          <Input
                            type="textarea"
                          />
                        </FormGroup>
                      </Col>
                    </Row>
                    <Row>
                      <div className="text-right">
                        <Button
                          onClick={() => sendData()}
                          color="primary"
                          variant="contained"
                          sx={{ mt: 3, mb: 2 }}>Salvar Dados
                        </Button>
                      </div>
                    </Row>

                  </Form>
                </CardBody>
              </Card>
            </Col>
          </Row>
          <div className="stats">
            <br></br>
          </div>
          <Row style={{ marginTop: 20 }}>
            <Col md="12">
              <Card>
                <CardHeader>
                  <CardTitle tag="h4">Histórico de Exames</CardTitle>
                </CardHeader>
                <CardBody>
                  <Table responsive>
                    <thead className="text-primary">
                      <tr>
                        <th>Médico</th>
                        <th>Exame</th>
                        <th>Valor</th>
                        {/* <th>Situação Exames</th> */}
                        {/* <th>Valor</th>
                      <th>Situação pagamento</th> */}
                        <th className="text-right"></th>
                      </tr>
                    </thead>
                    <tbody>
                      {data && data.map((item) => (
                        <>
                          <tr>
                            <td>{item.qualifieldProfessionals.name}</td>
                            <td>{item.name}</td>
                            <td>R$ {item.price}</td>
                            {/* <td></td> */}
                            {/* <td>R$ {item.procedure.price}</td>
                          <td>{item.paymentStatus}</td> */}
                            <td className="text-right">Visualizar | Excluir</td>
                          </tr>
                        </>

                      ))}
                    </tbody>
                  </Table>
                </CardBody>
              </Card>
            </Col>
          </Row>
        </div>
      </div>
    </div >
  );
}

export default Exams;
