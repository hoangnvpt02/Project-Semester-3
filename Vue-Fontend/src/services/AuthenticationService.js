import http from "../../http-common";

class AuthenticationService {
  login(form) {
    return http.post(`api/Authenticate/Login`, form);
  }

  register(form) {
    return http.post(`api/Authenticate/Register`, form);
  }

  logout() {
    localStorage.removeItem('user');
  }
}
export default new AuthenticationService();
