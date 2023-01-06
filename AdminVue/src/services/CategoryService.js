import http from "@/http-common";

class CategoryService {
  getAll() {
    return http.get("/api/category");
  }
  getById(id) {
    return http.get(`api/category/${id}`)
  }
  create(data) {
    return http.post("api/category/", data);
  }
  delete(id) {
    return http.delete(`/api/category/${id}`);
  }
  update(id, data) {
    return http.put(`/api/category/${id}`, data);
  }
}
export default new CategoryService();
