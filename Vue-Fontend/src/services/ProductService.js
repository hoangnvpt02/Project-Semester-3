import http from "@/http-common";
import authHeader from './auth-header';

/* eslint-disable */
class ProductService {
  getAll() {
    return http.get("/api/product/get-all");
  }

  getById(id) {
    return http.get(`/api/product/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/product/add", data, { headers: authHeader() });
  }

  update(id, data) {
    return http.put(`/api/product/update?id=${id}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/product/delete?id=${id}`, { headers: authHeader() });
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile", { headers: authHeader() });
  }
}
export default new ProductService();
