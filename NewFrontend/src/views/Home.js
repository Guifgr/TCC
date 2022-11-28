
import React from "react";

import {
  Card,
  CardBody,
  CardFooter,
  CardTitle,
  Row,
  Col
} from "reactstrap";

function Dashboard() {
  return (
    <>
      <div className="content">
        <Row>

          <Col lg="6" md="8" sm="8">
            <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="5">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-money-coins text-success" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Financeiro</p>
                      <CardTitle tag="p">MOSTRAR DÉBITOS</CardTitle>
                      <p />
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
                <hr />
                <div className="stats">
                  Saldo
                </div>
              </CardFooter>
            </Card>
          </Col>


          <Col lg="6" md="8" sm="8">
          <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="6">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-satisfied text-warning" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Perfil</p>
                      <CardTitle tag="p">INFORMAÇÕES PENDENTES</CardTitle>
                      <p />
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
              <hr />
                <div className="stats"> Dados Pessoais
                </div>
              </CardFooter>
            </Card>
          </Col>
          </Row>
          <Row>

          <Col lg="6" md="8" sm="8">
          <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="5">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-ambulance text-danger" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Consultas</p>
                      <CardTitle tag="p">CONSULTAS PENDENTES</CardTitle>
                      <p />
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
              <hr />
                <div className="stats">
                  <i className="far fa-calendar" /> Calendário
                </div>
              </CardFooter>
            </Card>
          </Col>

          <Col lg="6" md="8" sm="8">
          <Card className="card-stats">
              <CardBody>
                <Row>
                  <Col md="4" xs="6">
                    <div className="icon-big text-center icon-warning">
                      <i className="nc-icon nc-favourite-28 text-primary" />
                    </div>
                  </Col>
                  <Col md="8" xs="7">
                    <div className="numbers">
                      <p className="card-category">Exames</p>
                      <CardTitle tag="p">EXAMES PENDENTES</CardTitle>
                      <p />
                    </div>
                  </Col>
                </Row>
              </CardBody>
              <CardFooter>
              <hr />
                <div className="stats">
                  <i className="far fa-calendar" /> Calendário
                </div>
              </CardFooter>
            </Card>
          </Col>
        </Row>
        

      </div>
    </>
  );
}

export default Dashboard;