<template>
  <button type="button" class="btn btn-success" data-toggle="modal" data-target="#staticBackdrop">
    <font-awesome-icon icon="fa-regular fa-square-plus" />
    Create event
  </button>
  <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1"
    aria-labelledby="staticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form>
            <div class="form-group">
              <label class="control-label" for="exampleInputEmail1">Email address</label>
              <input type="email" class="form-control text-left" id="exampleInputEmail1" aria-describedby="emailHelp"
                placeholder="Enter email" />
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Password</label>
              <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password" />
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
      </div>
    </div>
  </div>
  <div class="card-columns mt-5">
    <ToDoItemCard v-for="(item, index) in toDoItems" :key="index" :todoItem="item" />
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

<style scoped>
form-group {
  text-align: left;
  align-content: flex-start;
}
</style>
