<template>
    <div class="modal fade" :id="Id" data-backdrop="static" data-keyboard="false" tabindex="-1"
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
                            <input type="text" class="form-control" id="FormInputName" placeholder="Enter event name"
                                v-model="name" />
                        </div>
                        <div class="form-group">
                            <label for="FormInputDescription">Description</label>
                            <textarea class="form-control" id="FormInputDescription" rows="3"
                                placeholder="Enter event description" v-model="description"></textarea>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="FormInputPlace">Place</label>
                            <input type="text" class="form-control" id="FormInputPlace" placeholder="Enter event place"
                                v-model="place" />
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="FormInputExpiryDate">Remind me at</label>
                            <input type="text" class="form-control" id="FormInputExpiryDate"
                                placeholder="Enter remind date and time" v-model="expiryDateTime" />
                        </div>
                        <button type="submit" class="btn btn-primary">{{ SubmitButtonText }}</button>
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
        Id: String,
        TodoItem: Object,
        SubmitButtonText: String
    },
    data() {
        return {
            name: '',
            description: '',
            place: '',
            expiryDateTime: ''
        };
    },
    created() {

        if (this.TodoItem) {
            this.name = this.TodoItem.name;
            this.description = this.TodoItem.description;
            this.place = this.TodoItem.place;
            this.expiryDateTime = new Date(this.TodoItem.expiryDateTime);
            console.log(this.TodoItem.expiryDateTime);
        }
    },
}
</script>