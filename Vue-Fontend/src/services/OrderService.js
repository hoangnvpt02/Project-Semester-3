import http from "../../http-common";

class ProductService {
  GetQuantityOrder() {
    return http.get("/api/Order/GetQuantityOrder");
  }
  getAllData() {
    return http.get("/api/Order");
  }
  delete(id) {
    return http.delete(`/api/Order/${id}`);
  }
}
export default new ProductService();
