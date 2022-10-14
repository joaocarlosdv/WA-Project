<template>
    <div class="layout-wrapper" :class="containerClass">
        <app-topbar @menubutton-click="onMenuButtonClick" @change-theme="changeTheme" :theme="theme" :exibir="exibirMenus"/>
        <app-menu :active="sidebarActive" :exibir="exibirMenus"/>
        <div :class="['layout-mask', {'layout-mask-active': sidebarActive}]" @click="onMaskClick"></div>
        <div class="layout-content">
            <router-view/>
            <app-footer />
        </div>
        <Toast />
        <Toast position="top-left" group="tl" />
        <Toast position="bottom-left" group="bl" />
        <Toast position="bottom-right" group="br" />
    </div>
</template>

<script>
import DomHandler from '@/components/utils/DomHandler';
import AppTopBar from '@/AppTopBar.vue';
import AppMenu from '@/AppMenu.vue';
import AppFooter from '@/AppFooter.vue';

export default {
    data() {
        return {
            sidebarActive: true,
            exibirMenus: true,
        }
    },
    watch: {
        $route: {
            immediate: true,
            exibirMenus: false,
            handler(to) {
                let route = window.location.href.split('/#')[1];
                if (to.path === route) {
                    window['gtag']('config', 'UA-93461466-1', {
                        'page_path': '/primevue' + to.path
                    });
                    this.exibirMenus = true;
                }

                this.sidebarActive = false;
                DomHandler.removeClass(document.body, 'blocked-scroll');
                this.$toast.removeAllGroups();
            }
        }
    },

    computed: {
        containerClass() {
            return [{
                'layout-news-active': this.newsActive,
                'p-input-filled': this.$primevue.config.inputStyle === 'filled',
                'p-ripple-disabled': this.$primevue.config.ripple === false
            }];
        }
    },
    components: {
        'app-topbar': AppTopBar,
        'app-menu': AppMenu,
        'app-footer': AppFooter
    }
}
</script>

<style lang="scss">
@import './assets/styles/app/app.scss';
</style>
