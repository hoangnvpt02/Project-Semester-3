import http from "@/http-common";

/* eslint-disable */
class MedicineService {
  getAll() {
    return http.get("/api/medicines");
  }
  countAll() {
    return http.get("api/medicines/count-all");
  }
  getById(id) {
    return http.get(`/api/medicines/${id}`);
  }

  create(data) {
    return http.post("/api/medicines", data);
  }

  update(id, data) {
    return http.put(`/api/medicines/${id}`, data);
  }

  delete(id) {
    return http.delete(`/api/medicines/${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }

}
export default new MedicineService();
