import React, { useContext } from "react";
import ListConsultaPatient from "./ConsultaPatient";
import ListConsultAdm from "./ConsultaAdm";
import UserContext from "../../context/userContext";
import Logo from '../../assets/img/logo-c-nome.svg'
import { useNavigate } from 'react-router-dom';

function Consulta() {
  const context = useContext(UserContext);
  const [userInfo] = context.state;
  const navigate = useNavigate();

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
    <div style={{ display: 'flex', flexDirection: 'row', width: '100%', height: '100%' }}>
      <div style={{ height: '100%', width: '20%', background: "#04cfd1", borderTopRightRadius: 10, borderBottomRightRadius: 10, padding: 25 }}>
        <img src={Logo} alt="Logo" style={{ width: '75%' }} />
        <hr />

        <div style={{ width: "100%", marginLeft: 25, height: '82%' }}>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/')}>
            INICIO
          </p>
          <h1 style={{ marginBottom: '5%', cursor: 'pointer' }} onClick={() => navigate('/consulta')}>
            CONSULTAS
          </h1>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/exame')}>
            EXAMES
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/financeiro')}>
            FINANCEIRO
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'not-allowed' }}>
            PROFISSIONAL
          </p>
          <p style={{ marginBottom: '5%', fontSize: 24, cursor: 'pointer' }} onClick={() => navigate('/perfil')}>
            PERFIL
          </p>
        </div>
        <hr />
        <p style={{ marginBottom: '5%', fontSize: 32, marginLeft: 25, cursor: 'pointer' }} onClick={() => {
          context.logout();
          navigate('/login')
          }}>
          SAIR
        </p>
      </div>
      <div className="content" style={{ width: '80%', padding: 10 }}>
        {userInfo.permissionLevel === 'User' ? <ListConsultaPatient translateConsultStatus={translateConsultStatus} translatePaymentStatus={translatePaymentStatus} />
          : <ListConsultAdm translateConsultStatus={translateConsultStatus} translatePaymentStatus={translatePaymentStatus} />}
      </div>
    </div>
  );
}

export default Consulta;
