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
                                пользователя
                            </div>
                        </v-tab>
                        <v-tab
                            value="option-2"
                        >
                            <v-icon start>
                                mdi-book-plus
                            </v-icon>
                            группы
                        </v-tab>
                        <v-tab value="option-3">
                            <v-icon start>
                                mdi-bookmark-plus
                            </v-icon>
                            типа танцев
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
                            Пользователей
                        </v-tab>
                        <v-tab
                            value="option-5"
                            @click="getDanceGroups()"
                        >
                            <v-icon start>
                                mdi-book
                            </v-icon>
                            групп
                        </v-tab>
                        <v-tab
                            value="option-6"
                            @click="getGenres()"
                        >
                            <v-icon start>
                                mdi-bookmark
                            </v-icon>
                            танцев
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
                                        Добавление групп
                                    </template>
                                </v-card>
                            </v-window-item>
                            <v-window-item value="option-3">
                                <v-card elevation="4">
                                    <template #title>
                                        Добавление танцев
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
                                        Таблица групп
                                    </template>
                                    <template #text>
                                        <v-table>
                                            <thead>
                                            <tr style="padding: 0 1rem; display: table; text-align: center">
                                                <td width="60%">
                                                    Название
                                                </td>
                                                <td width="20%">
                                                    Дата создания
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
                                        Таблица танцев
                                    </template>
                                    <template #text>
                                        <v-table style="text-align: center">
                                            <thead>
                                            <tr>
                                                <td width="80%">
                                                    Название
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
                                            v-model="newUser.Login"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-text-field
                                            label="Пароль"
                                            v-model="newUser.Password"
                                            type="password"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-text-field
                                            label="Email"
                                            v-model="newUser.Email"
                                            hide-details="auto"
                                            type="email"
                                        ></v-text-field>
                                    </template>
                                    <template #actions>
                                        <v-btn width="170px" variant="outlined" class="card-button" @click="createUser">
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
                                            v-model="newGroup.Name"
                                            hide-details="auto"
                                        ></v-text-field>
                                        <v-date-picker
                                            label="Дата создания"
                                            v-model="newGroup.Created"
                                            hide-details="auto"
                                        ></v-date-picker>
                                    </template>
                                    <template #actions>
                                        <v-btn width="170px" variant="outlined" class="card-button" @click="createDanceGroup">
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
                                                <td width="20%">{{ selectRole(item.idUserRole) }}</td>
                                                <td width="10%">{{ dateConvert(item.created) }}</td>
                                                <td width="10%">{{ dateConvert(item.updated)}}</td>
                                                <td width="20%" class="text-right">
                                                    <v-btn width="170px" variant="text" @click="usetEditModal=true">
                                                        Редактировать
                                                    </v-btn>
                                                    <v-dialog
                                                        :model-value="usetEditModal"
                                                        width="auto"
                                                    >
                                                        <v-card>
                                                            <template #text>
                                                                <v-text-field
                                                                    label="Имя"
                                                                    v-model="item.login"
                                                                    hide-details="auto"
                                                                ></v-text-field>
                                                                <v-text-field
                                                                    label="Пароль"
                                                                    v-model="item.password"
                                                                    type="password"
                                                                    hide-details="auto"
                                                                ></v-text-field>
                                                                <v-text-field
                                                                    label="Email"
                                                                    v-model="item.email"
                                                                    hide-details="auto"
                                                                    type="email"
                                                                ></v-text-field>
                                                            </template>
                                                            <template #actions>
                                                                <v-btn width="170px" variant="outlined" class="card-button" @click="editUser(item)">
                                                                    Обновить
                                                                </v-btn>
                                                                <v-btn width="170px" variant="outlined" class="card-button" @click="usetEditModal = false">
                                                                    Закрыть
                                                                </v-btn>
                                                            </template>
                                                        </v-card>
                                                    </v-dialog>
                                                    <v-btn width="170px" variant="text" @click="deleteUser(item.id)">
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
                                                v-for="item in groups"
                                                :key="item.id"
                                            >
                                                <td width="60%">{{ item.name }}</td>
                                                <td width="20%">{{ dateConvert(item.created) }}</td>
                                                <td width="20%" class="text-right">
                                                    <v-btn width="170px" variant="text" @click="danceGroupEditModal = true">
                                                        Редактировать
                                                    </v-btn>
                                                    <v-dialog
                                                        :model-value="danceGroupEditModal"
                                                        width="auto"
                                                    >
                                                        <v-card>
                                                            <template #text>
                                                                <v-text-field
                                                                    label="Имя"
                                                                    v-model="item.Name"
                                                                    hide-details="auto"
                                                                ></v-text-field>
                                                                <v-date-picker
                                                                    label="Дата создания"
                                                                    v-model="item.Created"
                                                                    hide-details="auto"
                                                                ></v-date-picker>
                                                            </template>
                                                            <template #actions>
                                                                <v-btn width="170px" variant="outlined" class="card-button" @click="editDanceGroup(item)">
                                                                    Обновить
                                                                </v-btn>
                                                                <v-btn width="170px" variant="outlined" class="card-button" @click="danceGroupEditModal = false">
                                                                    Закрыть
                                                                </v-btn>
                                                            </template>
                                                        </v-card>
                                                    </v-dialog>
                                                    <v-btn width="170px" variant="text" @click="deleteDanceGroup">
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
    <v-dialog
        :model-value="alertSuccess"
        width="auto"
    >
        <v-card>
            <v-card-text>
                Запись добавлена!
            </v-card-text>
            <v-card-actions>
                <v-btn color="#dd0000" block @click="alertSuccess = false">Закрыть</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
    <v-dialog
        :model-value="alertFailed"
        width="auto"
    >
        <v-card>
            <v-card-text>
                Произошла ошибка!
            </v-card-text>
            <v-card-actions>
                <v-btn color="#dd0000" block @click="alertFailed = false">Закрыть</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
    <v-dialog
        :model-value="alertDelete"
        width="auto"
    >
        <v-card>
            <v-card-text>
                Запись удалена!
            </v-card-text>
            <v-card-actions>
                <v-btn color="#dd0000" block @click="alertDelete = false">Закрыть</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
    <v-dialog
        :model-value="alertUpdate"
        width="auto"
    >
        <v-card>
            <v-card-text>
                Запись изменена!
            </v-card-text>
            <v-card-actions>
                <v-btn color="#dd0000" block @click="alertUpdate = false">Закрыть</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
