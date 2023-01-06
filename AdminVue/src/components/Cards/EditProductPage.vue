<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent>
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Edit Product Information
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
      <div class="w-full lg:w-12/12 px-4">
        <a href="/admin/product-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
          Back
        </a>
        <button @click="fnUpdate" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Save
        </button>
      </div>
    </form>
  </div>
</div>
</template>

<script>
import ProductService from '@/services/ProductService';
import CategoryService from "../../services/CategoryService";
import ProductCate from '../../services/ProductCate';
import UploadService from "../../services/UploadFilesService";
import swal from 'sweetalert';
export default {
  data() {
    let categories;
    let categoryId

    return {
      categoryId,
      categories,
      currentImage: undefined,
      previewImage: undefined,
      progress: 0,
      message: "",
      imageInfos: [],
      genders: [{
          id: 1,
          name: 'Male'
        },
        {
          id: 2,
          name: 'Female'
        },

      ],
      product: {
        id: null,
        name: null,
        price: null,
        author: null,
        quanlity: null,
        feature: null,
        active: 0,
        description: null,
        discount: null,
        fileDetailsId: null,
      },
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
    }
  },
  methods: {
    getAllCategory() {
      CategoryService.getAll()
        .then((response) => {
          this.categories = response.data;
          // console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    selectImage() {
      this.currentImage = this.$refs.file.files.item(0);
      this.previewImage = URL.createObjectURL(this.currentImage);
      this.progress = 0;
      this.message = "";
    },
    upload() {
      this.progress = 0;
      UploadService.upload(this.$route.params.id, this.currentImage)
        .then(() => {
          swal("Success!", "Upload  Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Upload  Failed!", "error", {
            button: false,
            timer: 2000
          });
        });
    },
    getFiles() {

    },
    getProductById(id) {
      ProductService.getById(id)
        .then((response) => {
          this.product.id = response.data.id;
          this.product.name = response.data.name;
          this.product.price = response.data.price;
          this.product.author = response.data.author;
          this.product.quanlity = response.data.quanlity;
          this.product.feature = response.data.isFeature;
          this.product.active = response.data.isActive;
          this.currentImage = response.data.image;
          this.previewImage = response.data.image;
          this.product.description = response.data.description;
          this.product.discount = response.data.salePercent;
          this.product.fileDetailsId = response.data.fileDetailsId;

        })
        .catch((e) => {
          console.log(e);
        });
    },

    getByProductId(id) {
      ProductCate.getByProductId(id).then((response) => {
        // console.log("🚀 ~ file: EditProductPage.vue:254 ~ ProductCate.getByProductId ~ response", response)
        this.categoryId = response.data.categoryId
    })
    },
    fnUpdate() {
      let data = {
        id : this.product.id,
        name: this.product.name,
        price: this.product.price,
        author: this.product.author,
        quanlity: this.product.quanlity,
        feature: this.product.feature,
        active: this.product.active,
        description: this.product.description,
        salePercent: this.product.discount,
      };

      ProductService.update(data)
        .then(() => {
          swal("Success!", "Update Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Update Failed!", "error", {
            button: false,
            timer: 2000
          });
        });

      // const formData = new FormData();
      // // formData.append('fileDetails',  this.$refs.file.files.item(0));
      // formData.append('Id', this.product.id);
      // formData.append('Name', this.product.name);
      // formData.append('Price', this.product.price);
      // formData.append('Author', this.product.author);
      // formData.append('Quanlity', this.product.quanlity);
      // formData.append('IsFeature', this.product.feature);
      // formData.append('IsActive', this.product.active);
      // formData.append('Description', this.product.description);
      // formData.append('SalePercent', this.product.discount);
      //     const data = {
      //       method: 'PUT',
      //       body: formData
      //       // If you add this, upload won't work
      //       // headers: {
      //       //   'Content-Type': 'multipart/form-data',
      //       // }
      //     };
      //     fetch('https://localhost:5001/api/Product', data)
      //     .then((response) => { 
      //       return response.json().then((data) => {
      //           console.log(data);
      //           this.idProduct = data.id
      //       })
      //       })
      //       .then(() => { 
      //         let data = {
      //           productId : this.idProduct,
      //           categoryId : this.categoryId
      //         }
      //         ProductCate.create(data)
      //       })
      //       .then(() => {
      //         swal("Success!", "Add Successfully!", "success", {
      //           button: false,
      //           timer: 2000
      //         });
      //       })
      //       .catch((res) => {
      //         console.log(res.message)
      //         swal("Error!", "Add Failed!", "error", {
      //           button: false,
      //           timer: 2000
      //         });
      //       });
    },
  },
  created() {
    this.getAllCategory()
    this.getByProductId(this.$route.params.id)
    this.getProductById(this.$route.params.id)
  },

}
</script>

<style>
.swal-modal {
  text-align: center;
  align-items: center;
}

.swal-text {
  background-color: #FEFAE3;
  padding: 17px;
  border: 1px solid #F0E1A1;
  display: block;
  margin: 22px;
  text-align: center;
  color: #61534e;
  border-radius: 2px;
}

/* .swal-button {
  padding: 7px 29px;
  border-radius: 2px;
  background-color: #059669;
  font-size: 12px;
  text-shadow: 0px -1px 0px #45ebb6;
  align-items: center;
} */
.swal-footer {
  text-align: center;
}
</style>
