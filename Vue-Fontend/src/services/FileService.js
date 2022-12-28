import http from "../../http-common";

class FileService {
  getFile(id) {
    return http.get(`/api/files/${id}`);
  }
}
export default new FileService();
