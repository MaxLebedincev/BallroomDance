import axios from "axios";
import {ref} from 'vue';

export async function UseGetBooks(upParm, filterSelect, filterCheckboxs, pageNumber, name ='') {
    const data = ref([])
    const answer = ref(false)
    const fetching = async () => {
        try {
            const response = await axios.post(
                '/user/getBooks',
                {
                    isUp: upParm,
                    isPopular: filterSelect,
                    name: name,
                    genres: filterCheckboxs,
                    page: pageNumber
                });
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