import axios from 'axios';

export default {
    addBeer() {  
        return axios.post('/brewery');
    },
    
    deleteBeer(beerId) {  
        return axios.delete(`/beer/${beerId}`);
    }
}