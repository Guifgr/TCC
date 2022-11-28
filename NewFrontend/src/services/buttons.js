import api from './api'

class BtnData {
  constructor(text, link) {
    this.text = text
    this.link = link
  }
}


export const getButtons = async (ambiente, isProduction) => {
  const buttonsData = []
  await api.get(`getclaims?isProduction=${isProduction}`).then(res => {
    let claimData = res.data.response
    
    for (let i = 0; i < claimData.length; i++) {
     
      if(claimData[i].HasAccess === true){  
        let btnText = claimData[i].Module
        buttonsData.push(
          new BtnData(
            btnText.replace(/([A-Z])/g, ' $1').trim(),
            ambiente + `enviar${btnText}`
          )
        )
      
      }
  }
  })

  return buttonsData
}
