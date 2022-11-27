<template>
  <div class="card-columns mt-5" v-if="Items.length">
    <ToDoItemCard v-for="(item, index) in Items" :key="index" :todoItem="item" @refresh-list="onRefreshList" />
  </div>
  <div v-else>
    <p class="no-items">No {{ Type }} todo events</p>
  </div>

</template>

<script>
import ToDoItemCard from "./ToDoItemCard.vue";

export default {
  name: "ToDoList",
  components: {
    ToDoItemCard
  },
  props: {
    Items: Array,
    Type: String
  }
};
</script>

<style scoped>
.no-items {
  text-align: center;
  margin: 10px;
  color: grey;
  size: 15pt;
}
</style>