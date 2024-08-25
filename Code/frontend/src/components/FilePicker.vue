<template>
  <ion-page>
    <ion-content>
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title color="primary" size="large">Share</ion-title>
          <ion-subtitle class="p-4 text-xl text-neutral-400">Share your food with friends</ion-subtitle>
        </ion-toolbar>
      </ion-header>
      <ion-content class="ion-padding">
        <ion-list class="flex flex-col content-center gap-4">
          <ion-item>
            <ion-input label="Titel"></ion-input>
          </ion-item>
          <ion-item>
            <ion-input label="Beschreibung"></ion-input>
          </ion-item>
          <ion-item>
            <ion-label>Ablaufdatum</ion-label>
            <ion-datetime-button datetime="datetime"></ion-datetime-button>
            <ion-modal :keep-contents-mounted="true">
              <ion-datetime id="datetime" presentation="date" value="2024-08-24T22:30:00"></ion-datetime>
            </ion-modal>
          </ion-item>
        </ion-list>
        <ion-button class="w-full mt-8" @click="openFilePicker">Upload image</ion-button>
        <div v-if="uploadSuccess" class="heart-animation">❤️</div>
        <div v-if="images.length" class="mt-8">
          <div v-for="(image, index) in images" :key="index" class="flex flex-col items-center mb-4">
            <img :src="image.url" :alt="image.name" />
            <ion-button @click="createItem(image)">
              <div class="flex gap-1">
                <span>Sponsor your food</span>
                <ion-icon :icon="chevronForwardOutline"></ion-icon>
              </div>
            </ion-button>

            
          </div>
        </div>
        <input type="file" ref="fileInput" @change="onFileChange" style="display:none" multiple accept="image/*" />

<!--        <ion-button class="w-full mt-8">Submit data</ion-button>-->

      </ion-content>


    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { IonPage, IonButton, IonDatetime, IonDatetimeButton, IonModal } from '@ionic/vue';
import { chevronForwardOutline } from 'ionicons/icons';
import { itemApi } from "@/lib/client";
import { CreateItemDto, ItemAddPicturesPostRequest, ItemCreatePostRequest } from "@/lib/leftoverlove_client";
import {getRandomValueBetween} from "@/lib/misc";

interface ImageFile {
  url: string;
  name: string;
}

const submitForm = () => {
  console.log("Submit form");
};

const dataURLtoFile = (dataUrl: string, fileName: string): File => {
  const arr = dataUrl.split(',');
  const mime = arr[0].match(/:(.*?);/)?.[1] || '';
  const bstr = atob(arr[1]);
  let n = bstr.length;
  const u8arr = new Uint8Array(n);

  while (n--) {
    u8arr[n] = bstr.charCodeAt(n);
  }

  return new File([u8arr], fileName, { type: mime });
};

export default defineComponent({
  name: 'FilePickerComponent',
  components: { IonButton, IonDatetime, IonDatetimeButton, IonModal },

  setup() {
    const fileInput = ref<HTMLInputElement | null>(null);
    const images = ref<ImageFile[]>([]);
    const uploadSuccess = ref(false);

    const openFilePicker = () => {
      fileInput.value?.click();
    };

    const createItem = async (image: ImageFile) => {
      try {
        // TODO: Exchange this one - get the user ID!
        const customerId = 1;
        const itemDto: CreateItemDto = {
          // TODO: File
          description: "A pile of food",
          // TODO: Get coords from image/gps
          longitude: getRandomValueBetween(7.44, 7.45),
          latitude: getRandomValueBetween(46.94, 46.95),
          expirationDate: new Date(),
          customerId: customerId,
        };
        const itemRequest: ItemCreatePostRequest = { createItemDto: itemDto }
        const createdItem = await itemApi.itemCreatePost(itemRequest)
        const fileBlob = dataURLtoFile(image.url, image.name)
        const request: ItemAddPicturesPostRequest = {
          itemId: createdItem.id,
          pictures: [fileBlob],
        }
        await itemApi.itemAddPicturesPost(request)
        uploadSuccess.value = true;
        setTimeout(() => {
          uploadSuccess.value = false;
          window.location.reload();
        }, 2000);
      } catch (e) {
        console.log(e)
      }
    }

    const onFileChange = () => {
      if (fileInput.value?.files) {
        images.value = [];
        const files = Array.from(fileInput.value.files);
        files.forEach(file => {
          if (file.type.startsWith('image/')) {
            const reader = new FileReader();
            reader.onload = e => {
              if (e.target?.result) {
                images.value.push({ url: e.target.result as string, name: file.name });
              }
            };
            reader.readAsDataURL(file);
          }
        });
        console.log(images)
      }
    };

    return {
      fileInput,
      images,
      uploadSuccess,
      openFilePicker,
      onFileChange,
      createItem
    };
  },
});
</script>

<style scoped>
.heart-animation {
  position: fixed;
  z-index: 9999;
  top: 50%;
  left: 50%;
  font-size: 4em;
  color: red;
  animation: pulse 1s infinite;
  text-align: center;
  margin-top: 0;
}

@keyframes pulse {
  0% {
    transform: scale(0.95);
  }
  70% {
    transform: scale(2.0);
  }
  100% {
    transform: scale(0.95);
  }
}

.image-preview img {
  max-width: 100%;
  height: auto;
}

.image-preview p {
  margin: 5px 0 0;
}
</style>