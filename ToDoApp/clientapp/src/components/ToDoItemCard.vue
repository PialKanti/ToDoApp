<template>
  <div class="card shadow bg-white rounded">
    <div class="card-header">
      <b>{{ todoItem.name }}</b>
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
      <small class="font-italic text-muted">Created at {{ getFormattedTime(todoItem.createdTimestamp)
      }}</small>
    </div>
    <div class="btn-group btn-blocks">
      <button type="button" class="btn btn-sm btn-outline-primary" @click="makeComplete" v-if="!todoItem.isCompleted">
        <font-awesome-icon icon="fa-solid fa-circle-check" />
        Complete
      </button>
      <button type="button" class="btn btn-sm btn-outline-info" data-toggle="modal" :data-target="dataTarget"
        v-if="!todoItem.isCompleted">
        <font-awesome-icon icon="fa-regular fa-pen-to-square" />
        Update
      </button>
      <button type="button" class="btn btn-sm btn-outline-danger" @click="onDeleteButtonClicked">
        <font-awesome-icon icon="fa-regular fa-trash-can" />
        Delete
      </button>
    </div>
    <ToDoModalForm Title="Update event" :Id="modalId" :TodoItem="todoItem" SubmitButtonText="Update"
      @form-submission="$emit('refresh-list')"></ToDoModalForm>
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
  emits: ['refresh-list'],
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
      const seconds = (date.getSeconds() == 0) ? "00" : date.getSeconds();
      const am_pm = date.getHours() >= 12 ? "PM" : "AM";
      return `${hours}:${minutes}:${seconds} ${am_pm}`;
    },
    async onDeleteButtonClicked() {
      const url = 'api/todo/' + this.todoItem.id;
      await fetch(url, {
        method: 'DELETE'
      });
      this.$emit('refresh-list');
    },
    async makeComplete() {
      const data = JSON.stringify({
        id: this.todoItem.id,
        name: this.todoItem.name,
        description: this.todoItem.description,
        place: this.todoItem.place,
        isCompleted: true,
        createdTimestamp: this.todoItem.createdTimestamp,
        expiryTimestamp: this.todoItem.expiryTimestamp
      });

      const requestUrl = 'api/todo/' + this.todoItem.id;
      console.log(requestUrl);
      await fetch(requestUrl, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: data
      });

      this.$emit('refresh-list');
    }
  },
};
</script>

<style scoped>
.card {
  max-width: 360px;
  min-width: 300px;
  margin-bottom: 20px;
}

.card-header {
  font-size: 14pt;
}

.btn-blocks {
  width: 100%;
  padding-left: 15px;
  padding-right: 15px;
  padding-bottom: 15px;
}

.btn {
  padding-left: 5px;
  padding-right: 5px;
  padding-top: 5px;
  padding-bottom: 5px;
  border-radius: 10px;
}
</style>
