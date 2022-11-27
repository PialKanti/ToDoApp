<template>
  <div class="card-columns mt-5" v-if="ItemList.length">
    <ToDoItemCard v-for="(item, index) in ItemList" :key="index" :todoItem="item" @refresh-list="onRefreshList" />
  </div>
  <div v-else>
    <p class="no-items">No upcoming todo events</p>
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
    ItemList: Array
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