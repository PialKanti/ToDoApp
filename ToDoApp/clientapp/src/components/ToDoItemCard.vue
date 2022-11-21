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
          <button type="button" class="btn btn-light">
            <font-awesome-icon icon="fa-regular fa-pen-to-square" />
            Update
          </button>
        </div>
        <div class="col-md-4">
          <button type="button" class="btn btn-light">
            <font-awesome-icon icon="fa-regular fa-trash-can" />
            Delete
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ToDoItemCard",
  props: {
    todoItem: Object,
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
      return (
        date.getDate() +
        " " +
        monthNames[date.getMonth()] +
        ", " +
        date.getFullYear() +
        " " +
        date.getHours() +
        ":" +
        date.getMinutes()
      );
    },
  },
};
</script>

<style scoped></style>
