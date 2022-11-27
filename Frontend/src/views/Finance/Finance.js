import React from "react";


import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Table,
  Row,
  Col
} from "reactstrap";

function Tables() {
  return (
    <>
      <div className="content">
        <Row>
          <Col md="12">
            <Card>
              <CardHeader>
                <CardTitle tag="h4">Mensalidades e Serviços</CardTitle>
              </CardHeader>
              <CardBody>
                <Table responsive>
                  <thead className="text-primary">
                    <tr>
                      <th>Lançamento</th>
                      <th>Detalhes</th>
                      <th>Valor</th>
                      <th>Situação</th>
                      <th className="text-right">Valor pago</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td>Mensalidade 01</td>
                      <td>Consulta Aparelho</td>
                      <td>R$ 59,00</td>
                      <td>Pago</td>
                      <td className="text-right">R$ 59,00</td>
                    </tr>
                    <tr>
                      <td>Mensalidade 02</td>
                      <td>Limpeza</td>
                      <td>R$ 198,00</td>
                      <td>Atraso</td>
                      <td className="text-right">R$ 100,00</td>
                    </tr>
                    <tr>
                      <td>Mensalidade 03</td>
                      <td>Consulta Aparelho</td>
                      <td>R$ 59,00</td>
                      <td>Em Aberto</td>
                      <td className="text-right">R$ 59,00</td>
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

export default Tables;
