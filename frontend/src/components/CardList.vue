<template>
  <ion-for>
    <ion-card v-for="item in items" :key="item.id">
      <img alt="Image-Alt" src="https://images.unsplash.com/photo-1463123081488-789f998ac9c4?q=80&w=450&h=200&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" />
      <!-- https://ionicframework.com/docs/img/demos/card-media.png -->
      <ion-card-header>
        <ion-card-title>{{ item.product }}</ion-card-title>
        <ion-card-subtitle>{{ item.date_created }}</ion-card-subtitle>
      </ion-card-header>
      <ion-card-content class="py-0 ion-padding">
        <div class="pb-4">
          <ion-chip>Fruits</ion-chip>
          <ion-chip>Exotic</ion-chip>
        </div>
        <div>{{ item.description }}</div>
      </ion-card-content>
      <ion-card-content>
        <div class="flex justify-end">posted by: {{ item.user }}</div>
      </ion-card-content>
    </ion-card>
  </ion-for>
</template>

<script>
import { ref, onMounted } from 'vue';

export default {
  name: 'Tab1Page',
  setup() {
    const pageTitle = ref('Items');
    const items = ref([]);

    onMounted(async () => {
      try {
        const response = await fetch('https://my.api.mockaroo.com/demo_app.json?key=37aa94e0');
        const data = await response.json();
        items.value = data;
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    });

    return {
      pageTitle,
      items
    };
  }
};
</script>
