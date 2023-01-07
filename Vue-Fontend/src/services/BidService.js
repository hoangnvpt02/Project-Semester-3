import http from "../../http-common";

class BidService {
  getProductByGalary(id) { 
    return http.get(`ProductByGaId/?galaryId=${id}`);
  }
  getAll() {
    return http.get("api/Bid");
  }
  getById(idGa,idPd) {
    return http.get(`api/Bid/PriceDesc?galaryId=${idGa}&productId=${idPd}`)
  }
  create(data) {
    return http.post("/api/Bid/", data);
  }
  
}
export default new BidService();
