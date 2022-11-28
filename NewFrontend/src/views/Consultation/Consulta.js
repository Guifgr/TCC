import React from "react";
import ListConsultaPatient from "./ConsultaPatient";
import ListConsultAdm from "./ConsultaAdm";

function Consulta() {
  return (
    <>
      <div className="content">

        <ListConsultaPatient />

        <ListConsultAdm />
      </div>
    </>
  );
}

export default Consulta;
