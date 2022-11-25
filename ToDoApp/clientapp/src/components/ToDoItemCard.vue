<template>
  {{ ToDoItem }}
  <div class="card">
    <div class="card-header">
      <h5>{{ todoItem.name }}</h5>
    </div>
    <div class="card-body">
      <h6 class="card-subtitle mb-3 text-muted">
        <font-awesome-icon icon="fa-regular fa-calendar-days" />
        {{ getFormattedDate(todoItem.expiryTimestamp) }}
      </h6>
      <h6 class="mb-3 text-muted">
        <font-awesome-icon icon="fa-regular fa-clock" />
        {{ getFormattedTime(todoItem.expiryTimestamp) }}
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
      <ToDoModalForm Title="Update event" :Id="modalId" :TodoItem="todoItem" SubmitButtonText="Update"
        @form-submission="$emit('refresh-list')"></ToDoModalForm>
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
    getFormattedDate(timestamp) {
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

      var date = new Date(timestamp);
      const day = date.getDate();
      const month = monthNames[date.getMonth()];
      const year = date.getFullYear();

      return (day + " " + month + ", " + year);
    },
    getFormattedTime(timestamp) {
      var date = new Date(timestamp);
      let hours = date.getHours() % 12;
      if (hours == 0) {
        hours = 12;
      }
      const minutes = (date.getMinutes() == 0) ? "00" : date.getMinutes();
      const am_pm = date.getHours() >= 12 ? "PM" : "AM";
      return (hours + ":" + minutes + " " + am_pm);
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
.card {
  min-width: 20rem;
}
</style>
