import http from "@/http-common";

/* eslint-disable */
class FacilityService {
  getAll() {
    return http.get("/api/specialist/get-all");
  }
  countAll() {
    return http.get("api/specialist/count-all");
  }
  getById(id) {
    return http.get(`/api/specialist/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/specialist/add", data);
  }

  update(id, data) {
    return http.put(`/api/specialist/update?id=${id}`, data);
  }

  delete(id) {
    return http.delete(`/api/specialist/delete?id=${id}`);
  }
  uploadMainImage(file){
    return http.post("/api/uploadFile");
  }

}
export default new FacilityService();
