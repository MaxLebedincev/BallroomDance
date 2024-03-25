<template>
    <v-container>
        <v-row>
            <v-col cols="2">
                <v-card class="card-menu">
                    <template #title>
                        Добавление
                    </template>
                    <v-tabs
                        v-model="tabOpt"
                        direction="vertical"
                        color="#dd0000"
                    >
                        <v-tab
                            v-if="role === 'admin'"
                            value="option-1"
                        >
                            <v-icon start>
                                mdi-account-plus
                            </v-icon>
                            <div class="tab-title">
                                клиента
                            </div>
                        </v-tab>
                        <v-tab
                            value="option-2"
                        >
                            <v-icon start>
                                mdi-book-plus
                            </v-icon>
                            книг
                        </v-tab>
                        <v-tab value="option-3">
                            <v-icon start>
                                mdi-bookmark-plus
                            </v-icon>
                            жанра
                        </v-tab>
                    </v-tabs>
                </v-card>
                <v-card class="card-menu">
                    <template #title>
                        Таблицы
                    </template>
                    <v-tabs
                        v-model="tabOpt"
                        direction="vertical"
                        color="#dd0000"
                    >
                        <v-tab
                            v-if="role === 'admin'"
                            value="option-4"
                            @click="getUsers()"
                        >
                            <v-icon start>
                                mdi-account
                            </v-icon>
                            клиентов
                        </v-tab>
                        <v-tab
                            value="option-5"
                            @click="getBooks()"
                        >
                            <v-icon start>
                                mdi-book
                            </v-icon>
                            книг
                        </v-tab>
                        <v-tab
                            value="option-6"
                            @click="getGenres()"
                        >
                            <v-icon start>
                                mdi-bookmark
                            </v-icon>
                            жанров
                        </v-tab>
                    </v-tabs>
                </v-card>
            </v-col>
            <v-col cols="10">
                <div>
                    <v-card class="info">
                        <v-window v-model="tabOpt">
                            <v-window-item v-if="role === 'admin'" value="option-1">
                                <v-card elevation="8">
                                    <template #title>
                                        Добавление пользователя
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-2">
                                <v-card elevation="4">
                                    <template #title>
                                        Добавление книги
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-3">
                                <v-card elevation="4">
                                    <template #title>
                                        Добавление жанра
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item v-if="role === 'admin'" value="option-4">
                                <v-card elevation="4" class="card-table">
                                    <template #title>
                                        Таблица пользователей
                                    </template>
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <thead>
                                            <tr>
                                                <td width="20%">
                                                    Логин
                                                </td>
                                                <td width="20%">
                                                    Почта
                                                </td>
                                                <td width="20%">
                                                    Роль
                                                </td>
                                                <td width="10%">
                                                    Дата добавления
                                                </td>
                                                <td width="10%">
                                                    Дата обновления
                                                </td>
                                                <td
                                                    width="20%"
                                                    class="text-right"
                                                ></td>
                                            </tr>
                                            </thead>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-5">
                                <v-card elevation="4" class="card-table">
                                    <template #title>
                                        Таблица книг
                                    </template>
                                    <template #text>
                                        <v-table>
                                            <thead>
                                            <tr style="padding: 0 1rem; display: table; text-align: center">
                                                <td width="25%">
                                                    Имя
                                                </td>
                                                <td width="15%">
                                                    Цена
                                                </td>
                                                <td width="25%">
                                                    Автор
                                                </td>
                                                <td width="10%">
                                                    Дата добавления
                                                </td>
                                                <td width="5%">
                                                    Оценка
                                                </td>
                                                <td
                                                    width="20%"
                                                    class="text-right"
                                                ></td>
                                            </tr>
                                            </thead>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-6">
                                <v-card elevation="4" class="card-table">
                                    <template #title>
                                        Таблица жанров
                                    </template>
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <thead>
                                            <tr>
                                                <td width="40%">
                                                    Имя
                                                </td>
                                                <td width="40%">
                                                    Картинка
                                                </td>
                                                <td
                                                    width="20%"
                                                    class="text-right"
                                                ></td>
                                            </tr>
                                            </thead>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                        </v-window>
                    </v-card>
                    <v-card class="content">
                        <v-window v-model="tabOpt">
                            <v-window-item v-if="role === 'admin'" value="option-1">
                                <v-card elevation="4" class="card-input">
                                    <template #text>
                                        <v-text-field
                                            label="Имя"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-text-field
                                            label="Пароль"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-text-field
                                            label="Email"
                                            hide-details="auto"
                                        ></v-text-field>
                                    </template>
                                    <template #actions>
                                        <v-btn width="170px" variant="outlined" class="card-button" @click="createAlert">
                                            Добавить
                                        </v-btn>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-2">
                                <v-card elevation="4" class="card-input">
                                    <template #text>
                                        <v-text-field
                                            label="Наименование"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-text-field
                                            label="Цена"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-select
                                            :modelValue="favorites"
                                            :items="states"
                                            label="Жанры"
                                            multiple
                                            persistent-hint
                                            hide-details="auto"
                                        ></v-select>
                                        <v-text-field
                                            label="Автор"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-textarea
                                            label="Описание"
                                            hide-details="auto"
                                        ></v-textarea>
                                        <v-file-input
                                            label="Изображение"
                                        ></v-file-input>
                                    </template>
                                    <template #actions>
                                        <v-btn width="170px" variant="outlined" class="card-button" @click="createAlert">
                                            Добавить
                                        </v-btn>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-3">
                                <v-card elevation="4" class="card-input">
                                    <template #text>
                                        <v-text-field
                                            label="Наименование"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-select
                                            :modelValue="favorites"
                                            :items="states"
                                            label="Картинки"
                                            multiple
                                            persistent-hint
                                            hide-details="auto"
                                        ></v-select>
                                    </template>
                                    <template #actions>
                                        <v-btn width="170px" variant="outlined" class="card-button" @click="createAlert">
                                            Добавить
                                        </v-btn>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item v-if="role === 'admin'" value="option-4">
                                <v-card elevation="4" class="card-table">
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <tbody>
                                            <tr
                                                v-for="item in users"
                                                :key="item.id"
                                            >
                                                <td width="20%">{{ item.login }}</td>
                                                <td width="20%">{{ item.email }}</td>
                                                <td width="20%">{{ selectRole(item.role) }}</td>
                                                <td width="10%">{{ dateConvert(item.registerDate) }}</td>
                                                <td width="10%">{{ dateConvert(item.updateDate) }}</td>
                                                <td width="20%" class="text-right">
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Редактировать
                                                    </v-btn>
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Удалить
                                                    </v-btn>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-5">
                                <v-card elevation="4" class="card-table">
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <tbody>
                                            <tr
                                                v-for="item in books"
                                                :key="item.id"
                                            >
                                                <td width="25%">{{ item.name }}</td>
                                                <td width="15%">{{ item.price }}</td>
                                                <td width="25%">{{ item.author }}</td>
                                                <td width="10%">{{ dateConvert(item.date) }}</td>
                                                <td width="5%">{{ item.popular }}</td>
                                                <td width="20%" class="text-right">
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Редактировать
                                                    </v-btn>
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Удалить
                                                    </v-btn>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-6">
                                <v-card elevation="4" class="card-table">
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <tbody>
                                            <tr
                                                v-for="item in genres"
                                                :key="item.id"
                                            >
                                                <td width="40%">{{ item.name }}</td>
                                                <td width="40%">{{ item.image ?? '' }}</td>
                                                <td width="20%" class="text-right">
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Редактировать
                                                    </v-btn>
                                                    <v-btn width="170px" variant="text" @click="createAlert">
                                                        Удалить
                                                    </v-btn>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </v-table>
                                    </template>
                                </v-card>
                            </v-window-item>
                        </v-window>
                    </v-card>
                </div>
            </v-col>
        </v-row>
    </v-container>
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
</template>

