const prod = {
    url: {
        route: "https://tccumcbacked.azurewebsites.net",
        Hub: "https://tccumcbacked.azurewebsites.net/hubs/TccHub",
    },
};
const dev = {
    url: {
        route: "https://localhost:7039",
        Hub: "https://localhost:7039/hubs/TccHub",
    },
};
export default process.env.NODE_ENV === "development" ? dev : prod;
