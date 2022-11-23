<template>
  {{ ToDoItem }}
  <div class="card" style="width: 22rem">
    <div class="card-header">
      <h5>{{ todoItem.name }}</h5>
    </div>
    <div class="card-body">
      <h6 class="card-subtitle mb-2 text-muted">
        <font-awesome-icon icon="fa-regular fa-calendar-days" />
        {{ getFormattedDateTime(todoItem.expiryDateTime) }}
      </h6>
      <p class="card-text">{{ todoItem.description }}</p>
      <p>
        <font-awesome-icon icon="fa-solid fa-location-dot" />
        {{ todoItem.place }}
      </p>
      <div class="row">
        <div class="col-md-4">
          <button type="button" class="btn btn-light">
            <font-awesome-icon icon="fa-regular fa-circle-check" />
            Complete
          </button>
        </div>
        <div class="col-md-4">
          <button type="button" class="btn btn-light" data-toggle="modal" :data-target="dataTarget">
            <font-awesome-icon icon="fa-regular fa-pen-to-square" />
            Update
          </button>
        </div>
        <div class="col-md-4">
          <button type="button" class="btn btn-light" @click="onDeleteButtonClicked">
            <font-awesome-icon icon="fa-regular fa-trash-can" />
            Delete
          </button>
        </div>
      </div>
      <ToDoModalForm Title="Update event" :Id="modalId" :TodoItem="todoItem" SubmitButtonText="Update"></ToDoModalForm>
    </div>
  </div>
</template>

<script>
import ToDoModalForm from './ToDoModalForm.vue';

export default {
  name: "ToDoItemCard",
  components: {
    ToDoModalForm
  },
  data() {
    return {
      dataTarget: '',
      modalId: ''
    };
  },
  props: {
    todoItem: Object,
  },
  created() {
    this.modalId = "ToDoModalUpdateForm" + this.todoItem.id;
    this.dataTarget = "#" + this.modalId;
  },
  methods: {
    getFormattedDateTime(dateTime) {
      const monthNames = [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December",
      ];

      var date = new Date(dateTime);
      const day = date.getDate();
      const month = monthNames[date.getMonth()];
      const year = date.getFullYear();

      let hours = date.getHours() % 12;
      if (hours == 0) {
        hours = 12;
      }
      const minutes = date.getMinutes();
      const am_pm = date.getHours() > 12 ? "PM" : "AM";
      return (
        day +
        " " +
        month +
        ", " +
        year +
        " " +
        hours +
        ":" +
        minutes +
        " " +
        am_pm
      );
    },
    async onDeleteButtonClicked() {
      const url = 'api/todo/' + this.todoItem.id;
      await fetch(url, {
        method: 'DELETE'
      });
      this.$emit('refresh-list');
    }
  },
};
</script>

<style scoped>

</style>
