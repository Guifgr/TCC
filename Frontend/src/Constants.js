const prod = {
  url: {
    route: 'http://10.0.0.33/Sync.TCE.API/scgas-tce-sync/api/v1/',
    Hub: 'http://10.0.0.33/Sync.TCE.API/hubs/ScGasHub',
  },
}
const dev = {
  url: {
    route: 'http://localhost:55587/scgas-tce-sync/api/v1/',
    Hub: 'http://localhost:55587/hubs/ScGasHub',
  },
}
export default process.env.NODE_ENV === 'development' ? dev : prod
