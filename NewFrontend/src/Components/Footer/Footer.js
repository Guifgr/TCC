import React from "react";
import { Container, Row } from "reactstrap";
// used for making the prop types of this component
import PropTypes from "prop-types";

function Footer(props) {
  return (
    
    

    <footer className={"footer" + (props.default ? " footer-default" : "")}>
      <Container fluid={props.fluid ? true : false}>
        <Row>
            <div className="copyright">
              &copy; {1900 + new Date().getYear()}, Copyright UMC. Todos os direitos reservados.{" "}
              <i className="fa fa-solid fa-user" /> by Stark Solution
            </div>
        </Row>       
      </Container>
    </footer>
    
  );
}

Footer.propTypes = {
  default: PropTypes.bool,
  fluid: PropTypes.bool
};

export default Footer;
