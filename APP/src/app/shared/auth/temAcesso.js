import {
    store
} from '@/store/store'
import router from '@/router'
//import VueJwtDecode from 'vue-jwt-decode'

export function temAcesso(regra) {
    if (!store.getters.estaAutenticado) {
        store.dispatch('tryAutoLogin')
        if (!store.getters.estaAutenticado) {
            router.push('/login')
            return false
        }
    }
    //let decodedToken = VueJwtDecode.decode(store.getters.getToken)
    //let regrasEncoded = decodedToken.usrRegras
    //let regras = atob(regrasEncoded)
    let regras = this.$store.getters.transacoes
    if (typeof (regra) === 'object') {
        if (regra.length > 0) {
            if (regra.every((item) => {
                    return (regras.indexOf(item.codigo) === -1)
                })) {
                return false
            }
        }
        return true
    } else {
        if (regra) {
            if (regras.indexOf(regra) === -1) {
                return false
            }
        }
        return true
    }
}
