<!-- eslint-disable vue/multi-word-component-names -->
<template lang="">
<div>
    <div class="container mt-5 mb-5" style="justify-content: center;">
        <div style="display: flex;justify-content: center; margin: 10px 20px 20px 30px;">
            <div class="col-md-5" style="background: #efefef;padding: 17px;border-radius: 3px;">
                <div v-for="(order, index) in list_product_payment_processing" :key="index" class="d-flex flex-row justify-content-between align-items-center p-2 bg-white mt-4 p-3 rounded item-list-order">
                    <!-- <div><img class="rounded" :src="order.fileDetailsId" width="50" height="40" style="border-radius: 10px"></div> -->
                    <div class="mr-1"><img class="rounded" :src="baseUrl +  + order.fileDetailsId" width="50" height="40"></div>
                    <div class="d-flex flex-column align-items-center product-details"><span class="font-weight-bold">{{ order.name }}</span>
                    </div>
                    <div>
                        <h5 class="text-grey" style="margin: 0px; position: static;">${{ formatMoney(order.totalPrice) }}</h5>
                    </div>
                </div>
                <div>
                    <div class='total col-md-12'>
                        <span style='float:left;'>
                            <div class='thin dense'>Delivery</div>
                            TOTAL
                        </span>
                        <span style='float:right; text-align:right;'>
                            <div class='thin dense'>$FREE</div>
                            ${{ formatMoney(calculateTotalPrice) }}
                        </span>
                    </div>
                </div>
            </div>

            <div class="col-md-5" style="background: #efefef;padding: 17px;border-radius: 3px; margin-left: 10px">
                <div class="p-2">
                    <h4 style="margin: 0 0 15px 0">Order notification</h4>
                </div>
                <div class="col-md-6" style="padding: 4px">
                    <input class="ip-imput-form" v-model="user.name" placeholder="Full Name" disabled>
                </div>
                <div class="col-md-6" style="padding: 4px">
                    <input class="ip-imput-form" v-model="user.email" placeholder="Email" disabled>
                </div>
                <div class="col-md-6" style="padding: 4px">
                    <input class="ip-imput-form" v-model="user.phone" placeholder="Phone" disabled>
                </div>
                <div class="col-md-6" style="padding: 4px">
                    <input class="ip-imput-form" v-model="user.address" placeholder="Address">
                </div>
                <div class="col-md-12" style="padding: 0px;margin-top: 10px;">
                    <div class="col-md-6" style="padding: 0px;">
                        <button class="btn btn-block ml-2 btn-payment" type="button" @click="updateStatus()">Order now</button>
                    </div>
                    <div class="col-md-6" style="padding: 0px;">
                        <a href="/cart" class="btn btn-block ml-2 btn-payment" style="background: #dc3545; margin-right: 11px;"  type="button">
                            Back
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import OrderService from '@/services/OrderService';
import base from "@/../base.json"

let data_user = JSON.parse(localStorage.getItem('user'));

export default {
    props: {
        list_product_payment_processing: {
            type: Array,
        },
        show_payment: {
            type: Boolean,
        },
    },
    data() {
        return {
            baseUrl: "",
            base,
            user: {
                id: data_user.id,
                name: data_user.name,
                email: data_user.email,
                phone: data_user.phone,
                address: data_user.address,
                address_detail: "",
            },
            total_money: 0,
        }
    },
    methods: {
        formatMoney(n) {
            this.total_money += n;
            return n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
        },
        updateStatus() {
            const user = this.user;
            this.list_product_payment_processing.forEach(element => {
                OrderService.updateStatus(element.id, 1, user.email, user.address)
                .then(() => {
                    window.location.reload();
                });
            });
            alert("?????t h??ng th??nh c??ng, ch??? x??c nh???n ????n t??? ng?????i b??n");
        }
    },
    created() {
        this.baseUrl = this.base.baseUrl + 'api/files/'
    },
    computed: { 
        calculateTotalPrice() {
            let total_price = 0;
            this.list_product_payment_processing.forEach(element => {
                total_price += element.totalPrice;
            });
            return total_price;
        }
        }
}
</script>

<style scoped>

@import "http://fonts.googleapis.com/css?family=Lato:400,700";

.total {
    margin-top:15px;
    font-size:20px;
    font-family: lato;
    background: white;
    padding: 15px;
    border-radius: 5px;
}

.thin {
    font-weight:400;
    font-family: lato;
}
.dense {
    line-height: 1.2em;
    font-size: 1.2rem;
    font-family: lato;
}
.btn-payment {
    font-size: 15px;
    font-weight: 500;
    box-sizing: border-box;
    color: white;
    border: 1px solid #d2d6db;
    border-radius: 6px;
    background-color: #5850eb;
}

.ip-imput-form {
    font-size: 16px;
    display: block;
    width: 99%;
    height: 50px;
    padding-left: 15px;
    border: 1px solid #d2d6db;
    border-radius: 6px;
}

.item-list-order:nth-child(1) {
    margin-top: 0;
}

.item-list-order {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 11px 25px 11px 25px;
    text-align: center;
    background: white;
    border-radius: 3px;
    margin-top: 15px;
    font-size: 14px;
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
