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
import Constants from "../../Constants";
import ReactSelect from "react-select";

function ConsultaPatient({ translatePaymentStatus, translateConsultStatus  }) {
  const [userInfo] = useContext(UserContext).state;
  const [toastConfig] = useState({
    position: "bottom-center",
    autoClose: 6000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    allowHtml: true
  });
  const [procedures ,setProcedures] = useState([]);
  const [professionals, setProfessionals] = useState([]);
  const [consults, setConsults] = useState([]);
  const [formData, setFormData] = useState({
    procedure: '',
    consultStart: '',
    professional: ''
  });
  const [headers] = useState({
    'authorization': `Bearer ${userInfo.token}`
  });

  const getConsults = () => {
    if (userInfo.token) axios.get(`${api.url.route}/Consults/GetUserConsults  `, {
      headers: {
        'authorization': `Bearer ${userInfo.token}`
      }
    }).then((res) => {
      const data = res.data;
      if (!Array.isArray(data)) return;
      setConsults(data);
    }).catch(() => {
      toast.error('Erro ao buscar consultas', toastConfig);
    });
  }
  useMemo(() => {
    const headers = {
      'authorization': `Bearer ${userInfo.token}`
    }
    if (userInfo.token) {
      axios.get(`${api.url.route}/Consults/GetUserConsults  `, {
        headers,
      }).then((res) => {
        const data = res.data;
        if (!Array.isArray(data)) return;
        setConsults(data);
      }).catch(() => {
        toast.error('Erro ao buscar consultas', toastConfig);
      });
      axios
        .get(`${Constants.url.route}/Professional/GetProfessionals`, {
          headers,
        })
        .then(({ data }) => {
          if (!Array.isArray(data)) throw Error;
          setProfessionals(
            data.map((d) => ({
              value: d.guid,
              label: `${d.nome} ${d.sobrenome}`,
            }))
          );
        });
      axios
        .get(`${Constants.url.route}/Procedures/GetClinicProcedure`, {
          headers: {
            authorization: `Bearer ${userInfo.token}`,
          },
        })
        .then(({ data }) => {
          if (!Array.isArray(data)) throw Error;
          setProcedures(data.map((d) => ({ value: d.guid, label: d.name })));
        });
    }
  }, [userInfo, toastConfig]);

  const handleSubmit = (ev) => {
    ev.preventDefault();
    const form = new FormData(ev.currentTarget);
    const date = form.get('date');
    const body = { ...formData, consultStart: date };
    if (Object.values(body).some((v) => !v)) return toast.info('Todos os campos devem ser preenchidos', toastConfig);
    setFormData(body);
    axios.post(`${Constants.url.route}/Consults/CreateConsult`, body, {
      headers: {
        authorization: `Bearer ${userInfo.token}`,
      }
    }).then(({ data }) => {
      if (!data.consultStart) throw Error;
      toast.success(`Consulta criada para data ${new Date(data.consultStart).toLocaleDateString('pt-br')}`, toastConfig);
    })
    .then(() => {
      getConsults();
    })
    .catch(() => {
      toast.error("Erro ao salvar consulta", toastConfig);
    });
  }

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
                <Form onSubmit={handleSubmit}>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label>Consulta</label>
                        <ReactSelect 
                          options={procedures}
                          onChange={(v) => setFormData({ ...formData, procedure: v.value })}
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
                    <FormGroup>
                        <label>Médico(a)</label>
                        <ReactSelect
                          options={professionals}
                          onChange={(v) => setFormData({ ...formData, professional: v.value })}
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="6">
                    <FormGroup>
                        <label>Data Disponivel</label>
                        <Input
                          id="date"
                          name="date"
                          label="date"
                          type='date'
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
                      <th>Consulta</th>
                      <th>Data/Horário</th>
                      <th>Situação Consultas</th>
                      <th>Valor</th>
                      <th>SitPgto</th>
                      <th>Possui Exame?</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    {consults && consults.map(({consultStart, procedure: { name: procedureName, price = 0 }, paymentStatus, pendingExams, status  }, key) => (<tr key={key}>
                      <td>{ procedureName }</td>
                      <td>{new Date(consultStart).toLocaleDateString('pt-br')}</td>
                      <td>{ translateConsultStatus(status) }</td> 
                      <td>{ price.toLocaleString('pt-br') }</td> 
                      <td>{ translatePaymentStatus(paymentStatus) }</td> 
                      <td>{ pendingExams ? 'Sim' : 'Não' }</td> 
                    </tr>)) }
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
