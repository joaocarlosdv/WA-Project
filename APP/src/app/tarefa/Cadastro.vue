<template>
    <Button
        label="Adicionar"
        icon="pi pi-plus"
        class="p-button-rounded"
        @click="showDialog()"
        v-if="id==0"
    />
    <Button
        icon="pi pi-pencil"
        class="p-button-rounded p-button-text p-button-success"
        title="Editar"
        @click="showDialog()"
        v-if="id > 0"
    />

    <Dialog
        v-model:visible="display"
        no-close-on-backdrop
        :maximizable="false">

        <template #header>
            <h3>Tarefa</h3>
        </template>

        <div class="p-formgrid p-grid p-fluid">
            <div class="p-field p-lg-2 p-sm-12">
                <label>Id</label>
                <div class="p-inputgroup">
                    <InputText type="text" v-model="tarefa.id" disabled/>
                </div>
            </div>
            <div class="p-field p-lg-8 p-sm-12">
                <label>Descrição</label>
                <InputText type="text" v-model="tarefa.descricao" />
            </div>
            <div class="p-field-checkbox p-col-2" style="margin-top:2%">
                <label>Feito &nbsp;</label>
                <Checkbox :binary="true" v-model="ckFeito"/>
            </div>
        </div>

        <template #footer>
            <Button label="Salvar" @click="salvar()" :disabled="v$.$invalid"/>
            <Button label="Fechar" autofocus @click="closeDialog()"/>
        </template>
    </Dialog>
</template>

<script>
    import Services from './../../service/app/Tarefa.Service.js';
    import useVuelidate from '@vuelidate/core';
    import { required } from '@vuelidate/validators';

    export default {
        setup() {
            return { v$: useVuelidate() };
        },

        validations() {
            return {
                Descricao: {required}
            }
        },

        props: {
            id: {
                type: Number
            },
        },

        watch:{
            'tarefa.descricao'(){
                this.Descricao = null
                if (this.tarefa.descricao != ''){
                    this.Descricao = this.tarefa.descricao;
                }
            }
        },

        data() {
            return {
                display: false,
                Descricao:null,
                ckFeito: true,
                tarefa: {
                    id: 0,
                    descricao: '',
                    feito: false,
                },
            }
        },

        methods: {
            showDialog() {
                this.display = true
                this.Descricao = null
                this.ckFeito = true
                this.limparComponentes()

                if (this.id > 0){
                    this.selectById();
                }
            },

            limparComponentes(){
                this.tarefa.id = 0
                this.tarefa.descricao = ''
                this.tarefa.feito = false
                this.ckFeito = false
            },

            closeDialog(){
                this.display = false;
            },

            selectById(){
                Services.SelectById(this.id)
                .then((response)=>{
                    if (response) {
                        this.tarefa = response.data
                        this.ckFeito = response.data.feito == true
                    }
                })
            },

            salvar(){
                this.tarefa.feito = false
                if (this.ckFeito == true){
                    this.tarefa.feito = true
                }

                Services.Salvar(this.tarefa)
                .then((response)=>{
                    if (response) {
                        this.$emit('atualizarLista')
                        this.$toast.add({severity:'success', summary:'Salvo', detail:'Operação realizada com sucesso', life: 5000});
                    }
                })
                .catch((error) => {
                   console.log(error)
                   this.$toast.add({severity:'error', summary:'Erro', detail:'Erro ao Salvar', life: 5000});
                })

                this.closeDialog();
            }
        }
    }
</script>
