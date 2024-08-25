<script>
import { ref, onMounted, watch } from 'vue';
import { GoogleMap } from '@capacitor/google-maps';
import {itemApi} from "@/lib/client.ts";

export default {
    name: 'MapComponent',
    setup(props, { emit }) {
        const mapRef = ref(null);
        let googleMap = null;

        async function createMap() {
            if (!mapRef.value) return;
            try {
                googleMap = await GoogleMap.create({
                    id: "simple-map",
                    element: mapRef.value,
                    apiKey: 'AIzaSyCeaKi3CsInCMMfJXzm72401yG9EwfSldQ',
                    config: {
                        center: {
                            lat: 46.942596781024726,
                            lng: 7.440866134927716,
                        },
                        zoom: 13,
                        disableDefaultUI: true,
                        styles: [
                            { elementType: 'geometry', stylers: [{ color: '#212121' }] },
                            { elementType: 'labels.icon', stylers: [{ visibility: 'off' }] },
                            { elementType: 'labels.text.fill', stylers: [{ color: '#757575' }] },
                            { elementType: 'labels.text.stroke', stylers: [{ color: '#212121' }] },
                            { featureType: 'administrative', elementType: 'geometry', stylers: [{ color: '#757575' }] },
                            { featureType: 'administrative.country', elementType: 'labels.text.fill', stylers: [{ color: '#9e9e9e' }] },
                            { featureType: 'administrative.land_parcel', stylers: [{ visibility: 'off' }] },
                            { featureType: 'administrative.locality', elementType: 'labels.text.fill', stylers: [{ color: '#bdbdbd' }] },
                            { featureType: 'poi', elementType: 'labels.text.fill', stylers: [{ color: '#757575' }] },
                            { featureType: 'poi.park', elementType: 'geometry', stylers: [{ color: '#181818' }] },
                            { featureType: 'poi.park', elementType: 'labels.text.fill', stylers: [{ color: '#616161' }] },
                            { featureType: 'poi.park', elementType: 'labels.text.stroke', stylers: [{ color: '#1b1b1b' }] },
                            { featureType: 'road', elementType: 'geometry.fill', stylers: [{ color: '#2c2c2c' }] },
                            { featureType: 'road', elementType: 'labels.text.fill', stylers: [{ color: '#8a8a8a' }] },
                            { featureType: 'road.arterial', elementType: 'geometry', stylers: [{ color: '#373737' }] },
                            { featureType: 'road.highway', elementType: 'geometry', stylers: [{ color: '#3c3c3c' }] },
                            { featureType: 'road.highway.controlled_access', elementType: 'geometry', stylers: [{ color: '#4e4e4e' }] },
                            { featureType: 'road.local', elementType: 'labels.text.fill', stylers: [{ color: '#616161' }] },
                            { featureType: 'transit', elementType: 'labels.text.fill', stylers: [{ color: '#757575' }] },
                            { featureType: 'water', elementType: 'geometry', stylers: [{ color: '#000000' }] },
                            { featureType: 'water', elementType: 'labels.text.fill', stylers: [{ color: '#3d3d3d' }] }
                        ]
                    }
                });

                const items = await itemApi.itemAllGet()
                const markerData = items.map(itm =>({
                  coordinate: {lat: itm.latitude, lng: itm.longitude},
                  // TODO: We do not have a name?
                  title: itm.description,
                  description: itm.description,
                }))


                await addMarkers(markerData);

                googleMap.setOnMarkerClickListener((event) => {
                    emit("onMarkerClicked", event);
                });
            } catch (error) {
                console.error('Error creating map:', error);
            }
        }

        async function addMarkers(markerData) {
            if (!googleMap) return;

            await googleMap.addMarkers(markerData.map(marker => ({
                coordinate: {
                    lat: marker.coordinate.lat,
                    lng: marker.coordinate.lng,
                },
                title: marker.title,
                snippet: marker.snippet,
                iconUrl: '/marker.svg'
            })));
        }

        watch(() => props.markerData, (newMarkerData) => {
            addMarkers(newMarkerData);
        });

        onMounted(() => {
            //console.log('component mounted');
            createMap();
        });

        return {
            mapRef,
        };
    }
};
</script>

<template>
    <capacitor-google-map class="inline-block w-screen h-[80vh]" ref="mapRef" style="width: 100vw;"></capacitor-google-map>
</template>