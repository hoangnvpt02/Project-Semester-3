import http from "../../http-common";

class OrderService {
  GetQuantityOrder(userId) {
    return http.get(`/api/Order/GetQuantityOrder?userId=${userId}`);
  }
  create(data) {
    return http.post("/api/Order/", data);
  }
  getAllData(userId = "Empty", status = 1) {
    return http.get(`/api/Order?userId=${userId}&status=${status}`);
  }
  delete(id) {
    return http.delete(`/api/Order/${id}`);
  }
  updateStatus(id, status, email = null, address = null) {
    return http.get(`/api/Order/UpdateStatus/${id}/${status}?email=${email}&address=${address}`);
  }
}
export default new OrderService();
