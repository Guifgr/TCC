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

function Professional() {
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
        <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/exame')}>
        EXAMES
          
        </p>
        <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/financeiro')}>
          FINANCEIRO
        </p>
        <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/profissional')}>
        PROFISSIONAL
          </h1>

        <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/perfil')}>
          PERFIL
        </p>
      </div>
      <hr />
      <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => navigate('/login')}>
        SAIR
      </p>
    </div>

    
      <div className="content">
      <div className="content" style={{ width: '390%', padding: 10 }}>
      <div style={{ width: '100%', padding: 20, height: '100%' }}>
        <p style={{ marginBottom: '5%', fontSize: 32 }}>
          Profissional
          <hr></hr>
        </p>
       
            <Row>
              <Col md="12">
                <Card>
                  <CardHeader>
                    <CardTitle tag="h4">Agenda Profissional</CardTitle>
                  </CardHeader>
                  <CardBody>
                    <Table responsive>
                      <thead className="text-primary">
                        <tr>
                          <th>Data</th>
                          <th>Detalhes</th>
                          <th>Situação</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td>18/12/2022</td>
                          <td>Consulta Aparelho</td>
                          <td>Em aberto</td>
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
    </div>
  );
}

export default Professional;
