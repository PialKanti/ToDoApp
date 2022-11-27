<template>
  <div class="card-deck mt-5" v-if="Items.length">
    <ToDoItemCard v-for="(item, index) in Items" :key="index" :todoItem="item" @refresh-list="$emit('refresh-list')" />
  </div>
  <div v-else>
    <p class="text-muted no-items-text">No {{ Type }} todo events.</p>
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
.no-items-text {
  text-align: center;
  margin: 20px;
  size: 16pt;
  font-weight: 500;
}
</style>