import http from "@/http-common";

/* eslint-disable */
class OrderStatusService {
  getAll() {
    return http.get("/api/order/get-all");
  }

  getById(id) {
    return http.get(`/api/order/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/order/add", data);
  }

  update(id, data) {
    return http.put(`/api/car/update?id=${id}`, data);
  }

  delete(id) {
    return http.delete(`/api/car/delete?id=${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }

  // deleteAll() {
  //   return http.delete(`/tutorials`);
  // }

  // findByTitle() {
  //   return http.get(`/tutorials?title=${title}`);
  // }
}
export default new OrderStatusService();
