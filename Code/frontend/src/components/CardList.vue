<template>
  <ion-list>
    <ion-for v-if="!loaded" v-for="item in [1, 2, 3, 4, 5, 6]" :key="item.id">
      <ion-list-header>
        <ion-skeleton-text :animated="true" style="width: 80px"></ion-skeleton-text>
      </ion-list-header>
      <ion-item>
        <ion-thumbnail slot="start">
          <ion-skeleton-text :animated="true"></ion-skeleton-text>
        </ion-thumbnail>
        <ion-label>
          <h3>
            <ion-skeleton-text :animated="true" style="width: 80%;"></ion-skeleton-text>
          </h3>
          <p>
            <ion-skeleton-text :animated="true" style="width: 60%;"></ion-skeleton-text>
          </p>
          <p>
            <ion-skeleton-text :animated="true" style="width: 30%;"></ion-skeleton-text>
          </p>
        </ion-label>
      </ion-item>
    </ion-for>
    <ion-for v-if="loaded">
      <ion-card v-for="item in items" :key="item.id">
        <img v-if="item.assetUrl" alt="" :src="item.assetUrl"/>
        <ion-card-header>
          <ion-card-title>{{ item.description }}</ion-card-title>
          <ion-card-subtitle>Hinzugefügt: {{ item.creationDate.toLocaleDateString("de-CH") }}</ion-card-subtitle>
          <ion-card-subtitle>Ablaufdatum: {{ item.expirationDate.toLocaleDateString("de-CH") }}</ion-card-subtitle>
        </ion-card-header>
        <ion-card-content>
          <span>Geteilt von: Max Mustermann</span>
        </ion-card-content>
      </ion-card>
    </ion-for>
  </ion-list>
</template>

<script lang="ts">
import {ref, onMounted} from 'vue';

interface CardContent {
  id: number;
  description: string;
  assetUrl: string | null;
  creationDate: string;
  expirationDate: string;
}

import {itemApi, pictureUrl} from '@/lib/client';


export default {
  name: 'Tab1Page',
  setup() {
    const pageTitle = ref('Items');
    const items = ref<CardContent[]>([]);
    const loaded = ref(false);

    onMounted(async () => {
      try {
        const fetchedItems = await itemApi.itemAllGet();

        items.value = fetchedItems.map(itm => {
          let imageUrl = null;
          if (itm.picturePaths?.length > 0) {
            imageUrl = pictureUrl(itm.picturePaths[0]);
          }
          console.log(itm)
          return {
            id: itm.id,
            description: itm.description,
            creationDate: itm.creationDate,
            expirationDate: itm.expirationDate,
            assetUrl: imageUrl,
          };
        });
        loaded.value = true;
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    });

    return {
      pageTitle,
      items,
      loaded
    };
  }
};
</script>
