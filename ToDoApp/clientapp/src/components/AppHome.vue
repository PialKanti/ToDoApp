<template>
    <AppHeader title="ToDo App" />
    <button type="button" class="btn btn-outline-success" data-toggle="modal" data-target="#ToDoModalCreateForm">
        <font-awesome-icon icon="fa-regular fa-square-plus" />
        Create event
    </button>
    <ToDoModalForm Title="Create event" Id="ToDoModalCreateForm" SubmitButtonText="Create"
        @form-submission="onFormSubmission">
    </ToDoModalForm>

    <button type="button" class="todo-type mt-5" @click="toggleListVisibility">
        <h5>
            <div class="todo-type-text">
                <font-awesome-icon icon="fa-regular fa-square-caret-down" v-if="showUpcomingList" />
                <font-awesome-icon icon="fa-regular fa-square-caret-right" v-else />
                Upcoming
            </div>
        </h5>
    </button>
    <ToDoList :ItemList="upcomingList" v-show="showUpcomingList"></ToDoList>
</template>

<script>
import AppHeader from "./AppHeader.vue";
import ToDoList from "./ToDoList.vue";
import ToDoModalForm from "./ToDoModalForm.vue";

export default {
    name: "AppHome",
    components: {
        AppHeader,
        ToDoList,
        ToDoModalForm
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
        },
        toggleListVisibility() {
            this.showUpcomingList = !this.showUpcomingList;
        }
    }
}
</script>

<style scoped>
.todo-type {
    border: thin solid;
    border-color: black;
    border-radius: 10px;
    width: 100%;
    height: 40px;
    vertical-align: center;
    text-align: left;
    background-color: transparent;
}

.todo-type-text {
    margin-left: 10px;
    margin-top: 6px;
}
</style>