<script>
import moment from 'moment';
import {UseSelectBooks} from "@/hooks/data/get/useSelectBooks";
import {UseSelectGenres} from "@/hooks/data/get/useSelectGenres";
import {UseSelectUser} from "@/hooks/data/get/useSelectUser";

export default {
    name: "AdminView",
    data: ()=> ({
        tabOpt: 'option-2',
        favorites: [],
        books: [],
        genres: [],
        users: [],
        role: localStorage.getItem('role') ?? '',
        alert: false
    }),
    mounted() {
        this.tabOpt = 'option-2'
    },
    methods: {
        async getBooks() {
            let {data, answer} = await UseSelectBooks();
            if (answer.value) {
                this.books = data.value;
            }
        },
        async getGenres() {
            let {data, answer} = await UseSelectGenres();
            if (answer.value) {
                this.genres = data.value;
            }
        },
        async getUsers() {
            let {data, answer} = await UseSelectUser();
            if (answer.value) {
                this.users = data.value;
            }
        },
        dateConvert(date) {
            return moment(date).format("YYYY-MM-DD")
        },
        selectRole(role) {
            switch (role) {
                case 'admin':
                    return 'Админ'
                case 'client':
                    return 'Клиент'
                case 'moderator':
                    return 'Модератор'
            }
        },
        createAlert(){
            this.alert = true;
        }
    }
}
</script>

<style lang="scss">
.card-menu .v-btn {
    text-overflow: ellipsis;
}
.info {
    .card-table .v-card-text{
        padding: 0 ;
    }
}
.content  {
    .card-input .v-field__overlay {
        background-color: #FFFFFF;
    }
}
</style>
<style lang="scss" scoped>
.card-menu {
    margin-bottom: 25px;
}
.info {
    margin-bottom: 25px;
    .v-card-text{
        padding: 0 ;
    }
}
.content  {
    .card-button {
        margin-left: auto;
    }
    .card-table {
        height: 70vh !important;
        overflow-y: auto;
    }
}
</style>