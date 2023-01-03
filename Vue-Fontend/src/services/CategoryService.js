import http from "../../http-common";

class CategoryService {
  getAll() {
    return http.get("/api/category");
  }
  getById(id) {
    return http.get(`api/category/${id}`)
  }
}
export default new CategoryService();
