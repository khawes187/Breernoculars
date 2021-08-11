import axios from 'axios';

export default {
    addBeer(newBeer) {  
        return axios.post('/beer', newBeer);
    },
    
    deleteBeer(beerId) {  
        return axios.delete(`/beer/${beerId}`);
    }
}