<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>File Picker</ion-title>
      </ion-toolbar>
    </ion-header>

    <ion-content class="ion-padding">
      <ion-button expand="full" @click="openFilePicker">Select Files</ion-button>
      <input type="file" ref="fileInput" @change="onFileChange" style="display:none" multiple />

      <div v-if="selectedFiles.length" class="file-list">
        <h3>Selected Files:</h3>
        <ul>
          <li v-for="file in selectedFiles" :key="file.name">{{ file.name }}</li>
        </ul>
      </div>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { IonPage, IonHeader, IonToolbar, IonTitle, IonContent, IonButton } from '@ionic/vue';

export default defineComponent({
  name: 'FilePickerComponent',
  components: {
    IonPage,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonContent,
    IonButton,
  },
  setup() {
    const fileInput = ref<HTMLInputElement | null>(null);
    const selectedFiles = ref<File[]>([]);

    const openFilePicker = () => {
      fileInput.value?.click();
    };

    const onFileChange = () => {
      if (fileInput.value?.files) {
        selectedFiles.value = Array.from(fileInput.value.files);
      }
    };

    return {
      fileInput,
      selectedFiles,
      openFilePicker,
      onFileChange,
    };
  },
});
</script>

<style scoped>
.file-list {
  margin-top: 20px;
}

.file-list ul {
  list-style: none;
  padding: 0;
}

.file-list li {
  background-color: #f1f1f1;
  border: 1px solid #ddd;
  padding: 5px;
  margin-bottom: 5px;
}
</style>