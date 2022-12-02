<template>
    <button type="button" class="btn btn-outline-dark btn-block todo-type mt-4" @click="toggleListVisibility">
        <div class="todo-type-text">
            <font-awesome-icon icon="fa-regular fa-square-caret-down" v-if="showUpcomingList" />
            <font-awesome-icon icon="fa-regular fa-square-caret-right" v-else />
            {{ capitalizeFirstLetter(Type) }}
        </div>
    </button>
    <ToDoList :Type="Type" :Items="ItemList" v-show="showUpcomingList" @refresh-list="$emit('refresh-list')"></ToDoList>
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
    emits: ['refresh-list'],
    methods: {
        toggleListVisibility() {
            this.showUpcomingList = !this.showUpcomingList;
        },
        capitalizeFirstLetter(str) {
            return str.charAt(0).toUpperCase() + str.slice(1);
        }
    }
};
</script>

<style scoped>
.todo-type {
    border-radius: 10px;
    width: 100%;
    height: 40px;
    text-align: left;
}

.todo-type-text {
    font-size: 13pt;
    vertical-align: middle;
}
</style>