import http from "@/http-common";

/* eslint-disable */
class FacilityService {
  getAll() {
    return http.get("/api/facility");
  }
  countAll() {
    return http.get("api/facility/count-all");
  }
  getById(id) {
    return http.get(`/api/facility/getById/${id}`);
  }

  create(data) {
    return http.post("/api/facility/add", data);
  }

  update(id, data) {
    return http.put(`/api/facility/update?id=${id}`, data);
  }

  delete(id) {
    return http.delete(`/api/facility/delete?id=${id}`);
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
export default new FacilityService();
