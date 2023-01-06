<template>
  <div>
    <table class="table-auto">
      <thead class="bg-gray-100">
        <tr>
          <th>Song</th>
          <th>Artist</th>
          <th>Year</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>The Sliding Mr. Bones (Next Stop, Pottersville)</td>
          <td>Malcolm Lockyer</td>
          <td>1961</td>
        </tr>
        <tr>
          <td>Witchy Woman</td>
          <td>The Eagles</td>
          <td>1972</td>
        </tr>
        <tr>
          <td>Shining Star</td>
          <td>Earth, Wind, and Fire</td>
          <td>1975</td>
        </tr>
      </tbody>
    </table>



      <ul class="list-group">
        <li
          class="list-group-item"
          :class="{ active: index == currentIndex }"
          v-for="(tutorial, index) in tutorials"
          :key="index"
          @click="setActiveTutorial(tutorial, index)"
        >
          {{ tutorial.brand }}
        </li>
      </ul>
  </div>
</template>

<script>
 import { ref } from "vue"

// import CarService from "@/services/CarService";
import CarService from "../../services/CarService";
// import Tutorial from "@/types/Tutorial";
// import ResponseData from "@/types/ResponseData";

export default {
  name: "tutorials-list",
  data() {
    const tutorials=ref([]);
    return {
      tutorials,
      // currentTutorial,
      currentIndex: -1,
      title: "",
    };
  },
  methods: {
    retrieveTutorials() {
      CarService.getAll()
        .then((response) => {
          this.tutorials = response.data;
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveTutorials();
      this.currentTutorial = {} ;
      this.currentIndex = -1;
    },

    setActiveTutorial(tutorial, index = -1) {
      this.currentTutorial = tutorial;
      this.currentIndex = index;
    },

    removeAllTutorials() {
      CarService.deleteAll()
        .then((response) => {
          console.log(response.data);
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },

    searchTitle() {
      CarService.findByTitle(this.title)
        .then((response) => {
          this.tutorials = response.data;
          this.setActiveTutorial({} );
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.retrieveTutorials();
  },
};
</script>

<style>
.list {
  text-align: left;
  max-width: 750px;
  margin: auto;
}
</style>
