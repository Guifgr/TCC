import React, { useContext } from "react";
import ListConsultaPatient from "./ConsultaPatient";
import ListConsultAdm from "./ConsultaAdm";
import UserContext from "../../context/userContext";

function Consulta() {
  const [userInfo] = useContext(UserContext).state;
  const translatePaymentStatus = (status) => {
    switch (status) {
        case 'Open':
          return 'Aberto';
        case 'Paid':
          return 'Pago';
        case 'Pendency':
          return 'Pendente';
        default:
          return '?';
    }
  }

  const translateConsultStatus = (status) => {
    switch (status) {
      case 'Open':
        return 'Aberto';
      case 'Closed':
        return 'Fechado';
      case 'Canceled':
        return 'Cancelado';
      default:
        return '?';
    }
  }
  return (
    <>
      <div className="content">
        { userInfo.permissionLevel === 'User' ? <ListConsultaPatient translateConsultStatus={translateConsultStatus} translatePaymentStatus={translatePaymentStatus}/>
        : <ListConsultAdm translateConsultStatus={translateConsultStatus} translatePaymentStatus={translatePaymentStatus}/>}
      </div>
    </>
  );
}

export default Consulta;
