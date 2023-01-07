import http from "@/http-common";

class BidService {
  getAll() {
    return http.get("/api/category");
  }
  getById(idGa,idPd) {
    return http.get(`api/Bid/PriceDesc?galaryId=${idGa}&productId=${idPd}`)
  }
  getByIdBid(id) {
    return http.get(`api/Bid/${id}`)
  }
  create(data) {
    return http.post("api/category/", data);
  }
  delete(id) {
    return http.delete(`/api/category/${id}`);
  }
  update(id, data) {
    return http.put(`/api/category/${id}`, data);
  }
}
export default new BidService();
