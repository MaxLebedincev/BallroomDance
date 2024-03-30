import axios from "axios";
import {ref} from 'vue';

const endpoint = '/TypeBallroomDance';

export async function TypeBallroomDanceGet() {
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

export async function TypeBallroomDanceCreate(name) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(`${endpoint}/Create`, {
                Name: name,
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

export async function TypeBallroomDanceDelete(id) {
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

export async function TypeBallroomDanceEdit(item) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.put(`${endpoint}/Update/${item.id}`,
                {
                    Name: item.name,
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