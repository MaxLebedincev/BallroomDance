<template>
    <div class="wrapper">
        <v-card
            class="card"
            @mouseover="upHere = true"
            @mouseleave="upHere = false"
            height="300px"
            width="200px"
        >
            <v-img
                :src="getImg(modelValue.image)"
                class="align-end"
                gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                height="300px"
                cover
            >
                <v-card-actions class="card-footer">
                    <div class="card-title">{{modelValue.name}}</div>
                    <div style="display: flex; justify-content: flex-end">
                        <v-btn
                            size="small"
                            color="#dd0000"
                            variant="text"
                            icon="mdi-cart-outline"
                            @click="$router.push(`/product/${modelValue.id}`)"
                        ></v-btn>
                    </div>
                </v-card-actions>
            </v-img>
        </v-card>
        <v-card class="popup"  v-if="upHere">
            <template #title>
                <h3>{{modelValue.name}}</h3>
                <hr>
            </template>
            <template #text>
                <div>
                    <c-tag
                        v-for="tag in [].concat(modelValue.listGenres).slice(0, 3)" :key="tag.id"
                        :name="tag.name"
                        :icon="tag.image"
                        :inverse="false"
                    ></c-tag>
                </div>
                <hr class="popup-hr">
                <p class="popup-text">
                    {{modelValue.description}}
                </p>
            </template>
        </v-card>
        <div v-if="false" >
            <c-tag
                v-for="tag in [].concat(modelValue.tags).slice(0, 3)" :key="tag.id"
                :name="tag.name"
                :icon="tag.image"
                :inverse="false"
            ></c-tag>
        </div>
    </div>
</template>

<script>
import CTag from "@/components/CTag";
export default {
    name: "CustomCard",
    components: {
        CTag
    },
    props: {
        modelValue:{
            type: Object,
            required: true
        }
    },
    data: () => ({
        upHere: false,
    }),
    methods: {
        getImg(path) {
            return require(`@/assets/image/${path ?? 'product.jpg'}`);
        }
    }
}
</script>


<style lang="scss" scoped>
.v-theme--dark{
    .wrapper {
        .card {
            &-footer{
                background: rgba(0,0,0,0.3) ;
            }
            &-title{
                color: #ffffff
            }
        }
    }
}
.wrapper {
    display: flex;
    .card {
        display: inline-block;
        &-footer{
            background: rgba(255,255,255,0.65) ;
        }
        &-title{
            opacity: 1;
            width: 200px;
            color: #000000;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }
    }
    .popup {
        position: absolute;
        transform: translate(220px, -105px);
        opacity: 0.9;
        z-index: 100;
        max-width: 300px;
        max-height: 450px;
        h3 {
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }
        &-hr {
            margin-top: 10px;
        }
        &-text {
            margin-top: 10px;
            text-overflow: ellipsis;
            overflow: hidden;
            -webkit-line-clamp: 15;
            display: -webkit-box; /* Включаем флексбоксы */
            -webkit-box-orient: vertical;
        }
    }
}
</style>