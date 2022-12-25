import http from "../../http-common";

class ProductService {
  getAll() {
    return http.get("/api/product");
  }
}
export default new ProductService();
