<!-- eslint-disable vue/multi-word-component-names -->
<template lang="">
<div>
    <Header></Header>
    <div class="container mt-5 mb-5">
        <div class="d-flex justify-content-center row">
            <div class="col-md-8" style="background: #efefef;padding: 17px;border-radius: 3px;">
                <div class="p-2">
                    <h4>Shopping cart</h4>
                    <div class="d-flex flex-row align-items-center pull-right"><span class="mr-1">Sort by:</span><span class="mr-1 font-weight-bold">Price</span><i class="fa fa-angle-down"></i></div>
                </div>
                <div v-for="(order, index) in list_order" :key="index" class="d-flex flex-row justify-content-between align-items-center p-2 bg-white mt-4 p-3 rounded">
                    <div class="mr-1"><img class="rounded" :src="baseUrl +  + order.fileDetailsId" width="100"></div>
                    <div class="d-flex flex-column align-items-center product-details"><span class="font-weight-bold">{{ order.name }}</span>
                    </div>
                    <div>
                        <h5 class="text-grey">{{ order.price }}</h5>
                    </div>
                    <div class="d-flex align-items-center" @click="deleteOrder(order.id)" style="cursor: pointer;"><i class="fa fa-trash mb-1 text-danger"></i></div>
                </div>
                <div class="d-flex flex-row align-items-center mt-3 p-2 bg-white rounded"><input type="text" class="form-control border-0 gift-card" placeholder="discount code/gift card"><button class="btn btn-outline-warning btn-sm ml-2" type="button">Apply</button></div>
                <div class="d-flex flex-row align-items-center mt-3 p-2 bg-white rounded"><button class="btn btn-warning btn-block btn-lg ml-2 pay-button" type="button">Proceed to Pay</button></div>
            </div>
        </div>
    </div>
    <Footer></Footer>
</div>
</template>

<script>
import Header from './Header.vue'
import Footer from './Footer.vue'
import OrderService from '@/services/OrderService';
import base from "@/../base.json"

export default {
    data() {
        return {
            list_order: [],
            baseUrl: "",
            base,
        }
    },
    components: {
        Header,
        Footer
    },
    methods: {
        getAllData() {
            OrderService.getAllData()
            .then((response) => {
                this.list_order = response.data;
            });
        },
        deleteOrder(id) {
          OrderService.delete(id)
          .then(() => {
              this.getAllData();
          });
        }
    },
    created() {
      this.baseUrl = this.base.baseUrl + 'api/files/'
      this.getAllData();
    },
}
</script>

<style>
/* @import "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css";
@import "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js";
@import "https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js";
@import "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"; */

.size span {
    font-size: 11px;
}

.color span {
    font-size: 11px;
}

.product-deta {
    margin-right: 70px;
}

.gift-card:focus {
    box-shadow: none;
}

.pay-button {
    color: #fff;
}

.pay-button:hover {
    color: #fff;
}

.pay-button:focus {
    color: #fff;
    box-shadow: none;
}

.text-grey {
    color: #a39f9f;
}

.qty i {
    font-size: 11px;
}
</style>
