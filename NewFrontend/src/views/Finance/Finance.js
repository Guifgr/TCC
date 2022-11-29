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
  Col
} from "reactstrap";

function Tables() {
  const navigate = useNavigate();

  return (
    <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%' }}>
      <div style={{ height: '100%', width: '20%', background: "#03ACAE", borderTopRightRadius: 20, borderBottomRightRadius: 20, padding: 10 }}>
        <img src={Logo} alt="Logo" style={{ width: '75%' }} />
        <hr />

        <div style={{ width: "100%", marginLeft: 25, height: '82%' }}>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/')}>
            INICIO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            CONSULTAS
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/exame')}>
            EXAMES
          </p>
          <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/financeiro')}>
            FINANCEIRO
          </h1>
          {/* <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            PROFISSIONAL
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            PERFIL
          </p> */}
        </div>
        <hr />
        <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => navigate('/login')}>
          SAIR
        </p>
      </div>
      <div className="content" style={{ width: '80%', padding: 10 }}>
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
    </div>
  );
}

export default Tables;
