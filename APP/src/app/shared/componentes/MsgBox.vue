<template>
    <transition-group name="p-messages" tag="div">
        <Message :severity="tipo" v-if="itensTemp.length > 0" @close="itensTemp = []">
            <ul>
                <li v-for="item in itensTemp" :key="item">{{ item }}</li>
            </ul>
        </Message>
    </transition-group>
</template>

<script>
export default {
    props: {
        itens: {
            type: Array,
            default: () => [],
        },

        tipo: {
            type: String,
            default: () => 'warn',
        },
    },

    data() {
        return {
            itensTemp: [],
        };
    },

    computed: {
        show() {
            return this.itensTemp.length > 0;
        },
    },

    watch: {
        itens() {
            this.itensTemp = this.itens;
        },
    },

    created() {
        this.itensTemp = this.itens;
    },
};
</script>
