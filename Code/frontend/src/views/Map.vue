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
        <Map @onMarkerClicked="markerClicked"/>
        <ion-modal ref="modal" :can-dismiss="canDismiss">
          <ion-header>
            <ion-toolbar>
              <ion-title>Food Share</ion-title>
              <ion-buttons slot="end">
                <ion-button @click="dismiss">Schliessen</ion-button>
              </ion-buttons>
            </ion-toolbar>
          </ion-header>
          <ion-content v-if="!loadedData">
            <!-- Todo -->
            <ion-skeleton-text :animated="true" style="width: 80px"></ion-skeleton-text>
          </ion-content>
          <ion-content v-if="loadedData">
            <ion-card>
              <img alt="" :src="loadedData.assetUrl"/>
              <ion-card-header>
                <ion-card-title>{{ loadedData.title }}</ion-card-title>
              </ion-card-header>
              <ion-card-content class="h-full">
                <!-- <span>{{ loadedData.id }}</span> -->
                <div>{{ loadedData.description }}</div>
                <div class="mt-4">Erstellt am: {{ loadedData.dateCreated }}</div>
                <div class="mt-4">Ablaufdatum: {{ loadedData.expirationDate }}</div>
                <div class="mt-4">
                  <ion-button class="w-full" color="primary">
                    <div class="flex gap-1">
                      <span>Take it!</span>
                      <ion-icon :icon="chevronForwardOutline"></ion-icon>
                    </div>
                  </ion-button>
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
import {IonPage, IonHeader, IonToolbar, IonTitle, IonContent, IonModal, IonLoading} from '@ionic/vue';
import {chevronForwardOutline} from 'ionicons/icons';
import {defineComponent, defineEmits, ref} from 'vue';
import {itemApi, pictureUrl} from '@/lib/client';
import Map from '@/components/Map.vue';
import {Capacitor} from '@capacitor/core';
import {ItemByIdIdGetRequest} from "@/lib/leftoverlove_client";
import {getRandomPic} from "@/lib/pics";

const emits = defineEmits<{
  (event: "onMarkerClicked", info: any): void;
}>();

interface ModalContent {
  description: string;
  assetUrl: string;
  title: string;
  dateCreated: string;
}

const modal = ref(null);
const loadedData = ref<ModalContent|null>(null);

const dismiss = () => {
  modal.value.$el.dismiss()
}

const loadItem = async (itemId: null) => {
  try {
    if (!itemId) {
      return null;
    }

    const request: ItemByIdIdGetRequest = {id: itemId};
    return await itemApi.itemByIdIdGet(request);

  } catch (error) {
    console.error("Error loading item:", error);
    return null;
  }
};

const markerClicked = async (item: any) => {
  if (!Capacitor.isNativePlatform()) {
    const fetchedItem = await loadItem(item.markerId)
    if (!fetchedItem) {
      return;
    }

    let imageUrl = getRandomPic();
    if (fetchedItem.picturePaths?.length > 0) {
      imageUrl = pictureUrl(fetchedItem.picturePaths[0]);
    }
    const modalContent: ModalContent = {
      assetUrl: imageUrl,
      description: fetchedItem.description,
      title: fetchedItem.description,
      dateCreated: fetchedItem.creationDate,
    }

    loadedData.value = modalContent;

    console.log(modalContent);

    modal.value.$el.present(loadedData);
  }
};

</script>