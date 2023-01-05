import http from "@/http-common";

class ProductCate {
  getAll() {
    return http.get("/api/category");
  }
  getById(id) {
    return http.get(`api/category/${id}`)
  }
  create(data) {
    return http.post("api/ProductCate/", data);
  }
}
export default new ProductCate();
