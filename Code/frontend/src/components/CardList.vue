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
        <img v-if="item.picturePaths?.length > 0" alt="" :src="pictureUrl(item.picturePaths[0])" />
        <ion-card-header>
          <ion-card-title>{{ item.description }}</ion-card-title>
          <ion-card-subtitle>{{ item.creationDate }}</ion-card-subtitle>
          <ion-card-subtitle>{{ item.expirationDate }}</ion-card-subtitle>
        </ion-card-header>
        <!-- <ion-card-content class="py-0 ion-padding">
          <div>{{ item.description }}</div>
        </ion-card-content> -->
        <ion-card-content>
          <span>Geteilt von: {{ item.customerId }}</span>
        </ion-card-content>
      </ion-card>
    </ion-for>
  </ion-list>
</template>

<script>
import { ref, onMounted } from 'vue';
import { itemApi } from '@/lib/client';

export default {
  name: 'Tab1Page',
  setup() {
    const pageTitle = ref('Items');
    const items = ref([]);
    const loaded = ref(false);

    onMounted(async () => {
      try {
        items.value = await itemApi.itemAllGet();
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
