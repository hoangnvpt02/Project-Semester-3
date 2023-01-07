import http from "@/http-common";

class ProductGalaryService {
  getAll() {
    return http.get("/api/Galary");
  }
  getById(id) {
    return http.get(`api/category/${id}`)
  }
  create(data) {
    return http.post("api/ProductGalary/", data);
  }
  delete(id) {
    return http.delete(`/api/category/${id}`);
  }
  update(id, data) {
    return http.put(`/api/category/${id}`, data);
  }
}
export default new ProductGalaryService();
