import http from "@/http-common";

class ProductService {
  delete(id) {
    return http.delete(`/api/product/${id}`);
  }
  getAll() {
    return http.get("api/product");
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
  create(data) {
    return http.post("api/product/", data);
  }
  update(data) {
    return http.put("/api/product/", data);
  }
}
export default new ProductService();
