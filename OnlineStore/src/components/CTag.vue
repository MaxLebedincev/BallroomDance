<template>
    <v-card class="tag">
        <v-icon v-if="icon" class="tag__icon" :icon="icon" size="17px"></v-icon>
        <div class="tag__name">{{name}}</div>
    </v-card>
</template>

<script>
export default {
    name: "CTag",
    props: {
        name: {
            type: String,
            required: true
        },
        icon: {
            type: String,
            required: false
        },
        inverse: {
            type: Boolean,
            required: false
        }
    },
    data(){
        return {
            color: null,
            backgroundColor: null
        }
    },
    methods: {

    },
}
</script>

<style lang="scss" scoped>
.v-theme--dark{
    .tag {
        display: inline-flex;
        border: 1px solid;
        border-color: #000000;
        color: #000000;
        background-color: #ffffff;
    }
}
.tag {
    display: inline-flex;
    border-color: white;
    color: white;
    background-color: black;
    border-radius: 5px;
    margin: 1px;
    &__icon {
        display: inline-block;
        padding: 2px;
    }
    &__name {
        display: inline-block;
        padding: 2px 12px;
    }
}
</style>