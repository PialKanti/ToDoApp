<template>
    <nav class="navbar navbar-dark bg-dark">
        <a class="navbar-brand" href="#">{{ Title }}</a>
        <form class="form-inline" @submit.prevent="search">
            <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"
                v-model="searchText">
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
        </form>
    </nav>
</template>

<script>
export default {
    name: 'AppHeader',
    props: {
        Title: String
    },
    data() {
        return {
            searchText: ''
        };
    },
    emits: ['search-items'],
    methods: {
        search() {
            this.$emit('search-items', this.searchText);
        }
    }
}
</script>