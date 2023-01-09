import http from "@/http-common";

class BidService {
  getById(idGa,idPd) {
    return http.get(`api/Bid/PriceDesc?galaryId=${idGa}&productId=${idPd}`)
  }
  getByIdBid(id) {
    return http.get(`api/Bid/${id}`)
  }
}
export default new BidService();
