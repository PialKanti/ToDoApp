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
                            <input type="text" class="form-control" :class="{ 'is-invalid': errors.name.show }"
                                id="FormInputName" placeholder="Enter event name" v-model="name" @input="onNameInput" />
                            <small class="text-danger" v-if="errors.name.show">
                                {{ errors.name.message }}
                            </small>
                        </div>
                        <div class="form-group">
                            <label for="FormInputDescription">Description</label>
                            <textarea class="form-control" :class="{ 'is-invalid': errors.description.show }"
                                id="FormInputDescription" rows="3" placeholder="Enter event description"
                                v-model="description"></textarea>
                            <small class="text-danger" v-if="errors.description.show">
                                {{ errors.description.message }}
                            </small>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="FormInputPlace">Place</label>
                            <input type="text" class="form-control" :class="{ 'is-invalid': errors.place.show }"
                                id="FormInputPlace" placeholder="Enter event place" v-model="place" />
                            <small class="text-danger" v-if="errors.place.show">
                                {{ errors.place.message }}
                            </small>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="FormInputExpiryDate">Remind me at</label>
                            <input type="datetime-local" class="form-control"
                                :class="{ 'is-invalid': errors.expiryTimestamp.show }" id="FormInputExpiryDate"
                                placeholder="Enter remind date and time" v-model="expiryTimestamp"
                                @input="onexpiryTimestampInput" />
                            <small class="text-danger" v-if="errors.expiryTimestamp.show">
                                {{ errors.expiryTimestamp.message }}
                            </small>
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
            closeButtonId: '',
            errors: {
                name: {
                    show: false,
                    message: ''
                },
                description: {
                    show: false,
                    message: ''
                },
                place: {
                    show: false,
                    message: ''
                },
                expiryTimestamp: {
                    show: false,
                    message: ''
                }
            }
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
    emits: ['form-submission'],
    methods: {
        async submitForm() {
            if (!this.validateFormData()) {
                return;
            }

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
        validateFormData() {
            if (!this.name) {
                this.errors.name.show = true;
                this.errors.name.message = 'Name is required';
                return false;
            }
            if (!this.expiryTimestamp) {
                this.errors.expiryTimestamp.show = true;
                this.errors.expiryTimestamp.message = 'Reminder date and time is required';
                return false;
            }
            return true;
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
            this.errors = {
                name: {
                    show: false,
                    message: ''
                },
                description: {
                    show: false,
                    message: ''
                },
                place: {
                    show: false,
                    message: ''
                },
                expiryTimestamp: {
                    show: false,
                    message: ''
                }
            }
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
        },
        onNameInput() {
            if (this.name) {
                this.errors.name.show = false;
                this.errors.name.message = '';
            }
        },
        onexpiryTimestampInput() {
            if (this.expiryTimestamp) {
                this.errors.expiryTimestamp.show = false;
                this.errors.expiryTimestamp.message = '';
            }
        }
    }
}
</script>