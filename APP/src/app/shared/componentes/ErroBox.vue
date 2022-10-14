<template>
    <transition-group name="p-messages" tag="div">
        <Message :severity="tipo" v-if="errosTemp.length > 0" @close="errosTemp = []">
            <ul>
                <li v-for="erro in errosTemp" :key="erro">{{ erro }}</li>
            </ul>
        </Message>
    </transition-group>
</template>

<script>
export default {
    props: {
        erros: {
            type: Array,
            default: () => [],
        },

        tipo: {
            type: String,
            default: () => 'error',
        },
    },

    data() {
        return {
            errosTemp: [],
        };
    },

    computed: {
        show() {
            return this.errosTemp.length > 0;
        },
    },

    watch: {
        erros() {
            this.errosTemp = this.erros;
        },
    },

    created() {
        this.errosTemp = this.erros;
    },
};
</script>
