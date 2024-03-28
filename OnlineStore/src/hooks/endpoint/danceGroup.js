import axios from "axios";
import {ref} from 'vue';

const endpoint = '/DanceGroup';

export async function DanceGroupGet() {
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

export async function DanceGroupCreate(name, created) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(`${endpoint}/Create`, {
                RussiaTrainerBallroomDanceId: 1,
                Name: name,
                Created: created
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

export async function DanceGroupDelete(id) {
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

export async function DanceGroupEdit(item) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.put(`${endpoint}/Update/${item.id}`,
                {
                    RussiaTrainerBallroomDanceId: 1,
                    Name: item.Name,
                    Created: item.Created,
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