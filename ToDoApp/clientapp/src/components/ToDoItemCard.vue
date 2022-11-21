<template>
    {{ToDoItem}}
    <div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">{{todoItem.name}}</h5>
    <h6 class="card-subtitle mb-2 text-muted">{{todoItem.createdDateTime}}</h6>
    <p class="card-text">{{todoItem.description}}</p>
    <a href="#" class="card-link">Card link</a>
    <a href="#" class="card-link">Another link</a>
  </div>
</div>
</template>

<script>
export default{
    name : 'ToDoItemCard',
    props:{
        todoItem : Object
    }
}
</script>