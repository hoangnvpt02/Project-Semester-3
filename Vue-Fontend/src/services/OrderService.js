import http from "../../http-common";

class ProductService {
  GetQuantityOrder(userId) {
    return http.get(`/api/Order/GetQuantityOrder?userId=${userId}`);
  }
  create(data) {
    return http.post("/api/Order/", data);
  }
  getAllData(userId, status = 0) {
    return http.get(`/api/Order?userId=${userId}&status=${status}`);
  }
  delete(id) {
    return http.delete(`/api/Order/${id}`);
  }
  updateStatus(id, status, email = null, address = null) {
    return http.get(`/api/Order/UpdateStatus/${id}/${status}?email=${email}&address=${address}`);
  }
}
export default new ProductService();
