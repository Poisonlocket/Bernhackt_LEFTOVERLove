import {describe, expect, test} from 'vitest'
import {
    Configuration,
    ConfigurationParameters,
    CustomerApi,
    CustomerCreatePostRequest
} from "../../src/lib/leftoverlove_client";

describe('Generated Client', () => {
    test('makes a request, when backend is up', async() => {
        // given
        const parameter: ConfigurationParameters = {basePath: "http://localhost:5000"}
        const config = new Configuration(parameter)
        const api = new CustomerApi(config)
        const userToCreate:
            CustomerCreatePostRequest = {
            createCustomerDto: {
                firstName: "Hans",
                lastName: "Fiesel",
                latitude: "1.1",
                longitude: "1.2",
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
