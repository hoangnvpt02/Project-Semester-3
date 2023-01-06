import http from "../../http-common";

class GalaryService {
  getProductByGalary(id) { 
    return http.get(`ProductByGaId/?galaryId=${id}`);
  }
  getAll() {
    return http.get("api/Galary");
  }

}
export default new GalaryService();
