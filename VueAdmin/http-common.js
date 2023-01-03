import axios from "axios";
import base from "@/../base.json"
export default axios.create({
  baseURL: base.baseUrl,
  headers: {
    "Content-type": "application/json"
  }
});
