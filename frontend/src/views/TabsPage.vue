<template>
  <ion-page>
    <ion-tabs>
      <ion-router-outlet></ion-router-outlet>
      <!-- <ion-content>
        <ion-button class="p-4" @click="console.log('Hello')" expand="block">Click me</ion-button>
      </ion-content> -->
      <ion-tab-bar class="py-2" slot="bottom">
        <ion-tab-button tab="map" href="/tabs/map">
          <ion-icon aria-hidden="true" :icon="mapOutline" />
          <ion-label>Map</ion-label>
        </ion-tab-button>
        
        <ion-tab-button tab="foods" href="/tabs/foods">
          <ion-icon aria-hidden="true" :icon="pizzaOutline" />
          <ion-label>Foods</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="tab3" href="/tabs/messages">
          <ion-icon aria-hidden="true" :icon="chatboxOutline" />
          <ion-label>Messages</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="tab4" href="/tabs/user">
          <ion-icon aria-hidden="true" :icon="personCircleOutline" />
          <ion-label>User</ion-label>
        </ion-tab-button>
      </ion-tab-bar>
    </ion-tabs>
  </ion-page>
</template>

<script setup lang="ts">
import { IonTabBar, IonTabButton, IonTabs, IonLabel, IonIcon, IonPage, IonRouterOutlet } from '@ionic/vue';
import { pizzaOutline, mapOutline, chatboxOutline, personCircleOutline } from 'ionicons/icons';
</script>
