import React from "react";

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

function ConsultaAdm() {
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
                      <th>Consultas</th>
                      <th>Detalhes</th>
                      <th>Data Consultas</th>
                      <th>Situação Consultas</th>
                      <th>Valor</th>
                      <th>Situação pagamento</th>
                      <th className="text-right"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>Ferraz de Vasconcelos-SP</td>
                      <td>Drº João</td>
                      <td>Orçamento</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Visualizar | Excluir</td>
                    </tr>
                    <tr>
                      <td>Ferraz de Vasconcelos-SP</td>
                      <td>Drº João</td>
                      <td>Orçamento</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Visualizar | Excluir</td>
                    </tr>
                    <tr>
                      <td>Ferraz de Vasconcelos-SP</td>
                      <td>Drº João</td>
                      <td>Orçamento</td>
                      <td>Para aparelho odonto</td>
                      <td>20/11/2022</td>
                      <td>Em andamento</td>
                      <td>R$ 60,00</td>
                      <td>Pago</td>
                      <td className="text-right">Visualizar | Excluir</td>
                    </tr>
                  </tbody>
                </Table>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </>
  );
}

export default ConsultaAdm;
