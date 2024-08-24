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
        <Map :markerData="markerData" @onMarkerClicked="markerClicked" />

        <ion-modal ref="modal" :can-dismiss="canDismiss">
          <ion-header>
            <ion-toolbar>
              <ion-title>Food Share</ion-title>
              <ion-buttons slot="end">
                <ion-button @click="dismiss">Schliessen</ion-button>
              </ion-buttons>
            </ion-toolbar>
          </ion-header>
          <ion-content v-if="loadedData">
            <ion-card>
              <img alt="" :src="loadedData.assetUrl" />
              <ion-card-header>
                <ion-card-title>{{ loadedData.title }}</ion-card-title>
                <ion-card-subtitle>{{ loadedData.dateCreated }}</ion-card-subtitle>
              </ion-card-header>
              <ion-card-content class="h-full">
                <span>{{ loadedData.id }}</span>
                <div>{{ loadedData.description }}</div>
                <div class="mt-4">
                  <ion-button class="w-full" color="primary">Interesse anmelden</ion-button>
                </div>
              </ion-card-content>
              
            </ion-card>
          </ion-content>
        </ion-modal>

      </ion-content>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonToolbar, IonTitle, IonContent, IonModal, IonLoading } from '@ionic/vue';
import { defineComponent, defineEmits, ref } from 'vue';
import Map from '@/components/Map.vue';
import { Capacitor } from '@capacitor/core';

const emits = defineEmits<{
  (event: "onMarkerClicked", info: any): void;
}>();

const modal = ref(null);
const loadedData = ref(null);

const dismiss = () => { modal.value.$el.dismiss() }

const loadItem = async (itemId: null) => {
  try {
    // handle api calls here - const response = await axios.get(`https://api.example.com/items/${itemId}`);
    const response = {
      data: {
        id: itemId,
        assetUrl: 'https://ionicframework.com/docs/img/demos/card-media.png',
        dateCreated: "2021-09-01T12:00:00Z",
        title: "an apple?",
        description: "this is demo data for an apple. apples are green. they are healthy and tasty.",
      }
    };
    return response.data;
  } catch (error) {
    console.error("Error loading item:", error);
    return null;
  }
};

const markerClicked = async (item: any) => {
  if (!Capacitor.isNativePlatform()) {
    loadedData.value = await loadItem(item.markerId);
    if (loadedData.value) {
      modal.value.$el.present(loadedData);
    }
  }
};

const markerData = [
  {
    coordinate: { lat: 46.94227090555359, lng: 7.440744738280579 },
    title: "First Item",
    description: "title one snippet content will be presented here",
  },
  {
    coordinate: { lat: 46.960253240769944, lng: 7.460482860907267 },
    title: "Second Item",
    description: "another short text",
  },
  {
    coordinate: { lat: 46.97021442933564, lng: 7.432154173280213 },
    title: "Third Item",
    description: "third snippet",
  }
];

</script>
