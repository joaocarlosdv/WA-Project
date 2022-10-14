import axios from 'axios';

const api = `${process.env.VUE_APP_API_URL}${process.env.VUE_APP_API_PORT}${process.env.VUE_APP_API_PATH}`;
const urlBase = `${api}/tarefa`;

export default {
    SelectAll(){
        console.log(urlBase)
        return axios.get(`${urlBase}/selectall`)
            .then(response => {
                return response.data
            });
    },

    SelectById(id){
        return axios.get(
            `${urlBase}/selectbyid/${id}`
        );
    },

    Salvar(obj){
        return axios.post(`${urlBase}/save`, obj)
            .then((response) => {
                return response.data
        })
    },

    Deletar(id){
        return axios.get(
            `${urlBase}/delete/${id}`
        );
    },

    Login(login, senha){
        return axios.get(
            `${urlBase}/Login/${login}/${senha}`
        );
    }
}
