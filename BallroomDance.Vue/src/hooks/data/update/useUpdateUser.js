import axios from "axios";
import {ref} from 'vue';

export async function UseUpdateUser(login, password, email, role, id) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post('/admin/updateUser', {
                login: name,
                password: password,
                email: email,
                role: role,
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