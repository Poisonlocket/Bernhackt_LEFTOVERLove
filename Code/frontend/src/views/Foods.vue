<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Foods</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title color="primary" size="large">Foods</ion-title>
          <ion-subtitle class="p-4 text-xl text-neutral-400">Check available food items</ion-subtitle>
        </ion-toolbar>
      </ion-header>

      <!-- Cardlist Fooditems -->
      <CardList />
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonToolbar, IonTitle, IonContent } from '@ionic/vue';
import CardList from '@/components/CardList.vue';
</script>
