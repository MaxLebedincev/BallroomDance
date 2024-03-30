<template>
    <v-container class="fill-height">
        <v-card class="product-border">
            <template #title>
                <h3 style="padding-bottom: 10px">{{product.name}} - {{product.price}} руб.</h3>
                <hr/>
            </template>
            <template #subtitle>
                <div style="display: flex; padding-top: 20px;">
                    <h2>{{product.author}}</h2>
                </div>
            </template>
            <template #text>
                <div style="display: flex">
                    <v-img
                        :src="getImg(product.image)"
                        width="300px"
                        height="400px"
                        cover
                    ></v-img>
                    <div>
                        <div style="padding-left: 20px" v-if="product.listGenres">
                            <div style="font-size: 16px; padding-bottom: 5px">Жанры:</div>
                            <c-tag
                                v-for="tag in [].concat(product.listGenres)"
                                :key="tag.id"
                                :name="tag.name"
                                :icon="tag.image"
                                :inverse="false"
                            ></c-tag>
                        </div>
                        <div style="font-size: 16px; padding: 20px">{{product.description}}</div>
                        <div class="text-left" style="padding-left: 5px; display: flex">
                            <div class="text-date">Дата выхода: {{dateConvert(product.date)}}</div>
                            <div class="popular-text">Оценки клиентов: </div>
                            <v-rating
                                v-model="product.popular"
                                color="#dd0000"
                                disabled
                            ></v-rating>
                        </div>
                    </div>
                </div>
            </template>
            <template #actions>
                <div class="custom-btn">
                    <v-btn color="#dd0000" variant="text" @click="$router.push('/')">
                        Назад
                    </v-btn>
                    <v-btn color="#dd0000" variant="text" @click="alert = true">
                        Купить
                    </v-btn>
                </div>
            </template>
        </v-card>
        <v-dialog
            :model-value="alert"
            width="auto"
        >
            <v-card>
                <v-card-text>
                    Функциоал находится в разработке!
                </v-card-text>
                <v-card-actions>
                    <v-btn color="#dd0000" block @click="alert = false">Закрыть</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script>
import {UseGetBook} from "@/hooks/data/get/useGetBook";
import CTag from "@/components/CTag";
import moment from "moment";

export default {
    name: "ProductView",
    components: {
        CTag
    },
    data: () => ({
        product: {},
        alert: false
    }),
    mounted() {
        this.getBook();
    },
    methods: {
        async getBook() {
            const id = Number(this.$route.params.id);
            let {data, answer} = await UseGetBook(id);
            if (answer.value) {
                this.product = data.value;
            }
        },
        getImg(path) {
            return require(`@/assets/image/${path ?? 'product.jpg'}`);
        },
        dateConvert(date) {
            return moment(date).format("YYYY-MM-DD")
        },
    }
}
</script>

<style lang="scss" scoped>
.product-border {
    width: 100%;
    .v-card {
        height: 100%;
    }
}
.text-date {
    align-content: center;
    flex-wrap: wrap;
    display: flex;
    font-size: 16px;
    padding-left: 15px;
}
.custom-btn {
    justify-content: flex-end;
    display: flex;
    width: 100%;
}
.popular-text {
    align-content: center;
    flex-wrap: wrap;
    display: flex;
    font-size: 16px;
    padding-left: 35px;
}
</style>