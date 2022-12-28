import http from "@/http-common";
import authHeader from './auth-header';

/* eslint-disable */
class OrderService {
  getAll() {
    return http.get("/api/order/get-all", { headers: authHeader() });
  }

  getById(id) {
    return http.get(`/api/order/get-by-id/${id}`, { headers: authHeader() });
  }

  create(data) {
    return http.post("/api/order/add", data, { headers: authHeader() });
  }

  updateOrderStatus(id, data) {
    return http.put(`/api/order/update-status?id=${id}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/car/delete?id=${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }
}
export default new OrderService();
