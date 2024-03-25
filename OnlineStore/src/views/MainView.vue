<template>
    <v-container class="page">
        <v-row class="search">
            <v-col cols="9">
                <div class="search-input">
                    <v-text-field
                        v-model="inputSearch"
                        density="default"

                    ></v-text-field>
                    <v-btn
                        size="56px"
                        prepend-icon="mdi-magnify"
                        variant="tonal"
                        @click="getData(isPopularity, filterSort, selectTag, page, inputSearch)"
                    ></v-btn>
                    <v-btn
                        class="switch-popularity"
                        size="56px"
                        variant="tonal"
                        :prepend-icon="getIcon(isPopularity)"
                        @click="setPopularity"
                    ></v-btn>
                </div>
            </v-col>
            <v-col cols="3">
                <v-select
                    label="Сортировка по"
                    :items="filterOptions"
                    v-model="filterSort"
                    variant="solo"
                ></v-select>
            </v-col>
        </v-row>
        <v-row class="product">
            <v-col cols="9" class="container">
                <v-container class="content max-width">
                    <custom-card
                        v-for="book in books"
                        :key="book.id"
                        :modelValue="book"
                        height="300px"
                        width="200px"
                    >
                    </custom-card>
                </v-container>
                <div class="container-pagination">
                    <v-pagination
                        class="pagination"
                        v-model="page"
                        :length="countPage"
                        :update="getData(isPopularity, filterSort, selectTag, page, inputSearch)"
                    ></v-pagination>
                </div>
            </v-col>
            <v-col cols="3" class="filter">
                <div class="box-color">
                    <div
                        class="filter-card"
                    >
                        <v-checkbox
                            class="filter-card__elem"
                            v-for="(tag, index) in tags"
                            :key="index"
                            v-model="selectTag"
                            :label="tag.name"
                            :value="tag.id"
                        ></v-checkbox>
                    </div>
                </div>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import CustomCard from "@/components/CustomCard";
import {UseGetBooks} from "@/hooks/data/get/useGetBooks";
import {UseGetGenres} from "@/hooks/data/get/useGetGenres";

export default {
    name: "MainView",
    components: {CustomCard},
    data: ()=> ({
        inputSearch: '',
        isPopularity: true,
        page: 1,
        countPage: 1,
        filterSort: 'дате добавления',
        filterOptions: ['дате добавления', 'рейтингу'],
        selectTag: [],
        tags: null,
        books: [],
        text: 'isi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
    }),
    mounted() {
        this.getGenres();
        this.getData(false, false, [], 1, '')
    },
    methods: {
        getIcon(value) {
            return value ? 'mdi-trending-up' : 'mdi-trending-down';
        },
        setPopularity() {
            this.isPopularity = !this.isPopularity;
        },
        async getData(upParm, filterSelect, filterCheckboxs, pageNumber, name) {

            if (filterSelect === 'рейтингу') {
                filterSelect = true
            } else {
                filterSelect = false
            }

            let {data, answer} = await UseGetBooks(upParm, filterSelect, filterCheckboxs, pageNumber, name)

            if (answer.value) {
                this.books = data.value.books;
                this.countPage = data.value.countPage;
                if (this.countPage === 0) {
                    this.countPage = 1;
                }
                if (this.page > this.countPage ){
                    this.page = this.countPage;
                }
            } else {
                this.books = []
                this.countPage = 1
            }
        },
        async getGenres() {
            let {genres, answer} = await UseGetGenres();

            if (answer.value) {
                this.tags = genres.value
            } else {
                this.tags = []
            }
        }
    }
}
</script>

<style lang="scss" scoped>
.page{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 100%;
    .search{
        height: 10%;
        align-content: center;
        .search-input {
            display: flex;
            .switch-popularity {
                margin: 0px 0px 0px 25px;
            }
        }
    }
    .product {
        height: 90%;

        .container{
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            .content{
                display: grid;
                grid-template-columns: repeat(auto-fill, minmax(200px,auto));
                grid-row-gap: 10px;
                &-card{

                }
            }
            .pagination {
                box-shadow: 0px 1px 4px -1px;
            }
        }
        .box-color {
            box-shadow: 0px 1px 4px -1px;
            height: 500px;
            overflow: hidden;
            overflow-y: auto;
            .filter{
                padding: 0px 0px 0px 15px;
                &-card{
                    width: 100%;
                    &__elem {
                        margin: 3px 3px;
                        display: inline-flex;
                    }
                }
            }
        }
    }
}
.v-theme--dark .pagination {
    background-color: #212121 !important;
    box-shadow: 0px 0px 0px 0px !important;
}
.v-theme--dark .box-color {
    background-color: #212121 !important;
    box-shadow: 0px 0px 0px 0px !important;
}
</style>
