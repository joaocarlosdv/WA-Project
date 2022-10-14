<template>
    <div class="p-grid p-nogutter p-mb-2" v-if="$mq == 'xl'">
        <div class="p-col-fixed p-mr-2" :style="`width: ${size}px`">
            <div class="p-text-right titulo">
                <strong>{{ titulo }}</strong>
            </div>
        </div>
        <div class="p-col">
            <div>
                <strong><slot></slot></strong>
            </div>
        </div>
    </div>
    <div class="p-grid p-nogutter p-mb-2" v-if="$mq != 'xl'">
        <div class="p-col-3 p-mb-1">
            <div class="p-text-right titulo">
                <strong>{{ titulo }} &nbsp;</strong>
            </div>
        </div>
        <div class="p-col-9" >
            <div>
                <strong><slot></slot></strong>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        titulo: {
            type: String,
        },

        size: {
            type: String,
            default: '100',
        },
    },
};
</script>

<style scoped>
.titulo {
    color: #0f97c7;
}

.dado {
    float: right;
}
</style>
