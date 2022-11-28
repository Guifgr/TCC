import axios from "axios";
import Constants from "Constants";
import React, { useState } from "react";
import { toast } from 'react-toastify';
import { Button, Card, CardHeader, CardBody, CardTitle, FormGroup, Form, Input, Row, Col } from "reactstrap";

function UpdatePatient() {

  const [loading, setLoading] = useState(false);

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    var email = data.get("email");
    var password = data.get("password");


    if (email == null || password == null || email == '' || password == '') {
      return toast.warning('Preecha todos os campos', {
        position: "bottom-right",
        autoClose: 2000,
        hideProgressBar: true,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        allowHtml: true
      });
    }

    setLoading(true);

    var body = {
      email: email,
      password: password
    };
    axios
      .post(`${Constants.url.route}/Auth/Login`, body)
      .then((res) => {
        localStorage.setItem("@tccToken", JSON.stringify(res.data));
        if (res.data.token != null) {
        } else {
          localStorage.removeItem("@tccToken");
          throw Error;
        }
        setLoading(false);
        window.location.href = '/'
      })
      .catch((err) => {
        var error = JSON.parse(err.request.response).Message
        setLoading(false);
        toast.error(error, {
          position: "bottom-right",
          autoClose: 2000,
          hideProgressBar: true,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
          allowHtml: true
        });
        if (error == 'Usuário ainda não confirmou a conta por email!') {
          toast.info('Não se preocupe já enviamos um novo email para você!', {
            position: "bottom-right",
            autoClose: 2000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            allowHtml: true
          });
        }
      });
  };

  return (
    <>
      <div className="content">
        <Row>
          <Col md="4">
            <Card className="card-user">
              <div className="image">
              </div>
              <CardBody>
                <div className="author">
                  <a href="#pablo" onClick={(e) => e.preventDefault()}>
                    <img
                      alt="..."
                      className="avatar border-gray"
                      // src={require("../assets/img/logo.png")}
                    />
                    <h5 className="title">fulaninho de tal</h5>
                  </a>
                </div>
              </CardBody>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle tag="h4">Dados</CardTitle>
              </CardHeader>
              <CardBody>
                <Form>
                  <Row>
                    <Col className="pr-1" md="12">
                      <FormGroup>
                        <label>Alergico algum médicamento?</label>
                        <Input
                          id="firstName"
                          name="firstName"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="12">
                      <FormGroup>
                        <label>Qual?</label>
                        <Input
                          id="firstName"
                          name="firstName"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="12">
                      <FormGroup>
                        <label>Deixe esse campo atualizado para que nossos médicos fiquem sempre atentos!</label>
                      </FormGroup>
                    </Col>
                  </Row>
                </Form>

              </CardBody>
            </Card>

          </Col>
          <Col md="8">
            <Card className="card-user">
              <CardHeader>
                <CardTitle tag="h5">Editar Perfil</CardTitle>
              </CardHeader>
              <CardBody>
                <Form>
                  <Row>
                    <Col className="pr-1" md="8">
                      <FormGroup>
                        <label>Email</label>
                        <Input
                          disabled
                          id="firstName"
                          name="firstName"
                          label="Email"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="4">
                      <FormGroup>
                        <label>CPF</label>
                        <Input
                          disabled
                          id="firstName"
                          name="firstName"
                          label="CPF"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="8">
                      <FormGroup>
                        <label>Nome completo</label>
                        <Input
                          required
                          id="name"
                          name="name"
                          label="Nome Completo"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="pl-1" md="4">
                      <FormGroup>
                        <label>Naturalidade:</label>
                        <Input
                          id="firstName"
                          name="firstName"
                          label="Naturalidade:"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="4">
                      <FormGroup>
                        <label>Data de Nascimento:</label>
                        <Input
                          required
                          id="name"
                          name="name"
                          label="Data de Nascimento:"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="pl-1" md="4">
                      <FormGroup>
                        <label>Sexo:</label>
                        <Input
                          id="firstName"
                          name="firstName"
                          label="Sexo:"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col md="12">
                      <FormGroup>
                        <label>Endereço</label>
                        <Input
                          required
                          id="street"
                          name="street"
                          label="Rua"
                        />
                      </FormGroup>
                    </Col>
                  </Row>
                  <Row>
                    <Col className="pr-1" md="4">
                      <FormGroup>
                        <label>Cidade</label>
                        <Input
                          required
                          id="city"
                          name="city"
                          label="Cidade"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="px-1" md="4">
                      <FormGroup>
                        <label>Estado</label>
                        <Input
                          required
                          id="state"
                          name="state"
                          label="Estado"
                        />
                      </FormGroup>
                    </Col>
                    <Col className="pl-1" md="4">
                      <FormGroup>
                        <label>CEP</label>

                        <Input required
                          id="zipCode"
                          name="zipCode"
                          label="CEP" />
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
      </div>
    </>
  );
}

export default UpdatePatient;
