import axios from "axios";
import {ref} from 'vue';

export async function UseInsertBook(name, price, author, description, image, popular) {
    const message = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post('/moderator/insertBook', {
                name: name,
                price: price,
                author: author,
                description: description,
                image: image,
                popular: popular
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