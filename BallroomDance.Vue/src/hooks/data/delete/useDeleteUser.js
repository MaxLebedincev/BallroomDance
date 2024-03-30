import axios from "axios";
import {ref} from 'vue';

export async function UseDeleteUser(id, role) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post('/admin/deleteUser', {
                id: id,
                role: role
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