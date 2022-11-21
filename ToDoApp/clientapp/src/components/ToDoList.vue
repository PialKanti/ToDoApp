<template>
  <button
    type="button"
    class="btn btn-success"
    data-toggle="modal"
    data-target="#staticBackdrop"
  >
    <font-awesome-icon icon="fa-regular fa-square-plus" />
    Create event
  </button>
  <div
    class="modal fade"
    id="staticBackdrop"
    data-backdrop="static"
    data-keyboard="false"
    tabindex="-1"
    aria-labelledby="staticBackdropLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
          <button
            type="button"
            class="close"
            data-dismiss="modal"
            aria-label="Close"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">...</div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">Understood</button>
        </div>
      </div>
    </div>
  </div>
  <div class="card-columns mt-5">
    <ToDoItemCard
      v-for="(item, index) in toDoItems"
      :key="index"
      :todoItem="item"
    />
  </div>
</template>

<script>
import ToDoItemCard from "./ToDoItemCard.vue";

export default {
  name: "ToDoList",
  components: {
    ToDoItemCard,
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
