<template>
  <div>
    <ion-button expand="full" @click="openFilePicker">Select Files</ion-button>
    <input type="file" ref="fileInput" @change="onFileChange" style="display:none" multiple accept="image/*"/>

    <div v-if="images.length" class="image-list">
      <div v-for="(image, index) in images" :key="index" class="image-preview">
        <img :src="image.url" :alt="image.name"/>
        <ion-button @click="createItem(image)">Sponsor your Food</ion-button>
      </div>
    </div>
    <div v-if="uploadSuccess" class="heart-animation">❤️</div>
  </div>
</template>

<script lang="ts">
import {defineComponent, ref} from 'vue';
import {IonButton} from '@ionic/vue';
import {itemApi} from "@/lib/client";
import {CreateItemDto, ItemAddPicturesPostRequest, ItemCreatePostRequest} from "@/lib/leftoverlove_client";

interface ImageFile {
  url: string;
  name: string;
}

const dataURLtoFile = (dataUrl: string, fileName: string): File => {
  const arr = dataUrl.split(',');
  const mime = arr[0].match(/:(.*?);/)?.[1] || '';
  const bstr = atob(arr[1]);
  let n = bstr.length;
  const u8arr = new Uint8Array(n);

  while (n--) {
    u8arr[n] = bstr.charCodeAt(n);
  }

  return new File([u8arr], fileName, {type: mime});
};

export default defineComponent({
  name: 'FilePickerComponent',
  components: {
    IonButton,
  },
  setup() {
    const fileInput = ref<HTMLInputElement | null>(null);
    const images = ref<ImageFile[]>([]);
    const uploadSuccess = ref(false);

    const openFilePicker = () => {
      fileInput.value?.click();
    };

    const getRandomValueBetween = (min: number, max: number) => {
      return Math.random() * (max - min) + min;
    };

    const createItem = async (image: ImageFile) => {
      try {
        // TODO: Exchange this one - get the user ID!
        const customerId = 1;
        const itemDto: CreateItemDto = {
          // TODO: File
          description: "A pile of food",
          // TODO: Get coords from image/gps
          longitude: getRandomValueBetween(7.001, 7.901),
          latitude: getRandomValueBetween(46.80, 47.30),
          expirationDate: new Date(),
          customerId: customerId,
        };
        const itemRequest: ItemCreatePostRequest = {createItemDto: itemDto}
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
                images.value.push({url: e.target.result as string, name: file.name});
              }
            };
            reader.readAsDataURL(file);
          }
        });
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

.image-list {
  margin-top: 20px;
}

.image-preview {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 10px;
}

.image-preview img {
  max-width: 100%;
  height: auto;
}

.image-preview p {
  margin: 5px 0 0;
}
</style>