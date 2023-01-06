<!-- eslint-disable vue/multi-word-component-names -->
<template lang="">
<div>
    <Header></Header>
    <div class="container mt-5 mb-5" v-if="!show_payment">
        <div style="display: flex; justify-content: center;">
            <div class="col-md-8" style="background: #efefef;padding: 17px;border-radius: 3px; margin: 10px 20px 20px 30px;">
                <div class="p-2">
                    <h4>Shopping cart</h4>
                </div>
                <div v-for="(order, index) in list_order" :key="index" class="d-flex flex-row justify-content-between align-items-center p-2 bg-white mt-4 p-3 rounded item-list-order">
                    <div class="flex items-center">
                        <input @change="changeProductPaymentProcessing(index)" id="checkbox-1" type="checkbox" value="" class="w-4 h-4 text-blue-600 bg-gray-100 rounded border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                    </div>
                    <div><img class="rounded" :src="order.fileDetailsId" width="50" height="40" style="border-radius: 10px"></div>
                    <!-- <div class="mr-1"><img class="rounded" :src="baseUrl +  + order.fileDetailsId" width="50" height="40"></div> -->
                    <div class="d-flex flex-column align-items-center product-details">
                        <span class="font-weight-bold">{{ order.name.substr(0, 18) + "..." }}</span>
                    </div>
                    <div>
                        <h5 class="text-grey" style="margin: 0px;">{{ formatMoney(order.price) }}</h5>
                    </div>
                    <div class="d-flex align-items-center" @click="deleteOrder(order.id)" style="cursor: pointer;">
                        <i class="fa fa-trash mb-1"></i>
                    </div>
                </div>
                <div class="d-flex flex-row align-items-center mt-3 p-2 bg-white rounded" style="margin-top: 15px">
                    <button class="btn btn-block btn-lg ml-2 btn-order" type="button" @click="show_payment = !show_payment">Tiến hành đặt hàng</button>
                </div>
            </div>
        </div>
    </div>
    <div v-else>
        <payment :list_product_payment_processing="list_product_payment_processing"></payment>
    </div>
    <Footer></Footer>
</div>
</template>

<script>
import Header from './Header.vue'
import Footer from './Footer.vue'
import OrderService from '@/services/OrderService';
import base from "@/../base.json"
import payment from "./Payment.vue";

export default {
    data() {
        return {
            list_order: [{
                    id: 1,
                    fileDetailsId: "https://s3.cloud.cmctelecom.vn/tinhte1/2014/11/2631443_despicable_me_2_minions-1920x1080_VVVaaa.png",
                    name: "Do co 1000 nam tuoi",
                    price: 10000000,
                },
                {
                    id: 30,
                    fileDetailsId: "https://imgs.vietnamnet.vn/Images/2017/03/19/10/20170319101545-co-vat-2.jpg",
                    name: "Bat co 100 nam tuoi",
                    price: 20000000,
                },
                {
                    id: 32,
                    fileDetailsId: "https://imgs.vietnamnet.vn/Images/2017/03/19/10/20170319101545-co-vat-2.jpg",
                    name: "Chau da co 1000 nam tuoi",
                    price: 30000000,
                }
            ],
            list_product_payment_processing: [],
            baseUrl: "",
            base,
            show_payment: false,
        }
    },
    components: {
        Header,
        Footer,
        payment
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
        },
        changeProductPaymentProcessing(index) {
            this.list_product_payment_processing.push(this.list_order[index]);
        },
        formatMoney(n) {
            return n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
        }
    },
    created() {
        this.baseUrl = this.base.baseUrl + 'api/files/'
        this.getAllData();
    },
}
</script>

<style scoped>
@import "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css";
.item-list-order {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 11px 25px 11px 25px;
    text-align: center;
    background: white;
    border-radius: 9px;
    margin-top: 15px;
    font-size: 14px;
}

.btn-order {
    border-radius: 10px;
    font-size: 13px; 
    background-color: #d1c286; 
    color: white
}

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
