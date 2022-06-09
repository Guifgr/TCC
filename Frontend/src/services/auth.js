export const TOKEN_KEY = '@tccToken'
export const isAuthenticated = () => localStorage.getItem(TOKEN_KEY) !== null
export const getToken = () => JSON.parse(localStorage.getItem(TOKEN_KEY)).token
export const getWasPostRegistered = () => JSON.parse(localStorage.getItem(TOKEN_KEY)).wasPostRegistered
export const getPermissionLevel = () => JSON.parse(localStorage.getItem(TOKEN_KEY)).permissionLevel
export const getExpirationDate = () => JSON.parse(localStorage.getItem(TOKEN_KEY)).expirationDate
export const getUserName = () => JSON.parse(localStorage.getItem(TOKEN_KEY)).userName

export const login = token => {
  token = token.replace('"', "")
  localStorage.setItem(TOKEN_KEY, token)
}
export const logout = () => {
  localStorage.removeItem(TOKEN_KEY)
  window.location.href = '/'
}
