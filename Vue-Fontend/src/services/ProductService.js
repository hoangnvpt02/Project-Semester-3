import http from "../../http-common";

class ProductService {
  getAll() {
    return http.get("api/product");
  }
  get15First() {
    return http.get("api/product/?start=0&end=15");
  }
  getAllByFeature() {
    return http.get("api/product/feature");
  }
  getAllBySale() {
    return http.get("api/product/sale");
  }
  getById(id) {
    return http.get(`api/product/${id}`)
  }
  getAllProductByCate(id) {
    return http.get(`api/product/CategoryId?CategoryId=${id}`)
  }
}
export default new ProductService();
