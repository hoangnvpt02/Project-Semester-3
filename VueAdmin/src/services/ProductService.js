import http from "../../http-common";
import authHeader from './auth-header';

/* eslint-disable */
class ProductService {
  getAll() {
    return http.get("/api/Product/", { headers: authHeader() });
  }

  getById(id) {
    return http.get(`/api/Product/${id}`, { headers: authHeader() });
  }

  updateStatus(id, status) {
    return http.get(`/api/Product/UpdateStatus/${id}/${status}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/Product/${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }
}
export default new ProductService();
