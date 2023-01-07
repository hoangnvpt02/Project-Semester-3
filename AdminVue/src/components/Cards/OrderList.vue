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
                        <div class="mr-1"><img class="rounded" :src="baseUrl +  + item.fileDetailsId" width="50" height="40"></div>
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.totalPrice }}
                    </td>
                    <td class=" border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.userName  }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.totalPrice }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        <button class="btn-status" style="background: #ffc107;" v-if="item.status == 1" @click="updateStatus(item.id, 2, index)">nhận đơn</button>
                        <button class="btn-status" style="background: #28a745;" v-if="item.status == 2" @click="updateStatus(item.id, 3, index)">Hoàn thành</button>
                        <button class="btn-status" style="background: #28a745;" v-if="item.status == 3">Đã Hoàn thành</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
</template>

<script>
import {
    ref
} from "vue"
import OrderService from "../../services/OrderService";
import base from "../../base.json";

export default {
    data() {
        const orders = ref([]);
        const titles = ref(['ID', 'NAME', 'IMAGE', 'PRICE', 'USER NAME', 'TOTAL MONEY', 'STATUS'])

        return {
            orders,
            titles,
            baseUrl: '',
            base,
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
            OrderService.getAllData()
                .then((response) => {
                    this.orders = response.data;
                })
                .catch((e) => {
                    console.log(e);
                });
        },
        updateStatus(id, status, index) {
            this.orders[index].status = status;

            OrderService.updateStatus(id, status)
            .then(() => {
                // window.location.reload();
            });
        },
    },
    created() {
        this.getListData();
        this.baseUrl = this.base.baseUrl + 'api/files/';
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
