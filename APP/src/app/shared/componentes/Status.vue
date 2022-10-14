<template>
    <!--Tag :class="`status-${status?.textoNormalizado().replace(/\s+/g, '')}`">{{ status }}</Tag-->
    <Tag class="p-mr-2" :severity="variant">{{ status }}</Tag>
</template>

<script>
export default {
    props: {
        status,
    },

    data(){
       return {
            statusPrimary: [
                'ATIVO',
                'ATIVA',
            ],
            statusInfo: [
                'CADASTRADO',
                'CADASTRADA',
            ],
            statusSuccess: [
                'PROCESSADO',
                'PROCESSADA',
            ],
            statusWarning: [
                'ENCERRADO',
                'ENCERRADA',
            ],
            statusDanger: [
                'CANCELADO',
                'CANCELADA',
            ],
       }
    },

    computed: {
        variant() {
            if (this.statusPrimary.filter((item) => {return item === this.status}).length > 0)
            {
                return 'primary'
            }
            else if (this.statusInfo.filter((item) => {return item === this.status}).length > 0
            ) {
                return 'info'
            }
            else if (this.statusSuccess.filter((item) => {return item === this.status}).length > 0
            ) {
                return 'success'
            }
            else if (this.statusWarning.filter((item) => {return item === this.status}).length > 0
            ) {
                return 'warning'
            }
            else if (this.statusDanger.filter((item) => {return item === this.status}).length > 0
            ) {
                return 'danger'
            }
            else {
                return ''
            }
        }
    }
};
</script>
