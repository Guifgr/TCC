import React, { useContext, useState, useEffect, useMemo } from "react";
import UserContext from "../../context/userContext";
import axios from "axios";
import api from '../../Constants';
import { toast, ToastContainer } from 'react-toastify';

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

function ConsultaPatient() {
  const [userState] = useContext(UserContext).state;
  const [consults, setConsults] = useState([]);
  useMemo(() => {
    if (userState.token) axios.get(`${api.url.route}/Consults/GetUserConsults  `, {
      headers: {
        'authorization': `Bearer ${userState.token}`
      }
    }).then((res) => {
      const data = res.data;
      if (!Array.isArray(data)) return;
      setConsults(data);
    }).catch(() => {
      toast.error('Erro ao buscar consultas', {
        position: "bottom-center",
        autoClose: 6000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        allowHtml: true
      })
    });
  }, [userState]);
  return (
    <>
      <div className="content">

        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Agendar Consulta PACIENTE</CardTitle>
              </CardHeader>
              <CardBody>
                <Form>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label>Consulta</label>
                        <Input
                          id="exame"
                          name="exame"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
                      <FormGroup>
                        <label>Unidade</label>
                        <Input
                          id="unidade"
                          name="unidade"
                          label="Unidade"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label>Médico(a)</label>
                        <Input
                          id="exame"
                          name="exame"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
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
                        <label>Observações/Detalhes:</label>
                        <Input
                          type="textarea"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <div className="update ml-auto mr-auto">
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

        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Histórico de Consultas PACIENTE</CardTitle>
              </CardHeader>
              <CardBody>
                <Table responsive>
                  <thead className="text-primary">
                    <tr>
                      <th>Paciente</th>
                      <th>CPF</th>
                      <th>Consultas</th>
                      <th>Medico</th>
                      <th>Unidade</th>
                      <th>Data Consultas</th>
                      <th>Situação Consultas</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    {consults && consults.map({}, key) => (<tr key={key}>
                      <td></td>
                    </tr>) }
                    <tr>
                      <td>Maria Silva</td>
                      <td>08869697799</td>
                      <td>Orçamento</td>
                      <td>Drº João</td>
                      <td>Ferraz - SP</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td className="text-right">Visualizar | Excluir</td>
                    </tr>
                    <tr>
                      <td>Maria Silva</td>
                      <td>08869697799</td>
                      <td>Orçamento</td>
                      <td>Drº João</td>
                      <td>Ferraz - SP</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td className="text-right">Visualizar | Excluir</td>
                    </tr>

                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
      <ToastContainer />
    </>
  );
}

export default ConsultaPatient;
