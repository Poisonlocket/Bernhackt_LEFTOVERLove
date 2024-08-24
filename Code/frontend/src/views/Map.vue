<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Map</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title color="primary" size="large">Map</ion-title>
        </ion-toolbar>
      </ion-header>

      <ion-content>
        <Map :markerData="markerData" />
      </ion-content>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonToolbar, IonTitle, IonContent } from '@ionic/vue';
import Map from '@/components/Map.vue';

const markerData = [
  {
    coordinate: { lat: 46.94227090555359, lng: 7.440744738280579 },
    title: "First Item",
    snippet: "title one snippet content will be presented here",
  },
  {
    coordinate: { lat: 46.960253240769944, lng: 7.460482860907267 },
    title: "Second Item",
    snippet: "another short text",
  },
  {
    coordinate: { lat: 46.97021442933564, lng: 7.432154173280213 },
    title: "Third Item",
    snippet: "third snippet",
  }
];

</script>
