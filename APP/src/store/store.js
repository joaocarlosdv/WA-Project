//import Vue from 'vue'
import Vuex from 'vuex'
import loading from './loading'
import loginUser from './loginUser'

//Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
      recarregar: false,
      requestErro: ''
    },

    mutations: {

      UPDATE_RECARREGAR (state, status) {
        state.recarregar = status
      },

      SET_REQUEST_ERROR (state, error) {
        state.requestErro = error
      }
    },

    actions: {

      setRecarregar ({ commit }, status) {
        commit('UPDATE_RECARREGAR', status)
      },

      setRequestError ({ commit }, error) {
        commit('SET_REQUEST_ERROR', error)
      }
    },

    getters: {

      recarregar (state) {
        return state.recarregar
      },

      requestErro (state) {
        return state.requestErro
      }
    },

    modules: {
      loading,
      loginUser
    }
  })
