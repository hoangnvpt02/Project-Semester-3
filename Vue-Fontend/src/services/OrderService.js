import http from "../../http-common";

class ProductService {
  GetQuantityOrder() {
    return http.get("/api/Order/GetQuantityOrder");
  }
  create(data) {
    return http.post("/api/Order/", data);
  }
  getAllData() {
    return http.get("/api/Order");
  }
  delete(id) {
    return http.delete(`/api/Order/${id}`);
  }
  updateStatus(id, status) {
    return http.get(`/api/Order/UpdateStatus/${id}/${status}`);
  }
}
export default new ProductService();
