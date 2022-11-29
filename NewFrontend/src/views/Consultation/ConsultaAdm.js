import React, { useContext, useMemo, useState } from "react";
import UserContext from "../../context/userContext";
import { toast, ToastContainer } from "react-toastify";
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
  Button,
} from "reactstrap";
import axios from "axios";
import Constants from "../../Constants";
import ReactSelect from "react-select";

function ConsultaAdm({ translatePaymentStatus, translateConsultStatus }) {
  const [userInfo] = useContext(UserContext).state;
  const [consults, setConsults] = useState([]);
  const [pacients, setPacients] = useState([]);
  const [professionals, setProfessionals] = useState([]);
  const [procedures, setProcedures] = useState([]);
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState({
    procedure: "",
    consultStart: "",
    professional: "",
  });
  const [selectedPacient, setSelectedPacient] = useState();
  const [toastConfig] = useState({
    position: "bottom-center",
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    allowHtml: true,
  });
  const getConsults = () => {
    const headers = {
      authorization: `Bearer ${userInfo.token}`,
    };
    axios
      .get(`${Constants.url.route}/Consults/GetClinicConsults`, {
        headers,
      })
      .then(({ data }) => {
        if (!Array.isArray(data)) {
          setLoading(false);
          throw Error;
        }
        console.log(data);
        setConsults(data);
        setLoading(false);
      })
      .catch(() => {
        toast.error("Erro ao buscar consultas", toastConfig);
      });
  };
  useMemo(() => {
    if (userInfo.token) {
      const headers = {
        authorization: `Bearer ${userInfo.token}`,
      };
      setLoading(true);
      axios
        .get(`${Constants.url.route}/Consults/GetClinicConsults`, {
          headers,
        })
        .then(({ data }) => {
          if (!Array.isArray(data)) throw Error;
          setConsults(data);
        })
        .catch(() => {
          toast.error("Erro ao buscar consultas", toastConfig);
        });
      axios
        .get(`${Constants.url.route}/Clinic/ListUsers`, {
          headers,
        })
        .then(({ data: rawData }) => {
          if (!Array.isArray(rawData)) throw Error;
          const data = rawData
            .filter((d) => d.name !== "")
            .map((d) => ({ value: d.guid, label: d.name }));
          setPacients(data);
        })
        .catch(() => {
          toast.error("Erro ao buscar pacientes", toastConfig);
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
      setLoading(false);
    }
  }, [userInfo, toastConfig]);

  const handleSubmit = (ev) => {
    ev.preventDefault();
    setLoading(true);
    const form = new FormData(ev.currentTarget);
    const date = form.get("availableDate");
    const body = { ...formData, consultStart: date };
    setFormData(body);
    if (Object.values(body).some((v) => !v) || !selectedPacient) {
      loading(false);
      toast.info("Todos os campos devem ser preenchidos", toastConfig);
      return;
    }
    axios
      .post(
        `${Constants.url.route}/Consults/ClinicCreateConsult/${selectedPacient}`,
        body,
        {
          headers: {
            authorization: `Bearer ${userInfo.token}`,
          },
        }
      )
      .then(({ data }) => {
        if (!data.consultStart) throw Error;
        toast.success(
          `Consulta agendada para data ${new Date(
            data.consultStart
          ).toLocaleDateString("pt-br")}`,
          toastConfig
        );
      })
      .then(() => getConsults());
  };

  return (
    <>
      <div className="content">
        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Agendar Consulta ADM</CardTitle>
              </CardHeader>
              <CardBody>
                <Form onSubmit={handleSubmit}>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label htmlFor="consult">Consulta</label>
                        <ReactSelect
                          id="consult"
                          name="consult"
                          label="Email"
                          onChange={(v) =>
                            setFormData({ ...formData, procedure: v.value })
                          }
                          options={procedures}
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
                          min={Date.now}
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="6">
                      <FormGroup>
                        <label htmlFor="medic">Médico(a)</label>
                        <ReactSelect
                          options={professionals}
                          onChange={(v) =>
                            setFormData({ ...formData, professional: v.value })
                          }
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="6">
                      <FormGroup>
                        <label htmlFor="pacient">Paciente</label>
                        <ReactSelect
                          options={pacients}
                          onChange={(v) => setSelectedPacient(v.value)}
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
                        sx={{ mt: 3, mb: 2 }}
                      >
                        Salvar Dados
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
                <CardTitle tag="h4">Histórico de Consultas ADM</CardTitle>
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
                    {consults &&
                      consults.map(
                        (
                          {
                            guid,
                            qualifieldProfessionals,
                            procedure: { name: procedureName, price },
                            observations,
                            consultStart,
                            status,
                            paymentStatus,
                          },
                          key
                        ) => (
                          <tr key={key}>
                            <td>{"Jhon doe ltda"}</td>
                            <td>
                              {qualifieldProfessionals
                                ? qualifieldProfessionals[0].nome
                                : "Nenhum médico encontrado"}
                            </td>
                            <td>{procedureName}</td>
                            <td>{observations ? observations : "Nenhum"}</td>
                            <td>
                              {new Date(consultStart).toLocaleDateString(
                                "pt-br"
                              )}
                            </td>
                            <td>{translateConsultStatus(status)}</td>
                            <td>{price?.toLocaleString("pt-br")}</td>
                            <td>{translatePaymentStatus(paymentStatus)}</td>
                            <td
                              className="consult-clinic-delete"
                              onClick={() => {
                                axios
                                  .delete(
                                    `${Constants.url.route}/Consults/DeleteConsultClinic/${guid}`,
                                    {
                                      headers: {
                                        authorization: `Bearer ${userInfo.token}`,
                                      },
                                    }
                                  )
                                  .then(() => {
                                    setConsults(
                                      consults.filter((c) => c.guid !== guid)
                                    );
                                  });
                              }}
                            >
                              Excluir
                            </td>
                          </tr>
                        )
                      )}
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

export default ConsultaAdm;
