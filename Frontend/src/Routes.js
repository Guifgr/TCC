import Home from "views/Home";
import Professional from "views/Professional/Professional.js";
import UserPage from "views/AccountPatient/UpdatePatient";
import Contact from "views/Contact/Contact"
import Consulta from "views/Consultation/Consulta";
import Exams from "views/Exams/Exams";
import Finance from "views/Finance/Finance";
// import Login from "views/Login/loginIndex";


var routes = [
  {
    path: "/home",
    name: "Inicio",
    icon: "nc-icon nc-button-play",
    component: Home,
    layout: "/admin"
  },
   {
     path: "/consulta",
     name: "Consultas",
     icon: "nc-icon nc-single-copy-04",
     component: Consulta,
     layout: "/admin"
   },
   {
     path: "/exames",
     name: "Exames",
     icon: "nc-icon nc-touch-id",
     component: Exams,
     layout: "/admin"
   },
     {
     path: "/financeiro",
     name: "Financeiro",
     icon: "nc-icon nc-bank",
     component: Finance,
     layout: "/admin"
   },
   {
    path: "/notifications",
    name: "Professional",
    icon: "nc-icon nc-lock-circle-open",
    component: Professional,
    layout: "/admin"
  },
  {
    path: "/perfil",
    name: "Perfil",
    icon: "nc-icon nc-single-02",
    component: UserPage,
    layout: "/admin"
  },
  {
    path: "/contact",
    name: "Fale com a gente",
    icon: "nc-icon nc-email-85",
    component: Contact,
    layout: "/admin"
  },


  // {
  //   pro: true,
  //   path: "/loginIndex",
  //   name: "Sair",
  //   icon: "nc-icon nc-button-power",
  //   component: Login,
  //   layout: "/admin"
  // }
];
export default routes;
