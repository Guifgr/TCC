import React from "react";
import Logo from '../../assets/img/logo-c-nome.svg'
import { useNavigate } from 'react-router-dom';

import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Table,
  Row,
  Col,
  Form,
  FormGroup,
  Input,
  Button
} from "reactstrap";

function Exams() {
  const navigate = useNavigate();

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
                <CardTitle tag="h4">Editar Exame</CardTitle>
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
                        <label>Data Disponivel</label>
                        <Input
                          id="date"
                          name="date"
                          label="date"
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
                        type="submit"
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
        <Row>
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
                      <th>Situação Exames</th>
                      <th>Valor</th>
                      <th>Situação pagamento</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>Raiox</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Excluir</td>
                    </tr>
                    <tr>
                      <td>Raiox</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Excluir</td>
                    </tr>
                    <tr>
                      <td>Raiox</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Excluir</td>
                    </tr>
                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </div>
    </div>
  );
}

export default Exams;
