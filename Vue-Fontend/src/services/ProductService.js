import http from "../../http-common";

class ProductService {
  getAll() {
    return http.get("api/product");
  }
  getById(id) {
    return http.get(`api/product/${id}`)
  }
  getAllProductByCate(id) {
    return http.get(`api/product/CategoryId?CategoryId=${id}`)
  }
}
export default new ProductService();
