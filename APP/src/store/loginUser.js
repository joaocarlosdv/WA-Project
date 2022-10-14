//import Vue from 'vue'
import router from '@/router'
import moment from 'moment'
import appMenu from "../router/index";
import {
    authNav
} from "../app/shared/auth/temAcesso";

const state = {
    token: null,
    expirationDate: null,
    usuario: {
        id: null,
        nome: null,
        email: null,
        login: null,
        ativo: null
    },
    transacoes: [],
    grupos: []
}

const mutations = {

    SET_USUARIO(state, auth) {
        //let decodedToken = Vue.$jwt.decode(localStorage.token)

        state.token = auth.token
        state.usuario.id = auth.usuario.id
        state.usuario.nome = auth.usuario.nome
        state.usuario.email = auth.usuario.email
        state.usuario.ativo = auth.usuario.ativo
        state.usuario.login = auth.usuario.login
        state.transacoes = auth.transacoes
        state.grupos = auth.grupos
    },

    REMOVE_USUARIO(state) {
        state.token = null
        state.usuario.id = null
        state.usuario.nome = null
        state.usuario.email = null
        state.usuario.ativo = null
        state.usuario.login = null
        state.transacoes = null
        state.grupos = null

        localStorage.removeItem('token')
        localStorage.removeItem('userId')
        localStorage.removeItem('expirationDate')
        router.push('/login')
    },

    ATUALIZAR_MENU(state) {
        //state.transacoes = authNav(appMenu.items)
        console.log(authNav)
        console.log(appMenu)
        console.log(state)
    }
}

const actions = {

    login({
        commit,
        dispatch,
        state
    }, authData) {

        //console.log('authData', authData)

        let tFim = new Date(authData.dataExpiracao)
        let tInicio = new Date(authData.dataCriacao)
        let tempoExpirar = tFim.getTime() - tInicio.getTime()
        let agora = moment(new Date())
        let localExpiraEm = agora.add(tempoExpirar, 'ms')
        
        commit('SET_USUARIO', {
            token: authData.token,
            time: localExpiraEm,
            usuario: authData.usuario,
            transacoes: authData.transacoes,
            grupos: authData.grupos
        })

        localStorage.setItem('token', authData.token)
        localStorage.setItem('userId', state.usuario.id)
        localStorage.setItem('expirationDate', localExpiraEm)
        dispatch('atualizarMenu')
    },

    logout({
        commit
    }) {
        commit('REMOVE_USUARIO')
    },

    tryAutoLogin({
        commit,
        dispatch
    }) {
        const token = localStorage.getItem('token')
        if (!token) {
            return
        }
        const expirationDate = new Date(localStorage.getItem('ExpirationDate'))
        const now = new Date()
        if (now >= expirationDate) {
            commit('REMOVE_USUARIO')
            return
        }
        commit('SET_USUARIO', {
            token: token,
            time: expirationDate
        })
        dispatch('atualizarMenu')
    },

    atualizarMenu({
        commit
    }) {
        commit('ATUALIZAR_MENU')
    }
}

const getters = {

    usuario(state) {
        return state.usuario
    },

    grupos(state) {
        return state.grupos
    },

    transacoes(state) {
        return state.transacoes
    },

    estaAutenticado(state) {
        if (state.usuario.ativo === 'True') {
            //router.push('/atualizarsenha')
        }
        return state.token !== null
    },

    getToken(state) {
        return state.token
    },

    menu(state) {
        return state.menu
    },

    getExpirationDate(state) {
        return state.expirationDate
    }

}

export default {
    state,
    mutations,
    actions,
    getters
}