import moment from 'moment';
import {UseSelectBooks} from "@/hooks/data/get/useSelectBooks";
import {UseSelectGenres} from "@/hooks/data/get/useSelectGenres";
import {UserCreate, UserDelete, UserEdit, UserGet} from "@/hooks/endpoint/user";
import {DanceGroupCreate, DanceGroupDelete, DanceGroupEdit, DanceGroupGet} from "@/hooks/endpoint/danceGroup";

export default {
    name: "AdminView",
    data: ()=> ({
        tabOpt: 'option-2',
        favorites: [],
        books: [],
        users: [],
        groups: [],

        role: localStorage.getItem('role') ?? '',
        alert: false,
        alertSuccess: false,
        alertFailed: false,
        alertDelete: false,
        alertUpdate: false,

        usetEditModal: false,
        danceGroupEditModal: false,

        newUser: {
            IdUserRole: 1,
            Login: null,
            Email: null,
            Password: null
        },
        newGroup: {
            RussiaTrainerBallroomDanceId: 1,
            Name: null,
            Created: null
        }
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
            let {data, answer} = await UserGet();
            if (answer.value) {
                this.users = data.value;
            }
        },
        async createUser() {
            let result = await UserCreate(this.newUser.Login, this.newUser.Password, this.newUser.Email, this.newUser.IdUserRole);
            if (result) {
                this.newUser = {
                    IdUserRole: 1,
                    Login: null,
                    Email: null,
                    Password: null
                };
                this.createAlertSuccess();
            }
            else {
                this.createAlertFailed();
            }
        },
        async deleteUser(id) {
            let result = await UserDelete(id);
            if (result) {
                await this.getUsers();
                this.createAlertDelete();
            }
            else {
                this.createAlertFailed();
            }
        },
        async editUser(item) {
            let result = await UserEdit(item);
            if (result) {
                await this.getUsers();
                this.createAlertUpdate();
            }
            else {
                this.createAlertFailed();
            }
        },

        async getDanceGroups() {
            let {data, answer} = await DanceGroupGet();
            if (answer.value) {
                this.groups = data.value;
            }
        },
        async createDanceGroup() {
            let result = await DanceGroupCreate(this.newGroup.Name, this.newGroup.Created);
            if (result) {
                this.newGroup = {
                    Name: null,
                    Created: null
                };
                this.createAlertSuccess();
            }
            else {
                this.createAlertFailed();
            }
        },
        async deleteDanceGroup(id) {
            let result = await DanceGroupDelete(id);
            if (result) {
                await this.getDanceGroups();
                this.createAlertDelete();
            }
            else {
                this.createAlertFailed();
            }
        },
        async editDanceGroup(item) {
            let result = await DanceGroupEdit(item);
            if (result) {
                await this.getUsers();
                this.createAlertUpdate();
            }
            else {
                this.createAlertFailed();
            }
        },


        dateConvert(date) {
            return (date) ? moment(date).format("YYYY-MM-DD") : '-';
        },
        selectRole(role) {
            switch (role) {
                case 1:
                    return 'Админ'
                case 2:
                    return 'Клиент'
            }
        },
        createAlert(){
            this.alert = true;
        },
        createAlertSuccess(){
            this.alertSuccess = true;
        },
        createAlertFailed(){
            this.alertFailed = true;
        },
        createAlertDelete(){
            this.alertDelete = true;
        },
        createAlertUpdate(){
            this.alertUpdate = true;
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
        padding: 0px;
    }
}
</style>