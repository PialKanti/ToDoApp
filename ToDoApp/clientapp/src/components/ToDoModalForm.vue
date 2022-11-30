<template>
    <div class="modal fade" :id="Id" data-backdrop="static" data-keyboard="false" tabindex="-1"
        aria-labelledby="ToDoModalFormLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ToDoModalFormLabel">{{ Title }}</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" :id="closeButtonId"
                        @click="closeClick">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form ref="todoForm" @submit.prevent="submitForm">
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
                            <input type="datetime-local" class="form-control" id="FormInputExpiryDate"
                                placeholder="Enter remind date and time" v-model="expiryTimestamp" />
                        </div>
                        <button type="submit" class="btn btn-primary">{{
                                SubmitButtonText
                        }}</button>
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
            isCompleted: false,
            expiryTimestamp: '',
            closeButtonId: ''
        };
    },
    beforeMount() {
        this.closeButtonId = 'close' + this.Id;
    },
    created() {
        if (this.TodoItem) {
            this.name = this.TodoItem.name;
            this.description = this.TodoItem.description;
            this.place = this.TodoItem.place;
            this.isCompleted = this.TodoItem.isCompleted;
            this.expiryTimestamp = this.toIsoString(this.TodoItem.expiryTimestamp);
        }
    },
    methods: {
        async submitForm() {
            var data;
            if (this.SubmitButtonText == 'Create') {
                data = JSON.stringify({
                    name: this.name,
                    description: this.description,
                    place: this.place,
                    expiryTimestamp: new Date(this.expiryTimestamp).getTime()
                });

                console.log(data);

                await fetch('api/todo', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: data
                });
            }
            else {
                data = JSON.stringify({
                    id: this.TodoItem.id,
                    name: this.name,
                    description: this.description,
                    place: this.place,
                    isCompleted: this.isCompleted,
                    expiryTimestamp: new Date(this.expiryTimestamp).getTime()
                });

                const requestUrl = 'api/todo/' + this.TodoItem.id;
                console.log(requestUrl);
                await fetch(requestUrl, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: data
                });
            }

            this.$emit('form-submission');
            this.$refs.todoForm.reset();
            this.closeModal();
            this.resetForm();
        },
        closeModal() {
            document.getElementById(this.closeButtonId).click();
        },
        closeClick() {
            this.resetForm();
        },
        resetForm() {
            this.name = '';
            this.description = '';
            this.place = '';
            this.expiryTimestamp = '';
        },
        toIsoString(timestamp) {
            var date = new Date(timestamp);
            return date.getFullYear() +
                '-' + this.pad(date.getMonth() + 1) +
                '-' + this.pad(date.getDate()) +
                'T' + this.pad(date.getHours()) +
                ':' + this.pad(date.getMinutes());
        },
        pad(num) {
            return (num < 10 ? '0' : '') + num;
        }
    }
}
</script>