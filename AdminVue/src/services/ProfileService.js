import http from "@/http-common";

/* eslint-disable */
class ProfileService {
  getAll() {
    return http.get("api/users");
  }

  getById(id) {
    return http.get(`/api/car/get-by-id/${id}`);
  }

  create(data) {
    return http.post("/api/car/add", data);
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
export default new ProfileService();
