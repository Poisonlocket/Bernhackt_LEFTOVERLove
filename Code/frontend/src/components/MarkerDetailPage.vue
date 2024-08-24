<!-- src/components/MarkerDetailPage.vue -->
<template>
  <div>
    <h1>Marker Details</h1>
    <p>{{ markerDetail }}</p>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';

export default defineComponent({
  name: 'MarkerDetailPage',
  setup() {
    const route = useRoute();
    const markerDetail = ref(null);

    onMounted(() => {
      const markerId = route.params.id;
      // Assume getMarkerDetail is a function that fetches the marker details by ID
      markerDetail.value = getMarkerDetail(markerId);
    });

    function getMarkerDetail(id: string) {
      // Sample data.
      const markers = [
        { id: '1', detail: 'Details for marker 1' },
        { id: '2', detail: 'Details for marker 2' },
      ];

      return markers.find(marker => marker.id === id)?.detail || 'No details available';
    }

    return {
      markerDetail,
    };
  },
});
</script>