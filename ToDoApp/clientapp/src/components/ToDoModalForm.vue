<template>
    <div class="modal fade" id="ToDoModalForm" data-backdrop="static" data-keyboard="false" tabindex="-1"
        aria-labelledby="ToDoModalFormLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ToDoModalFormLabel">{{ Title }}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label class="control-label" for="FormInputName">Name</label>
                            <input type="text" class="form-control" id="FormInputName" placeholder="Enter event name" />
                        </div>
                        <div class="form-group">
                            <label for="FormInputDescription">Description</label>
                            <textarea class="form-control" id="FormInputDescription" rows="3"
                                placeholder="Enter event description"></textarea>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="FormInputPlace">Place</label>
                            <input type="text" class="form-control" id="FormInputPlace"
                                placeholder="Enter event place" />
                        </div>
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'ToDoModalForm',
    props: {
        Title: String,
        TodoItem: Object
    },
}
</script>