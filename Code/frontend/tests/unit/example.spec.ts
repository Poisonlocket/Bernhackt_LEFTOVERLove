import {describe, expect, test} from 'vitest'
import {
    Configuration,
    ConfigurationParameters, CreateItemDto,
    CustomerApi,
    CustomerCreatePostRequest, ItemAddPicturesPostRequest, ItemCreatePostRequest
} from "../../src/lib/leftoverlove_client";
import {itemApi} from "../../src/lib/client";

describe('Generated Client', () => {
    test('makes a request, when backend is up', async () => {
        // given
        const parameter: ConfigurationParameters = {basePath: "http://localhost:5000"}
        const config = new Configuration(parameter)
        const api = new CustomerApi(config)
        const userToCreate:
            CustomerCreatePostRequest = {
            createCustomerDto: {
                firstName: "Hans",
                lastName: "Fiesel",
                latitude: 1.1,
                longitude: 1.2,
                points: 20
            }
        }
        // when
        const response = await api.customerCreatePost(userToCreate);
        console.log(response)

        // then
        expect(response.id).toBeGreaterThan(0)
    })
})

describe('Generated Client', () => {
    test('makes a request, when backend is up', async () => {
        const file = new File([""], "mock-image.png", { type: "image/png" });
        const customerId = 1;
        const itemDto: CreateItemDto = {
            description: "A pile of food",
            longitude: 7.4474,
            latitude: 46.9481,
            expirationDate: new Date(),
            customerId: customerId,
        };
        const itemRequest: ItemCreatePostRequest = {createItemDto: itemDto}
        const itemResponse = await itemApi.itemCreatePost(itemRequest)
        const request: ItemAddPicturesPostRequest = {
            itemId: itemResponse.id,
            pictures: [file],
        }
        await itemApi.itemAddPicturesPost(request)
    })
})

async function uploadImages(userId, files) {
    const url = `http://localhost:5000/image?userId=${userId}`;

    // Create FormData object
    const formData = new FormData();

    // Append files to FormData
    files.forEach((file, index) => {
        formData.append(`images[${index}]`, file);
    });

    // Make the POST request
    const response = await fetch(url, {
        method: 'POST',
        body: formData,
    });

    if (!response.ok) {
        throw new Error('Failed to upload images');
    }

    return await response.json();
}
