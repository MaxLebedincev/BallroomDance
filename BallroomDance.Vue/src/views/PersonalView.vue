<template>
    <v-container class="fill-height">
        <v-row>
            <v-col cols="4">
                <v-card
                    elevation="4"
                    height="100%"
                >
                    <template #title>
                        <div class="user-title">
                            {{profileName}}
                        </div>
                    </template>
                    <template #image>
                        <v-avatar
                            class="user-avatar"
                            color="grey-darken-1"
                            size="100px"
                        ></v-avatar>
                    </template>
                </v-card>
            </v-col>
            <v-col cols="8">
                <v-card
                    title="Информация о вас"
                    elevation="4"
                >
                    <template #text>
                        <div class="description">
                            <ul>
                                <li>Ваш login: {{profileName}}</li>
                                <li>Ваш e-mail: {{profileEmail}}</li>
                                <li>Ваша роль: {{profileRole}}</li>
                            </ul>
                            <div class="description-text">

                            </div>
                        </div>
                    </template>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name: "PersonalView",
    data: () => ({
        profileName: localStorage.getItem('login') ?? 'User',
        profileEmail: localStorage.getItem('email') ?? 'test@mail.ru',
        profileRole: ''
    }),
    mounted() {
        const role = localStorage.getItem('role') ?? ''
        this.profileRole = this.selectRole(role);
    },
    methods: {
        selectRole(role) {
            switch (role) {
                case 'admin':
                    return 'Админ'
                case 'client':
                    return 'Клиент'
                case 'moderator':
                    return 'Модератор'
            }
            return ''
        },
    }
}
</script>

<style lang="scss" scoped>
.user-title{
    text-align: center;
}
.user-avatar{
    margin: auto;
}
.description {
    padding: 15px;
    li {
        padding-top: 5px;
    }
    &-text{
        padding-top: 20px;
    }
}
</style>