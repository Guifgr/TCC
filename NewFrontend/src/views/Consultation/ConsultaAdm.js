import React, { useContext, useMemo, useState } from "react";
import UserContext from "../../context/userContext";
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
import axios from "axios";
import Constants from "../../Constants";
import ReactSelect from "react-select";

function ConsultaAdm({ translatePaymentStatus, translateConsultStatus  }) {
  const [userInfo] = useContext(UserContext).state;
  const [consults, setConsults] = useState([]);
  const [pacients, setPacients] = useState([]);
  const [selectedPacient, setSelectedPacient] = useState();
  const [toastConfig] = useState({
    position: "bottom-center",
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    allowHtml: true
  });
  useMemo(() => {
    if (userInfo.token) {
      axios.get(`${Constants.url.route}/Consults/GetClinicConsults`,{
        headers: {
          'authorization': `Bearer ${userInfo.token}`
        }
      })
      .then(({ data }) => {
        if (!Array.isArray(data)) throw Error;
        setConsults(data);
      }).catch(() => {
        toast.error('Erro ao buscar consultas', toastConfig)
      });
      axios.get(`${Constants.url.route}/Clinic/ListUsers`, {
        headers: {
          'authorization': `Bearer ${userInfo.token}`
        }
      })
      .then(({ data: rawData }) => {
        if (!Array.isArray(rawData)) throw Error;
        const data = rawData.map((d) => ({ value: d.guid, label: d.name }));
        setPacients(data);
      })
      .catch(() => {
        toast.error('Erro ao buscar pacientes', toastConfig);
      });
    }
  }, [userInfo, toastConfig]);

  const handleSubmit = (ev) => {
    ev.preventDefault();
    const form = new FormData(ev.currentTarget);
    const consult = form.get('consult');
    const unit = form.get('unidade');
    const medic = form.get('medic');
    const availableDate = form.get('availableDate');
    const observations = form.get('obs'); 
    if ([
      consult,
      unit,
      medic,
      availableDate,
      observations
    ].some(v => !v)) toast.info('Todos os campos devem ser preenchidos', toastConfig);
  }

  return (
    <div style={{ width: '100%', padding: 20, height: '100%' }}>
        <p style={{ marginBottom: '5%', fontSize: 32 }}>
          Consultas
          <hr></hr>
        </p>
      <div className="content">

        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Agendar Consulta para o paciente</CardTitle>
              </CardHeader>
              <CardBody>
                <Form onSubmit={handleSubmit}>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label htmlFor="consult">Consulta</label>
                        <Input
                          id="consult"
                          name="consult"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
                      <FormGroup>
                        <label htmlFor="unidade">Unidade</label>
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
                        <label htmlFor="medic">Médico(a)</label>
                        <Input
                          id="medic"
                          name="medic"
                          label="Médico(a)</"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
                      <FormGroup>
                        <label htmlFor="availableDate">Data Disponivel</label>
                        <Input
                          id="availableDate"
                          name="availableDate"
                          label="Data disponível"
                          type="date"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                  <Col className="px-1" md="6">
                    <label htmlFor="pacient">Paciente</label>
                    <ReactSelect 
                      options={pacients}
                      onChange={(ev) => console.log(ev.target.value)}
                    />
                  </Col>
                    
                  </Row>
                  <Row>
                    <Col md="12">
                      <FormGroup>
                        <label>Observações:</label>
                        <Input
                          type="textarea"
                          id="obs"
                          name="obs"
                          label="Observações"
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
                <CardTitle tag="h4" >Histórico de Consultas dos pacientes</CardTitle>
              </CardHeader>
              <CardBody>
                <Table responsive>
                  <thead className="text-primary">
                    <tr>
                      <th>Unidade</th>
                      <th>Médico</th>
                      <th>Consulta</th>
                      <th>Detalhes</th>
                      <th>Data Consulta</th>
                      <th>Situação Consulta</th>
                      <th>Valor</th>
                      <th>Situação pagamento</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    { consults && consults.map(({ guid, clinic: { name }, qualifieldProfessionals, procedure: { name: procedureName, price }, observations, consultStart, status, paymentStatus }, key) => <tr key={key}>
                      <td>{ name }</td>
                      <td>{ qualifieldProfessionals ? qualifieldProfessionals[0].nome : 'Nenhum médico encontrado' }</td>
                      <td>{procedureName}</td>
                      <td>{observations ? observations : 'Nenhum'}</td>
                      <td>{new Date(consultStart).toLocaleDateString('pt-br')}</td>
                      <td>{ translateConsultStatus(status) }</td>
                      <td>{ price?.toLocaleString('pt-br') }</td>
                      <td>{ translatePaymentStatus(paymentStatus) }</td>
                      <td className='consult-clinic-delete' onClick={() => toast.info(`isto deveria deletar consulta ${guid}`, toastConfig)}>Excluir</td>
                    </tr>) }
                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
      <ToastContainer />
      </div>
  );
}

export default ConsultaAdm;
