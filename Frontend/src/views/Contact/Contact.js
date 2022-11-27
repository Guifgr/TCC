import React from "react";

// reactstrap components
import {
  Button,
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Table,
  Row,
  Col
} from "reactstrap";

function Upgrade() {
  return (
    <>
      <div className="content">
        <Row>
          <Col className="ml-auto mr-auto" md="8">
            <Card className="card-upgrade">
              <CardHeader className="text-center">
                <CardTitle tag="h4">Nos contate!</CardTitle>
                <p className="card-category">
                  Está com problemas no seu agendamento ou prefere agendar pelo telefone?
                  Aqui estão nossos contatos:
                </p>

                <Col lg="6" md="8" sm="8">
                  <Card className="card-stats">
                    <CardBody>
                      <Row>
                        <Col md="4" xs="5">
                          <div className="icon-big text-center icon-warning">
                          <i className="fa-brands fa-whatsapp"></i>
                          </div>
                        </Col>
                      </Row>
                    </CardBody>
                  </Card>
                </Col>

                <Col lg="6" md="8" sm="8">
                  <Card className="card-stats">
                    <CardBody>
                      <Row>
                        <Col md="4" xs="5">
                          <div className="icon-big text-center icon-warning">
                          <i className="fa-brands fa-youtube"></i>
                          </div>
                        </Col>
                      </Row>
                    </CardBody>
                  </Card>
                </Col>

                <Col lg="6" md="8" sm="8">
                  <Card className="card-stats">
                    <CardBody>
                      <Row>
                        <Col md="4" xs="5">
                          <div className="icon-big text-center icon-warning">
                          <i class="fa-brands fa-instagram"></i>
                          </div>
                        </Col>
                      </Row>
                    </CardBody>
                  </Card>
                </Col>

              </CardHeader>
              <CardBody>

              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    </>
  );
}

export default Upgrade;
