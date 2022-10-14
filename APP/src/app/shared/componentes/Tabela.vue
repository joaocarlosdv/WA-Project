<template>
    <DataTable
        :value="data"
        :paginator="true"
        :rows="5"
        :dataKey="dataKey"
        :rowHover="true"
        v-model:filters="filters"
        :autoLayout="true"
        :globalFilterFields="globalFilterFields"
        :rowsPerPageOptions="[5, 10, 20, 50, 100]"
        @filter="filterCallBack($event)"
        filterDisplay="menu"
        paginatorTemplate="CurrentPageReport FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink RowsPerPageDropdown"
        currentPageReportTemplate="Mostrando {first} até {last} de {totalRecords}"
        stripedRows
        responsiveLayout="scroll"
        stateStorage="local"
        :stateKey="stateKey"
    >
        <template #header>
            <div class="table-header p-d-flex p-flex-column p-flex-md-row p-jc-md-between">
                <span class="p-input-icon-left" v-if="mostrarPesquisa">
                    <i class="pi pi-search" />
                    <InputText v-model="filters['global'].value" placeholder="Pesquisar..." />
                </span>
                <div class="p-d-flex p-flex-column p-flex-md-row">
                    <slot name="botoes"></slot>
                </div>
            </div>
        </template>
        <template #empty> Não exitem registros para exibição. </template>
        <slot name="conteudo"></slot>
    </DataTable>
</template>

<script>
import { FilterMatchMode } from 'primevue/api';

export default {
    props: {
        data: {
            type: Array,
        },

        dataKey: {
            type: String,
        },

        globalFilterFields: {
            type: Array,
        },

        mostrarPesquisa: {
            type: Boolean,
            default: () => true,
        },

        filtersProp: {
            type: Object,
            default: () => null,
        },

        filterCallBack: {
            type: Function,
            default: () => null,
        },

        stateKey: {
            type: String,
            default: () => 'dt-padrao',
        },
    },

    data() {
        return {
            filtersLocal: {
                global: { value: null, matchMode: FilterMatchMode.CONTAINS },
            },
            filters: null,
        };
    },

    created() {
        if (this.filtersProp) {
            this.filters = this.filtersProp;
        } else {
            this.filters = this.filtersLocal;
        }
    },

    watch: {
        filtersProp() {
            this.filters = this.filtersProp;
        },
    },
};
</script>

<style lang="scss" scoped>
::v-deep(.p-paginator) {
    .p-paginator-current {
        margin-left: auto;
    }
}
</style>
