import React, { useContext, useState, useEffect, useMemo } from "react";
import UserContext from "../../context/userContext";
import Logo from '../../assets/img/logo-c-nome.svg'
import { useNavigate } from 'react-router-dom';
import api from '../../Constants';
import axios from "axios";
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
                        <label>Exame</label>
                        <Input
                          id="exame"
                          name="exame"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="4">
                      <FormGroup>
                        <label>Unidade</label>
                        <Input
                          id="unidade"
                          name="unidade"
                          label="Unidade"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="4">
                    <FormGroup>
                        <label htmlFor="availableDate">Data Disponivel</label>
                        <Input
                          id="date"
                          name="date"
                          label="date"
                          type="date"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col md="12">
                      <FormGroup>
                        <label>Observações:</label>
                        <Input
                          type="textarea"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <div className="text-right">
                      <Button
                        type="button"
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
                      <th>Exames</th>
                      <th>Detalhes</th>
                      <th>Data Exames</th>
                      {/* <th>Situação Exames</th> */}
                      <th>Valor</th>
                      <th>Situação pagamento</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    {data && data.map((item) => (
                      <>
                        <tr>
                          <td>{item.procedure.name}</td>
                          <td>{item.observations}</td>
                          <td>{item.consultStart.split('-')[2].split("T")[0]}/{item.consultStart.split('-')[1]}/{item.consultStart.split("-")[0]}</td>
                          {/* <td></td> */}
                          <td>R$ {item.procedure.price}</td>
                          <td>{item.paymentStatus}</td>
                          <td className="text-right">Visualizar | Excluir</td>
                        </tr>
                        {console.log(item)}
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
