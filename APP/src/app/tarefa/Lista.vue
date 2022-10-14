<template>
    <div class="p-grid">
        <div class="p-col-12">
            <div class="card">
                <div class="p-d-flex">
                    <h5>Tarefas</h5>
                </div>

                <tabela
                    :data="lista"
                    :rows="10"
                >
                    <template #botoes>
                        <Cadastro
                            @atualizarLista="listar()"
                            :id="0"
                        >
                        </Cadastro>
                    </template>
                    <template #conteudo>
                        <Column headerStyle="width: 10em" header="Operações">
                            <template #body="slotProps">
                                <Cadastro
                                    @atualizarLista="listar()"
                                    :id="slotProps.data.id"
                                >
                                </Cadastro>
                                <Button
                                    icon="pi pi-trash"
                                    class="p-button-rounded p-button-text p-button-danger"
                                    title="Excluir"
                                    @click="Excluir(slotProps.data.id)"
                                />
                            </template>
                        </Column>
                        <Column headerStyle="width: 10em" field="id" header="Id" :sortable="true">
                            <template #body="slotProps">
                                {{ slotProps.data.id }}
                            </template>
                        </Column>
                        <Column field="descricao" header="Descrição" :sortable="true">
                            <template #body="slotProps">
                                {{ slotProps.data.descricao }}
                            </template>
                        </Column>
                        <Column field="feito" header="Feito" :sortable="true">
                            <template #body="slotProps">
                                <InputSwitch v-model="slotProps.data.feito" @click="marcar(slotProps.data)"/>
                            </template>
                        </Column>
                    </template>
                </tabela>
            </div>
        </div>
    </div>

    <ConfirmDialog></ConfirmDialog>
</template>

<script>
    import Services from './../../service/app/Tarefa.Service.js';
    import Cadastro from './Cadastro.vue';

    export default {
        components: {
            Cadastro
        },

        data() {
            return {
                lista:[],
            };
        },

        mounted() {
            this.listar();
        },

        methods: {
            marcar(tarefa){
                tarefa.feito = !tarefa.feito

                Services.Salvar(tarefa)
                .then((response)=>{
                    if (response) {
                        this.listar()
                        this.$toast.add({severity:'success', summary:'Salvo', detail:'Operação realizada com sucesso', life: 5000});
                    }
                })
                .catch((error) => {
                   console.log(error)
                   this.$toast.add({severity:'error', summary:'Erro', detail:'Erro ao Salvar', life: 5000});
                })
            },

            listar(){
                Services.SelectAll()
                .then((response)=>{
                    this.lista = null
                    if (response) {
                        this.lista = response
                    }
                })
            },

            Excluir(id){
                this.$confirm.require({
                    message: 'Confirma a Exclusão?',
                    header: 'Confirmação',
                    icon: 'pi pi-exclamation-triangle',
                    acceptLabel: 'Sim',
                    rejectLabel: 'Não',
                    accept: () => {

                        Services.Deletar(id)
                        .then((response)=>{
                            if (response) {
                                this.listar()
                            }
                        });

                        this.$toast.add({severity:'success', summary:'Deletado', detail:'Operação realizada com sucesso', life: 5000});
                    },
                    reject: () => {
                        this.$toast.add({severity:'error', summary:'Registro não deletado', detail:'Operação cancelada pelo usuário', life: 5000});
                    }
                });
            },
        },
    }
</script>
