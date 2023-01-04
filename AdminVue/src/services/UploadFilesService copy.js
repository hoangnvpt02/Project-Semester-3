import http from "@/http-common";
class UploadFilesService {
  upload(id,file) {
    let formData = new FormData();
    formData.append("file", file);
    return http.post(`/api/uploadFile/${id}`, formData, {
      headers: {
        "Content-Type": "multipart/form-data"
      },
    });
  }
  getFiles() {
    return http.get("/api/downloadFile");
  }
}
export default new UploadFilesService();