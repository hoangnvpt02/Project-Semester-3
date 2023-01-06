import axios from "axios";

const API_URL = "https://localhost:5001/api/Authenticate/";

class AuthService {
  login(user) {
    return axios
      .post(API_URL + "loginAdmin", {
        username: user.username,
        password: user.password,
      })
      .then((response) => {
        if (response.data.token) {
          localStorage.setItem("admin", JSON.stringify(response.data));
        }

        return response.data;
      })
      .catch(() => {
        alert("Username or password is correct");
      });
  }

  logout() {
    localStorage.removeItem("admin");
  }

  register(user) {
    return axios.post(API_URL + "registerAdmin", {
      username: user.username,
      email: user.email,
      password: user.password,
    });
  }
}

export default new AuthService();
