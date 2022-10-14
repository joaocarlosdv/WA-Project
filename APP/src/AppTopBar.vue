<template>
    <div class="layout-topbar" v-if="exibir">
        <a class="menu-button" @click="$emit('menubutton-click')">
            <i class="pi pi-bars"></i>
        </a>
        <h4>Desafio E-commerce Dashboard - João Carlos Dantas Vieira</h4>
        <ul ref="topbarMenu" class="topbar-menu">
        </ul>
    </div>
</template>

<script>
export default {
    outsideClickListener: null,
    darkDemoStyle: null,
    
    props: {
        theme: null,
        exibir: Boolean
    },
}
</script>
