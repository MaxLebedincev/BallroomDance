<template>
    <v-app-bar :elevation="2" class="px-3 custom-header">
        <template #title>
            <span style="color: #FFFFFF">
                Императорская библиотека
            </span>
        </template>
        <template #default>
            <v-tabs
                centered
                v-model="activeRoute"
                color="grey-darken-2"
            >
                <div v-for="link in routes"
                     :key="link">
                    <v-tab
                        @click="$router.push(link.link)"
                        v-if="link.role.includes(role)"
                    >
                        {{link.name}}
                    </v-tab>
                </div>
            </v-tabs>
        </template>
        <template #append>
            <v-switch
                v-model="isNotification"
                true-icon="mdi-bell-ring"
                false-icon="mdi-bell-off"
                width="50px"
                hide-details
                inset
            ></v-switch>
            <v-btn
                :icon="this.$store.state.inverse ? 'mdi-weather-sunny-off' : 'mdi-weather-sunny'"
                hide-details
                inset
                @click="toggleTheme"
            ></v-btn>
            <custom-authorization
                @updateRole="updateRole"
            ></custom-authorization>
            <v-avatar
                class="hidden-sm-and-down"
                color="grey-darken-1"
                size="48"
            ></v-avatar>
        </template>
        <template #image>
        </template>
    </v-app-bar>
</template>

<script>
import {useTheme} from "vuetify";
import CustomAuthorization from "@/components/CustomAuthorization";

export default {
    name: "CustomAppBar",
    components: {CustomAuthorization},
    setup () {
        const theme = useTheme()
        theme.global.name.value = localStorage.getItem("inverse") ?? 'light'
        return {
            theme,
            toggleTheme: () => {
                theme.global.name.value = theme.global.current.value.dark ? 'light' : 'dark'
                localStorage.setItem("inverse", theme.global.name.value)
            }
        }
    },
    data: () => ({
        dialog: false,
        isNotification: false,
        role: localStorage.getItem('role') ?? '',
        routes: [
            {
                id: 0,
                link: '/about',
                name: 'О нас',
                role: ['admin', 'moderator', 'client', '']
            },
            {
                id: 1,
                link: '/',
                name: 'Товары',
                role: ['admin', 'moderator', 'client', '']
            },
            {
                id: 2,
                link: '/admin',
                name: 'Админ панель',
                role: ['admin', 'moderator']
            },
            {
                id: 3,
                link: '/home',
                name: 'Личный кабинет',
                role: ['admin', 'moderator', 'client']
            }
        ],
        activeRoute: Number(localStorage.getItem('activeRoute')) ?? 1,
    }),
    watch: {
        activeRoute(active) {
            localStorage.setItem('activeRoute', active)
            this.activeRoute = active
        }
    },
    methods: {
        updateRole(role){

            if (!this.routes[this.activeRoute].role.includes(role)) {
                this.activeRoute = 1;
                this.$router.push('/');
            }

            this.role = role;
        }
    }
}
</script>


<style lang="scss" scoped>
.v-toolbar__append {
    div {
        margin: 0px 10px;
    }
}
.v-theme--dark .custom-header {
    background: rgb(255,0,0);
    background: linear-gradient(90deg, rgba(255,0,0,1) 6%, rgba(43,43,43,1) 47%);
}
.custom-header {
    background: rgb(255,0,0);
    background: linear-gradient(90deg, rgba(255,0,0,1) 6%, rgba(255, 255, 255, 1) 47%);
}
.custom-header .text-grey-darken-2 {
    color: #dd0000 !important;
}
</style>