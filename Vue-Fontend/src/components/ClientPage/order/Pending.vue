<!-- eslint-disable vue/multi-word-component-names -->
<template lang="">
<div>
    <div style="display: flex; justify-content: center;">
        <div class="col-md-8" style="background: #efefef;padding: 17px;border-radius: 3px; margin: 10px 20px 20px 30px;">
            <div class="p-2">
                <h4>Orders are pending</h4>
            </div>
            <div v-for="(order, index) in list_order" :key="index" class="d-flex flex-row justify-content-between align-items-center p-2 bg-white mt-4 p-3 rounded item-list-order">
                <div class="mr-1"><img class="rounded" :src="baseUrl +  + order.fileDetailsId" width="50" height="40" style="border-radius: 9px;"></div>
                <div class="d-flex flex-column align-items-center product-details">
                    <span class="font-weight-bold">{{ order.name.substr(0, 18) + "..." }}</span>
                </div>
                <div>
                    <h5 class="text-grey" style="margin: 0px;">{{ formatMoney(order.totalPrice) }}</h5>
                </div>
                <button class="btn-status" style="background: #17a2b8;" v-if="order.status == 1" @click="updateStatus(order.id, 2, index)">Chờ xác nhận</button>
                <button class="btn-status" style="background: #ffc107;" v-if="order.status == 2" @click="updateStatus(order.id, 2, index)">Chờ lấy hàng</button>
                <button class="btn-status" style="background: #28a745;" v-if="order.status == 3" @click="updateStatus(order.id, 2, index)">Đã thanh đoán</button>
            </div>
            <div class="col-md-12" style="padding: 0px;margin-top: 10px;">
                <a href="/cart" class="btn btn-block btn-lg ml-2 btn-payment" style="background: #dc3545; margin-right: 11px; color: white; border-radius: 5px" type="button">
                    Trở lại
                </a>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import OrderService from '@/services/OrderService';
import base from "@/../base.json"

export default {
    props: {
        show_order_peding: {
            type: Boolean,
        }
    },
    data() {
        return {
            list_order: [],
            baseUrl: "",
            base,
        }
    },
    methods: {
        getAllData() {
            OrderService.getAllData()
                .then((response) => {
                    this.list_order = response.data;
                    console.log(response.data);
                });
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
