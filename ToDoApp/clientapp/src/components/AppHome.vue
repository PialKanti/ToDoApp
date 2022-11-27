<template>
    <AppHeader title="ToDo App" />
    <button type="button" class="btn btn-outline-success" data-toggle="modal" data-target="#ToDoModalCreateForm">
        <font-awesome-icon icon="fa-regular fa-square-plus" />
        Create event
    </button>
    <ToDoModalForm Title="Create event" Id="ToDoModalCreateForm" SubmitButtonText="Create"
        @form-submission="onFormSubmission">
    </ToDoModalForm>
    <ToDoEvent Type="upcoming" :ItemList="upcomingList"></ToDoEvent>
    <ToDoEvent Type="completed" :ItemList="completedList"></ToDoEvent>
</template>

<script>
import AppHeader from "./AppHeader.vue";
import ToDoModalForm from "./ToDoModalForm.vue"
import ToDoEvent from "./ToDoEvent.vue";

export default {
    name: "AppHome",
    components: {
        AppHeader,
        ToDoModalForm,
        ToDoEvent
    },
    data() {
        return {
            upcomingList: [],
            completedList: [],
            type: { Upcoming: "1", Completed: "2" },
            showUpcomingList: true
        };
    },
    async created() {
        this.onRefreshList();
    },
    methods: {
        onFormSubmission() {
            this.onRefreshList();
        },
        async onRefreshList() {
            this.upcomingList = await this.fetchTodoList(this.type.Upcoming);
            this.completedList = await this.fetchTodoList(this.type.Completed);
        },
        async fetchTodoList(todoType) {
            const requestUrl = "api/todo?type=" + todoType;
            const response = await fetch(requestUrl);
            const data = await response.json();
            return data;
        }
    }
}
</script>