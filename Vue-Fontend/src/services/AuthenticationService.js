import http from "../../http-common";

class AuthenticationService {
  login(user_name, password) {
    return http.post(`api/Authenticate/Login/${user_name, password}`);
  }

  register(user_name, email, password) {
    return http.post(`api/Authenticate/Register/${user_name, email, password}`);
  }
}
export default new AuthenticationService();
