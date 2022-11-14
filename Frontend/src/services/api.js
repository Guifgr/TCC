import axios from 'axios'
import { getToken, logout } from './auth'
import config from '../Constants'

export const hub = config.url.Hub

const api = axios.create({
  baseURL: config.url.route,
})

api.interceptors.request.use(async config => {
  const token = getToken()
  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

api.interceptors.response.use(
  function (response) {
    return response
  },
  function (error) {
    // if (error.message === 'Request failed with status code 401') logout()
    return Promise.reject(error)
  },
)

export default api
