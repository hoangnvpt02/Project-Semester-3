import http from "../../http-common";

class ProductService {
  GetQuantityOrder() {
    return http.get("/api/Order/GetQuantityOrder");
  }
}
export default new ProductService();
