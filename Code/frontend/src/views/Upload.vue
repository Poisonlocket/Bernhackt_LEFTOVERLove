<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Share your leftover food</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <FilePickerComponent/>
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title color="primary" size="large">Share</ion-title>
        </ion-toolbar>
      </ion-header>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonToolbar, IonTitle, IonContent } from '@ionic/vue';
import FilePickerComponent from "@/components/FilePicker.vue";
</script>
