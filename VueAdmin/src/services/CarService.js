import http from "@/http-common";
import authHeader from './auth-header';

/* eslint-disable */
class CarService {
  getAll() {
    return http.get("/api/car/get-all");
  }

  getById(id) {
    return http.get(`/api/car/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/car/add", data, { headers: authHeader() });
  }

  update(id, data) {
    return http.put(`/api/car/update?id=${id}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/car/delete?id=${id}`, { headers: authHeader() });
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile", { headers: authHeader() });
  }
}
export default new CarService();
