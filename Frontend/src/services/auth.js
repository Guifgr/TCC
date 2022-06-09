export const TOKEN_KEY = '@tccToken'
export const isAuthenticated = () => localStorage.getItem(TOKEN_KEY) !== null
export const getToken = () => JSON.parse(localStorage.getItem(TOKEN_KEY))
export const login = token => {
  token = token.replace('"', "")
  localStorage.setItem(TOKEN_KEY, token)
}
export const logout = () => {
  localStorage.removeItem(TOKEN_KEY)
  window.location.href = '/'
}
