<!-- eslint-disable vue/multi-word-component-names -->
<template lang="">
<div>
    <Header></Header>
    <div class="container mt-5 mb-5" v-if="!show_payment && !show_order_peding">
        <div style="display: flex; justify-content: center;">
            <div class="col-md-8" style="background: #efefef;padding: 17px;border-radius: 3px; margin: 10px 20px 20px 30px;">
                <div class="p-2" style="display: flex; justify-content: space-between; align-items: center;">
                    <h4 style="margin: 0px">Shopping cart</h4>
                    <button class="btn-order_pending" type="button" @click="show_order_peding = !show_order_peding">Order pending</button>
                </div>
                <div v-for="(order, index) in list_order" :key="index" class="d-flex flex-row justify-content-between align-items-center p-2 bg-white mt-4 p-3 rounded item-list-order">
                    <div class="flex items-center">
                        <input @change="changeProductPaymentProcessing(index)" id="checkbox-1" type="checkbox" value="" class="w-4 h-4 text-blue-600 bg-gray-100 rounded border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                    </div>
                    <!-- <div><img class="rounded" :src="order.fileDetailsId" width="50" height="40" style="border-radius: 10px"></div> -->
                    <div class="mr-1"><img class="rounded" :src="baseUrl +  + order.fileDetailsId" width="50" height="40"></div>
                    <div class="d-flex flex-column align-items-center product-details">
                        <span class="font-weight-bold">{{ order.name.substr(0, 18) + "..." }}</span>
                    </div>
                    <div>
                        <h5 class="text-grey" style="margin: 0px;">{{ formatMoney(order.totalPrice) }}</h5>
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
    <div class="container mt-5 mb-5" v-if="show_order_peding">
        <pending :show_payment="show_payment"></pending>
    </div>
    <div v-if="show_payment">
        <payment :list_product_payment_processing="list_product_payment_processing" :show_order_peding="show_order_peding"></payment>
    </div>
    <Footer></Footer>
</div>
</template>

<script>
import Header from '../Header.vue'
import Footer from '../Footer.vue'
import OrderService from '@/services/OrderService';
import base from "@/../base.json"
import payment from "./Payment.vue";
import pending from "./Pending.vue";

export default {
    data() {
        return {
            list_order: [],
            list_product_payment_processing: [],
            baseUrl: "",
            base,
            show_payment: false,
            show_order_peding: false,
            user: JSON.parse(localStorage.getItem('user'))
        }
    },
    components: {
        Header,
        Footer,
        payment,
        pending,
    },
    methods: {
        getAllData() {
            let userId = null;
            if (this.user != null) {
                userId = this.user.id;
            }

            OrderService.getAllData(userId)
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
@import "http://fonts.googleapis.com/css?family=Lato:400,700";

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

.btn-status {
    padding: 5px 11px 5px 11px;
    border-radius: 20px;
    font-size: 11px;
    color: white;
    border: white;
    font-family: lato;
}

.btn-order_pending {
    background: #17a2b8;
    padding: 8px 20px 8px 20px;
    color: white;
    font-size: 10px;
    border: white;
    border-radius: 8px;
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
