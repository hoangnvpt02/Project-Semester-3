import http from "../../http-common";

class BidService {
  getProductByGalary(id) { 
    return http.get(`ProductByGaId/?galaryId=${id}`);
  }
  getAll() {
    return http.get("api/Bid");
  }
  create(data) {
    return http.post("/api/Bid/", data);
  }
  
}
export default new BidService();
