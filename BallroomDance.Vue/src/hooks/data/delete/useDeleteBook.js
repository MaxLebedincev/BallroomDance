import axios from "axios";
import {ref} from 'vue';

export async function UseDeleteBook(id) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post('/moderator/deleteBook', {
                id: id
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