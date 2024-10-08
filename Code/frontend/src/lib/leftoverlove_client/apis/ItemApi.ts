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
import type {
  CreateItemDto,
  ItemDto,
} from '../models/index';
import {
    CreateItemDtoFromJSON,
    CreateItemDtoToJSON,
    ItemDtoFromJSON,
    ItemDtoToJSON,
} from '../models/index';

export interface ItemAddPicturesPostRequest {
    itemId?: number;
    pictures?: Array<Blob>;
}

export interface ItemByIdIdGetRequest {
    id: number;
}

export interface ItemCreateBulkPostRequest {
    createItemDto?: Array<CreateItemDto>;
}

export interface ItemCreatePostRequest {
    createItemDto?: CreateItemDto;
}

export interface ItemRangeGetRequest {
    skip?: number;
    take?: number;
    longitude?: number;
    latitude?: number;
}

/**
 * 
 */
export class ItemApi extends runtime.BaseAPI {

    /**
     */
    async itemAddPicturesPostRaw(requestParameters: ItemAddPicturesPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        if (requestParameters['itemId'] != null) {
            queryParameters['itemId'] = requestParameters['itemId'];
        }

        const headerParameters: runtime.HTTPHeaders = {};

        const consumes: runtime.Consume[] = [
            { contentType: 'multipart/form-data' },
        ];
        // @ts-ignore: canConsumeForm may be unused
        const canConsumeForm = runtime.canConsumeForm(consumes);

        let formParams: { append(param: string, value: any): any };
        let useForm = false;
        // use FormData to transmit files using content-type "multipart/form-data"
        useForm = canConsumeForm;
        if (useForm) {
            formParams = new FormData();
        } else {
            formParams = new URLSearchParams();
        }

        if (requestParameters['pictures'] != null) {
            requestParameters['pictures'].forEach((element) => {
                formParams.append('pictures', element as any);
            })
        }

        const response = await this.request({
            path: `/Item/AddPictures`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: formParams,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async itemAddPicturesPost(requestParameters: ItemAddPicturesPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.itemAddPicturesPostRaw(requestParameters, initOverrides);
    }

    /**
     */
    async itemAllGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ItemDto>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/Item/All`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ItemDtoFromJSON));
    }

    /**
     */
    async itemAllGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ItemDto>> {
        const response = await this.itemAllGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async itemByIdIdGetRaw(requestParameters: ItemByIdIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ItemDto>> {
        if (requestParameters['id'] == null) {
            throw new runtime.RequiredError(
                'id',
                'Required parameter "id" was null or undefined when calling itemByIdIdGet().'
            );
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/Item/ById/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters['id']))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ItemDtoFromJSON(jsonValue));
    }

    /**
     */
    async itemByIdIdGet(requestParameters: ItemByIdIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ItemDto> {
        const response = await this.itemByIdIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async itemCreateBulkPostRaw(requestParameters: ItemCreateBulkPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ItemDto>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/Item/CreateBulk`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: requestParameters['createItemDto']!.map(CreateItemDtoToJSON),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ItemDtoFromJSON));
    }

    /**
     */
    async itemCreateBulkPost(requestParameters: ItemCreateBulkPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ItemDto>> {
        const response = await this.itemCreateBulkPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async itemCreatePostRaw(requestParameters: ItemCreatePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ItemDto>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        const response = await this.request({
            path: `/Item/Create`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateItemDtoToJSON(requestParameters['createItemDto']),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ItemDtoFromJSON(jsonValue));
    }

    /**
     */
    async itemCreatePost(requestParameters: ItemCreatePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ItemDto> {
        const response = await this.itemCreatePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async itemRangeGetRaw(requestParameters: ItemRangeGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ItemDto>>> {
        const queryParameters: any = {};

        if (requestParameters['skip'] != null) {
            queryParameters['skip'] = requestParameters['skip'];
        }

        if (requestParameters['take'] != null) {
            queryParameters['take'] = requestParameters['take'];
        }

        if (requestParameters['longitude'] != null) {
            queryParameters['longitude'] = requestParameters['longitude'];
        }

        if (requestParameters['latitude'] != null) {
            queryParameters['latitude'] = requestParameters['latitude'];
        }

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/Item/Range`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ItemDtoFromJSON));
    }

    /**
     */
    async itemRangeGet(requestParameters: ItemRangeGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ItemDto>> {
        const response = await this.itemRangeGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
