<template>
  <button type="button" class="btn btn-success" data-toggle="modal" data-target="#ToDoModalCreateForm">
    <font-awesome-icon icon="fa-regular fa-square-plus" />
    Create event
  </button>
  <ToDoModalForm Title="Create event" Id="ToDoModalCreateForm" SubmitButtonText="Create"></ToDoModalForm>
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
