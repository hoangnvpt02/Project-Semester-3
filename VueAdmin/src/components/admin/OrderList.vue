<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
    <div class="block w-full overflow-x-auto" id="cars-list">
        <!-- Projects table -->
        <table class="table-order items-center w-full bg-transparent border-collapse">
            <thead>
                <tr>
                    <th v-for="(title, index) in titles" :key="index" class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left bg-blueGray-50 text-blueGray-500 border-blueGray-100">
                        {{ title }}
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in orders" :key="index">
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ index+1 }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        <b>{{ item.name }}</b>
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        <img :src="item.image" style="width: 87px;border-radius: 10px; margin-left: 11px;" alt="">
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.totalPrice   }}
                    </td>
                    <td class=" border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.userName  }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.totalPrice }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        <button class="btn-status" style="background: #ffc107;" v-if="item.status == 1">nhận đơn</button>
                        <button class="btn-status" style="background: #28a745;" v-if="item.status == 2">Hoàn thành</button>
                        <button class="btn-status" style="background: #dc3545;" v-if="item.status == 3">Xác nhận hủy đơn</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
</template>

<script>
import {ref} from "vue"
import OrderService from "../../services/OrderService";

export default {
    data() {
        const orders = ref([]);
        const titles = ref(['ID', 'NAME', 'IMAGE', 'PRICE', 'USER NAME', 'TOTAL MONEY', 'STATUS'])

        return {
            orders,
            titles,
        };
    },
    props: {
        color: {
            default: "light",
            validator: function (value) {
                // The value must match one of these strings
                return ["light", "dark"].indexOf(value) !== -1;
            },
        },
    },

    methods: {
        getListData() {
            OrderService.getAll()
                .then((response) => {
                    this.orders = response.data;
                    this.orders = [
                        {
                            id: 2,
                            name: "Do co 100.000 nam",
                            image: "http://vanhoanghethuat.vn/datasite///201807/BAI_VIET_14562/03%20(3).jpg",
                            price: "10.000.000",
                            userName: "Thanh Nguyen",
                            totalPrice: "10.000.000",
                            status: 1,
                        },
                        {
                            id: 2,
                            name: "Do co 100.000 nam",
                            image: "http://vanhoanghethuat.vn/datasite///201807/BAI_VIET_14562/03%20(3).jpg",
                            price: "10.000.000",
                            userName: "Thanh Nguyen",
                            totalPrice: "10.000.000",
                            status: 2,
                        },
                        {
                            id: 3,
                            name: "Do co 100.000 nam",
                            image: "http://vanhoanghethuat.vn/datasite///201807/BAI_VIET_14562/03%20(3).jpg",
                            price: "10.000.000",
                            userName: "Thanh Nguyen",
                            totalPrice: "10.000.000",
                            status: 3,
                        },
                    ];
                })
                .catch((e) => {
                    console.log(e);
                });
        },
    },
    created() {
        this.getListData();
    },
};
</script>

<style>
.table-order th {
    vertical-align: middle;
    text-align: center;
}

.table-order td {
    vertical-align: middle;
    text-align: center;
}

.btn-status {
    padding: 5px 11px 5px 11px;
    border-radius: 20px;
    font-size: 11px;
    color: white;
}
</style>