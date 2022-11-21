<template>
  <button type="button" class="btn btn-success" data-toggle="modal" data-target="#ToDoModalForm">
    <font-awesome-icon icon="fa-regular fa-square-plus" />
    Create event
  </button>
  <ToDoModalForm Title="Create event"></ToDoModalForm>
  <div class="card-columns mt-5">
    <ToDoItemCard v-for="(item, index) in toDoItems" :key="index" :todoItem="item" />
  </div>
</template>

<script>
import ToDoItemCard from "./ToDoItemCard.vue";
import ToDoModalForm from "./ToDoModalForm.vue";

export default {
  name: "ToDoList",
  components: {
    ToDoItemCard,
    ToDoModalForm
  },
  data() {
    return {
      toDoItems: [],
    };
  },
  async created() {
    this.toDoItems = await this.fetchTodoList();
    console.log(this.toDoItems);
  },
  methods: {
    async fetchTodoList() {
      const response = await fetch("api/todo");
      const data = await response.json();
      return data;
    },
  },
};
</script>

<style scoped>
form-group {
  text-align: left;
  align-content: flex-start;
}
</style>
