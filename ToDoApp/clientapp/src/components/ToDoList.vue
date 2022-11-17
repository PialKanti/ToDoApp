<template>
    <div class="card-columns">
        <ToDoItemCard v-for="(item, index) in toDoItems" :key="index" :todoItem="item"/>
    </div>
</template>

<script>
import ToDoItemCard from './ToDoItemCard.vue'

export default{
    name : 'ToDoList',
    components:{
        ToDoItemCard
    },
    data(){
        return{
            toDoItems : []
        }
    },
    async created(){
        this.toDoItems = await this.fetchTodoList();
        console.log(this.toDoItems);
    },
    methods:{
        async fetchTodoList(){
            const response = await fetch('https://localhost:5002/api/todo');
            const data = await response.json();
            return data;
        }
    }
}
</script>