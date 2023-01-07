import http from "../http-common";

class AuthenticationService {
  login(form) {
    return http.post(`api/Authenticate/LoginAdmin`, form);
  }
  
  logout() {
    localStorage.removeItem('admin');
  }
}
export default new AuthenticationService();
