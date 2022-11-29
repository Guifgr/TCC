const prod = {
    url: {
        route: "https://tccumcbacked.azurewebsites.net",
        Hub: "https://tccumcbacked.azurewebsites.net/hubs/TccHub",
    },
};
const dev = {
    url: {
        route: "https://cyan-dryers-lick-200-171-134-45.loca.lt/",
        Hub: "https://cyan-dryers-lick-200-171-134-45.loca.lt/hubs/TccHub",
    },
};

export const routes = [
    { path: '/login', name: 'Login' },
    { path: '/redefinir-senha', name: 'Redefinir senha' },
    { path: '/definir-senha', name: 'Definir Senha' },
    { path: '/criar-conta', name: 'Criar Conta' },
    { path: '/validar-conta', name: 'Validar Conta' },
    { path: '/consulta', name: 'Consulta' },
    { path: '/exames', name: 'Exame' },
    { path: '/financeiro', name: 'Financeiro' },
    { path: '/professional', name: 'Professional' },
    { path: '/perfil', name: 'Perfil' },
    { path: '/contact', name: 'Contato' }

]

export default process.env.NODE_ENV === "development" ? dev : prod;
