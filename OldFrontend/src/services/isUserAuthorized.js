import api from './api'

export const isUserAuthorized = (url, isProd) => {

  api.get(`getclaims?isProduction=${isProd}`).then((res) => {

    let claimData = res.data.response
    let isIncludeArray = []

    for (let i = 0; i < claimData.length; i++) {

      if (claimData[i].HasAccess === true) {
        let btnText = claimData[i].Module
        isIncludeArray.push(btnText)

      }
    }

    if (isIncludeArray.includes(url) === false) {
      window.location.href = '/#/#/servicos'
    }

  }).catch((err) => {
    console.log('ERRO GET CLAIMS REQUISICAO', err)
  })

}