<template>
    <button type="button" class="todo-type mt-5" @click="toggleListVisibility">
        <h5>
            <div class="todo-type-text">
                <font-awesome-icon icon="fa-regular fa-square-caret-down" v-if="showUpcomingList" />
                <font-awesome-icon icon="fa-regular fa-square-caret-right" v-else />
                {{ Type }}
            </div>
        </h5>
    </button>
    <ToDoList :Items="ItemList" v-show="showUpcomingList"></ToDoList>
</template>

<script>
import ToDoList from "./ToDoList.vue";

export default {
    name: "ToDoEvent",
    components: {
        ToDoList
    },
    data() {
        return {
            showUpcomingList: true
        };
    },
    props: {
        Type: String,
        ItemList: Array
    },
    methods: {
        toggleListVisibility() {
            this.showUpcomingList = !this.showUpcomingList;
        }
    }
};
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