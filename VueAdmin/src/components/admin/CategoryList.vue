<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
    <button class="btn-create" style="background: #28a745;" @click="setData(index, 'CREATE')">Thêm mới</button>
    <div class="block w-full overflow-x-auto" id="cars-list" v-show="viewData">
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
                <tr v-for="(item, index) in list_product" :key="index">
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ index+1 }}
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        <b>{{ item.Name }}</b>
                    </td>
                    <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4">
                        {{ item.Description }}
                    </td>
                    <td style="width: 10%">
                        <button class="btn-status" style="background: #28a745;" v-if="item.status == 1" @click="updateStatus(id, 2, index)">Hoạt động</button>
                        <button class="btn-status" style="background: #dc3545;" v-if="item.status == 2" @click="updateStatus(id, 1, index)">Không hoạt động</button>
                    </td>
                    <td style="width: 15%">
                        <button type="button" class="btn-status" style="background: rgb(54 40 167); margin-left: 4px;" @click="setData(index, 'EDIT')">
                            Sửa
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="w-full max-w-lg" v-show="!viewData" style="padding: 19px 15px 15px 15px;">
        <h1 class="-mx-3 mb-6" style="margin-left: 29px" v-if="type_perform == 'CREATE'"><b>Thêm Thể loại mới!</b></h1>
        <h1 class="-mx-3 mb-6" style="margin-left: 29px" v-if="type_perform == 'EDIT'"><b>Chỉnh sửa Thể loại!</b></h1>

        <div class="flex flex-wrap -mx-3 mb-4" style="margin-left: 19px">
            <div class="md:w-1/2 px-3">
                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-name">
                    Tên
                </label>
                <input v-model="data_edit_add.Name" class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-2 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="grid-last-name" type="text" placeholder="Doe">
            </div>
            <div class="md:w-1/2 px-3">
                <label class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2" for="grid-last-name">
                    Mô tả
                </label>
                <input v-model="data_edit_add.Description" class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-2 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500" id="grid-last-name" type="text" placeholder="Doe">
            </div>
        </div>
        <div class="w-full lg:w-12/12 px-3 mt-4" style="margin-left: 17px">
            <button class="btn-status" style="background: #dc3545; padding: 8px 40px 8px 40px; margin-right: 11px;" @click="viewData = true" type="button">
                Trở lại
            </button>
            <button v-if="type_perform == 'CREATE'" class="btn-status" style="background: #28a745; padding: 8px 40px 8px 40px" type="submit">
                Thêm
            </button>
            <button v-if="type_perform == 'EDIT'" class="btn-status" style="background: #28a745; padding: 8px 40px 8px 40px" type="submit">
                Sửa
            </button>
        </div>
    </div>

</div>
</template>

<script>
import {
    ref
} from "vue"
import ProductService from "../../services/ProductService";

export default {    
    data() {
        const list_product = ref([{
                Id: 1,
                Name: "Đá cổ",
                status: 2,
                Description: "San pham tot",
            },
            {
                Id: 2,
                Name: "Bình cổ",
                status: 2,
                Description: "San pham tot",
            },
            {
                Id: 3,
                Name: "Bát cổ",
                status: 2,
                Description: "San pham tot",
            },
        ]);
        const titles = ref(['ID', 'Tên', 'Mô tả', 'Trạng thái', 'Thao tác'])

        return {
            list_product,
            data_edit_add: {
                Name: null,
                Description: null,
            },
            titles,
            viewData: true,
            type_perform: "CREATE",
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
            ProductService.getAll()
                .then((response) => {
                    this.list_product = response.data;
                })
                .catch((e) => {
                    console.log(e);
                });
        },
        updateStatus(id, status, index) {
            this.list_product[index].status = status;
        },
        setData(index, type) {
            this.viewData = !this.viewData;

            if (type == "CREATE") {
                this.type_perform = "CREATE";
                this.data_edit_add = {
                    Name: null,
                    status: null,
                    Description: null,
                };
            } else {
                this.type_perform = "EDIT";
                const data = this.list_product[index];
                this.data_edit_add = {
                    id: data.Id,
                    Name: data.Name,
                    status: data.status,
                    Description: data.Description,
                };
            }
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
.btn-create {
    background: rgb(40, 167, 69);
    padding: 7px 35px 7px 35px;
    color: white;
}
</style>
