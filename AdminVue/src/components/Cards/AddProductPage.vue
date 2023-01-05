<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">

  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent="onSubmit">
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Product Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Product Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="product.name" name="name" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Price
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="product.price" name="price" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Author
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="product.author" name="author" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Quanlity
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="product.quanlity" name="quanlity" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Featured Product
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="feature" v-model="product.feature">
              <option v-for="item in features" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Category
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="categoryId">
              <option v-for="item in categories" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Percent Discount
            </label>
            <input type="number" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="product.discount" name="discount" />

          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Active
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="product.active">
              <option v-for="item in actives" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Description
            </label>
            <textarea type="text" placeholder="Example:Add description..." class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" rows="4" required v-model="product.description" name="note">
            </textarea>
          </div>
        </div>
        
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              IMAGE PRODUCT
            </label>
            <div class="flex items-center space-x-6">
              <div v-if="previewImage" class="shrink-0">
                <img style="width:100px;height:100px" class="object-cover rounded-md" :src="previewImage" alt="Photo" />
              </div>
              <div v-else class="shrink-0">
                <img style="width:100px;height:100px" class="object-cover rounded-md" src="https://png.pngtree.com/png-vector/20190508/ourmid/pngtree-upload-cloud-vector-icon-png-image_1027251.jpg" alt="Photo" />
              </div>
              <label class="block">
                <span class="sr-only">Choose profile photo</span>
                <input type="file" accept="image/*" ref="file" @change="selectImage" />
              </label>
            </div>
          </div>
        </div>
        <!-- <div class="w-full lg:w-6/12 px-4">
          <button class="block text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" :disabled="!currentImage" @click="upload">
            Upload
          </button>

        </div> -->
      </div>
      <div class="w-full lg:w-12/12 px-4 mt-8">
        <a href="/admin/product-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
          Back
        </a>
        <button @click="save" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Save
        </button>
      </div>
    </form>

  </div>

</div>
</template>

<script>
import CategoryService from "../../services/CategoryService";
import ProductService from "../../services/ProductService";
import ProductCate from "../../services/ProductCate";
import UploadService from "../../services/UploadFilesService";
import { ref } from "vue"
import swal from 'sweetalert';

export default {
  data() {
    const categories = ref([]);
    let categoryId
    let idProduct
    return {
      idProduct,
      categoryId,
      categories,
      currentImage: undefined,
      previewImage: undefined,
      previewImage1: null,
      progress: 0,
      message: "",
      imageInfos: [],
      features: [{
          id: 0,
          name: 'Yes'
        },
        {
          id: 1,
          name: 'No'
        },
      ],
      actives: [{
          id: 0,
          name: 'Active'
        },
        {
          id: 1,
          name: 'InActive'
        },
      ],
      product: {
        name: null,
        price: null,
        author: null,
        quanlity: null,
        feature: null,
        active: 0,
        description: null,
        discount: null,
      },
    }
  },
  methods: {
    selectImage() {
      this.currentImage = this.$refs.file.files.item(0);
      this.previewImage = URL.createObjectURL(this.currentImage);
      this.progress = 0;
      this.message = "";
    },
    getAllCategory() {
      CategoryService.getAll()
        .then((response) => {
          this.categories = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    save() {
      const formData = new FormData();
      formData.append('fileDetails',  this.$refs.file.files.item(0));
      formData.append('Name', this.product.name);
      formData.append('Price', this.product.price);
      formData.append('Author', this.product.author);
      formData.append('Quanlity', this.product.quanlity);
      formData.append('IsFeature', this.product.feature);
      formData.append('IsActive', this.product.active);
      formData.append('Description', this.product.description);
      formData.append('SalePercent', this.product.discount);
          const data = {
            method: 'POST',
            body: formData
            // If you add this, upload won't work
            // headers: {
            //   'Content-Type': 'multipart/form-data',
            // }
          };
          fetch('https://localhost:5001/api/Product', data)
          .then((response) => { 
            return response.json().then((data) => {
                console.log(data);
                this.idProduct = data.id
            })
            })
            .then(() => { 
              let data = {
                productId : this.idProduct,
                categoryId : this.categoryId
              }
              ProductCate.create(data)
            })
            .then(() => {
              swal("Success!", "Add Successfully!", "success", {
                button: false,
                timer: 2000
              });
            })
            .catch((res) => {
              console.log(res.message)
              swal("Error!", "Add Failed!", "error", {
                button: false,
                timer: 2000
              });
            });


      // let formData = new FormData();
      // formData.append('file', this.currentImage);
      // let data = {
      //   name: this.product.name,
      //   price: this.product.price,
      //   author: this.product.author,
      //   quanlity: this.product.quanlity,
      //   feature: this.product.feature,
      //   active: this.product.active,
      //   fileDetails:  this.previewImage
      // };
      // ProductService.create(data)
      //   .then(() => {
      //     swal("Success!", "Add Successfully!", "success", {
      //       button: false,
      //       timer: 2000
      //     });
      //   })
      //   .catch((res) => {
      //     console.log(res.message)
      //     swal("Error!", "Add Failed!", "error", {
      //       button: false,
      //       timer: 2000
      //     });
      //   });
    },
  },
  created() {
    this.getAllCategory()
  }
}
</script>

<style>
input[type="file"] {
  background-color: antiquewhite;
  border-radius: 5px;
  margin-left: 5px;
}

input::file-selector-button {
  font-weight: normal;
  color: limegreen;
  padding: 0.5em;
  border: thin solid gainsboro;
  border-radius: 5px;
  cursor: pointer;
}
</style>
