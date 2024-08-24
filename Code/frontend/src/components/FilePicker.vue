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

  return new File([u8arr], fileName, { type: mime });
};

export default defineComponent({
  name: 'FilePickerComponent',
  components: {
    IonButton,
  },
  setup() {
    const fileInput = ref<HTMLInputElement | null>(null);
    const images = ref<ImageFile[]>([]);

    const openFilePicker = () => {
      fileInput.value?.click();
    };

    const createItem = async (image: ImageFile) => {
      try {
        // TODO: Exchange this one - get the user ID!
        const customerId = 1;
        const itemDto: CreateItemDto = {
          description: "A pile of food",
          longitude: "7.4474",
          latitude: "46.9481",
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
      openFilePicker,
      onFileChange,
      createItem
    };
  },
});
</script>

<style scoped>
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