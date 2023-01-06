import http from "@/http-common";

/* eslint-disable */
class DoctorService {
  getAll() {
    return http.get("api/doctor/get-all");
  }
  countAll() {
    return http.get("api/doctor/count-all");
  }

  getById(id) {
    return http.get(`/api/doctor/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/doctor/add", data);
  }

  update(id, data) {
    return http.put(`/api/doctor/update?id=${id}`, data);
  }

  delete(id) {
    return http.delete(`/api/doctor/delete?id=${id}`);
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
export default new DoctorService();
