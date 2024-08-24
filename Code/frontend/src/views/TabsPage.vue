<template>
  <ion-page>
    <ion-tabs>
      <ion-router-outlet></ion-router-outlet>
      <ion-tab-bar class="py-2" slot="bottom">
        <ion-tab-button tab="map" href="/tabs/map">
          <ion-icon aria-hidden="true" :icon="mapOutline" />
          <ion-label>Map</ion-label>
        </ion-tab-button>
        
        <ion-tab-button tab="food" href="/tabs/food">
          <ion-icon aria-hidden="true" :icon="restaurantOutline" />
          <ion-label>Food</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="messages" href="/tabs/messages">
          <ion-icon aria-hidden="true" :icon="chatboxOutline" />
          <ion-label>Messages</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="user" href="/tabs/user">
          <ion-icon aria-hidden="true" :icon="personCircleOutline" />
          <ion-label>User</ion-label>
        </ion-tab-button>
      </ion-tab-bar>
    </ion-tabs>
  </ion-page>
</template>

<script setup lang="ts">
import { IonTabBar, IonTabButton, IonTabs, IonLabel, IonIcon, IonPage, IonRouterOutlet } from '@ionic/vue';
import { restaurantOutline, mapOutline, chatboxOutline, personCircleOutline } from 'ionicons/icons';
</script>
