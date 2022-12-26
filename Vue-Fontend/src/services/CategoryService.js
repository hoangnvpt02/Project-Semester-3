import http from "../../http-common";

class CategoryService {
  getAll() {
    return http.get("/api/category");
  }
}
export default new CategoryService();
