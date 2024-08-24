/* tslint:disable */
/* eslint-disable */
/**
 * LeftOverLove.WebAPI
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';

export interface HaversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2GetRequest {
    latitude1: string;
    longitude1: string;
    latitude2: string;
    longitude2: string;
}

/**
 * 
 */
export class HaversineDistanceApi extends runtime.BaseAPI {

    /**
     */
    async haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2GetRaw(requestParameters: HaversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2GetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<number>> {
        if (requestParameters['latitude1'] == null) {
            throw new runtime.RequiredError(
                'latitude1',
                'Required parameter "latitude1" was null or undefined when calling haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2Get().'
            );
        }

        if (requestParameters['longitude1'] == null) {
            throw new runtime.RequiredError(
                'longitude1',
                'Required parameter "longitude1" was null or undefined when calling haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2Get().'
            );
        }

        if (requestParameters['latitude2'] == null) {
            throw new runtime.RequiredError(
                'latitude2',
                'Required parameter "latitude2" was null or undefined when calling haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2Get().'
            );
        }

        if (requestParameters['longitude2'] == null) {
            throw new runtime.RequiredError(
                'longitude2',
                'Required parameter "longitude2" was null or undefined when calling haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2Get().'
            );
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/HaversineDistance/GetHaversineDistance/{latitude1}/{longitude1}/{latitude2}/{longitude2}`.replace(`{${"latitude1"}}`, encodeURIComponent(String(requestParameters['latitude1']))).replace(`{${"longitude1"}}`, encodeURIComponent(String(requestParameters['longitude1']))).replace(`{${"latitude2"}}`, encodeURIComponent(String(requestParameters['latitude2']))).replace(`{${"longitude2"}}`, encodeURIComponent(String(requestParameters['longitude2']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        if (this.isJsonMime(response.headers.get('content-type'))) {
            return new runtime.JSONApiResponse<number>(response);
        } else {
            return new runtime.TextApiResponse(response) as any;
        }
    }

    /**
     */
    async haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2Get(requestParameters: HaversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2GetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<number> {
        const response = await this.haversineDistanceGetHaversineDistanceLatitude1Longitude1Latitude2Longitude2GetRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
