import http from "@/http-common";

/* eslint-disable */
class CarImageService {
  getAll() {
    return http.get("/api/car-images/get-all");
  }
  getById(id) {
    return http.get(`/api/car-images/get-by-id/${id}`);
  }
}
export default new CarImageService();
