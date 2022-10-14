const state = {
    loading: false,
    numeroRequests: 0
  }

  const mutations = {
    SET_LOADING (state, status) {
      state.loading = status
    },

    ADD_REQUEST (state) {
      state.numeroRequests++
      state.loading = (state.numeroRequests > 0)
    },

    REMOVE_REQUEST (state) {
      state.numeroRequests--
      state.loading = (state.numeroRequests > 0)
    }

  }

  const actions = {
    abrirLoading ({ commit }) {
      commit('SET_LOADING', true)
    },

    fecharLoading ({ commit }) {
      commit('SET_LOADING', false)
    },

    addRequest ({ commit }) {
      commit('ADD_REQUEST')
    },

    removeRequest ({ commit }) {
      commit('REMOVE_REQUEST')
    }
  }

  const getters = {
    loadingfull (state) {
      return state.loading
    }
  }

  export default {
    state,
    mutations,
    actions,
    getters
  }
