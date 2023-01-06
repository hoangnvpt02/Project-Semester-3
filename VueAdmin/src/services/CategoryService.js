import http from "../../http-common";
import authHeader from './auth-header';

/* eslint-disable */
class CategoryService {
  getAll() {
    return http.get("/api/Category/", { headers: authHeader() });
  }

  UpdateStatus(id, status) {
    return http.get(`/api/Category/UpdateStatus/${id}/${status}`, data, { headers: authHeader() });
  }

  delete(id) {
    return http.delete(`/api/Category/${id}`);
  }
}
export default new CategoryService();
