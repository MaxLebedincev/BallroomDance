import axios from "axios";
import {ref} from 'vue';

const endpoint = '/User';

export async function UserGet() {
    const data = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(`${endpoint}/Get`);
            data.value = response.data;
            answer.value = true;
        } catch (e) {
            answer.value = false;
        }
    }
    await fetching();
    return {
        data, answer
    }
}

export async function UserCreate(login, password, email, role) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(`${endpoint}/Create`, {
                login: login,
                password: password,
                email: email,
                idUserRole: role
            }, {Authorization: `Bearer ${document.cookie.split('=')[1]}`});
            message.value = response.data.error ?? response.data.success;
            answer.value = true;
        } catch (e) {
            answer.value = false;
        }
    }
    await fetching();
    return {
        message, answer
    }
}

export async function UserDelete(id) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.delete(`${endpoint}/Delete/${id}`,
                {Authorization: `Bearer ${document.cookie.split('=')[1]}`});
            message.value = response.data.error ?? response.data.success;
            answer.value = true;
        } catch (e) {
            answer.value = false;
        }
    }
    await fetching();
    return {
        message, answer
    }
}

export async function UserEdit(item) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.put(`${endpoint}/Update/${item.id}`,
                {
                    IdUserRole: 1,
                    Login: item.login,
                    Email: item.email,
                },
                {Authorization: `Bearer ${document.cookie.split('=')[1]}`});
            message.value = response.data.error ?? response.data.success;
            answer.value = true;
        } catch (e) {
            answer.value = false;
        }
    }
    await fetching();
    return {
        message, answer
    }
}