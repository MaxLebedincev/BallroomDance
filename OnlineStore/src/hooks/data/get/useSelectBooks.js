import axios from "axios";
import {ref} from 'vue';

export async function UseSelectBooks() {
    const data = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {

            const response = await axios.post('/moderator/selectBooks');
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