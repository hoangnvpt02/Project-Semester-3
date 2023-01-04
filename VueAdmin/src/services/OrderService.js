import http from "../../http-common";
import authHeader from './auth-header';

/* eslint-disable */
class OrderService {
  getAll() {
    return http.get("/api/order/", { headers: authHeader() });
  }

  getById(id) {
    return http.get(`/api/order/${id}`, { headers: authHeader() });
  }

  updateOrderStatus(id, status) {
    return http.get(`/api/order/UpdateStatus/${id}/${status}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/order/${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }
}
export default new OrderService();
