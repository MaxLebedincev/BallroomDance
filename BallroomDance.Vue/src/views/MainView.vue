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
                        @click="getData(isPopularity, filterSort, page, inputSearch)"
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
            <v-col cols="12" class="container">
                <v-container class="content max-width">
                    <v-table>
                        <thead>
                            <tr style="text-align: center">
                                <td width="60%">
                                    Название
                                </td>
                                <td width="40%">
                                    Дата создания
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr
                                v-for="item in groups"
                                :key="item.id"
                                style="text-align: center"
                            >
                                <td width="60%">{{ item.name }}</td>
                                <td width="40%">{{ dateConvert(item.created) }}</td>
                            </tr>
                        </tbody>
                    </v-table>
                </v-container>
                <div class="container-pagination">
                    <v-pagination
                        class="pagination"
                        v-model="page"
                        :length="countPage"
                        :update="getData(isPopularity, filterSort, page, inputSearch)"
                    ></v-pagination>
                </div>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import {DanceGroupGet} from "@/hooks/endpoint/danceGroup";
import moment from "moment";

export default {
    name: "MainView",
    data: ()=> ({
        inputSearch: '',
        isPopularity: true,
        page: 1,
        countPage: 1,
        filterSort: 'дате добавления',
        filterOptions: ['дате добавления', 'рейтингу'],
        selectTag: [],
        tags: null,
        groups: [],
        text: 'isi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
    }),
    mounted() {
        this.getData(false, false, 1, '')
    },
    methods: {
        getIcon(value) {
            return value ? 'mdi-trending-up' : 'mdi-trending-down';
        },
        setPopularity() {
            this.isPopularity = !this.isPopularity;
        },
        dateConvert(date) {
            return (date) ? moment(date).format("YYYY-MM-DD") : '-';
        },
        async getData(upParm, filterSelect, pageNumber, name) {

            if (filterSelect === 'рейтингу') {
                filterSelect = true
            } else {
                filterSelect = false
            }

            let request = {
                Offset: pageNumber,
                Number: 10,
                Name: name
            }

            let {data, answer} = await DanceGroupGet(request)

            if (answer.value) {

                console.log(data.value.list);
                console.log(data.value.count);

                this.groups = data.value.list;
                this.countPage = data.value.count;
                if (this.countPage === 0) {
                    this.countPage = 1;
                }
                if (this.page > this.countPage ){
                    this.page = this.countPage;
                }
            } else {
                this.groups  = []
                this.countPage = 1
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
