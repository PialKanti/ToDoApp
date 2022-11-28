<template>
    <div class="col-md-12 text-center">
        <button type="button" class="btn btn-outline-success btn-create" data-toggle="modal"
            data-target="#ToDoModalCreateForm">
            <font-awesome-icon icon="fa-regular fa-square-plus" />
            &nbsp;Create event
        </button>
    </div>
    <ToDoModalForm Title="Create event" Id="ToDoModalCreateForm" SubmitButtonText="Create"
        @form-submission="onFormSubmission">
    </ToDoModalForm>
    <ToDoEvent Type="upcoming" :ItemList="upcomingList" @refresh-list="onRefreshList"></ToDoEvent>
    <ToDoEvent Type="completed" :ItemList="completedList" @refresh-list="onRefreshList"></ToDoEvent>
    <ToDoEvent Type="expired" :ItemList="expiredList" @refresh-list="onRefreshList"></ToDoEvent>
</template>

<script>
import ToDoModalForm from "./ToDoModalForm.vue"
import ToDoEvent from "./ToDoEvent.vue";

export default {
    name: "AppHome",
    components: {
        ToDoModalForm,
        ToDoEvent
    },
    data() {
        return {
            upcomingList: [],
            completedList: [],
            expiredList: [],
            type: { Upcoming: "1", Completed: "2", Expired: "3" },
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
            this.expiredList = await this.fetchTodoList(this.type.Expired);
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

<style scoped>
.btn-create {
    border-radius: 20px;
    margin-top: 15px;
    margin-bottom: 10px;
    text-align: center;
    width: 25%;
}
</style>