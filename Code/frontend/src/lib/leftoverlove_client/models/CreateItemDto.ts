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

import { mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface CreateItemDto
 */
export interface CreateItemDto {
    /**
     * 
     * @type {string}
     * @memberof CreateItemDto
     */
    description?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CreateItemDto
     */
    longitude?: number;
    /**
     * 
     * @type {number}
     * @memberof CreateItemDto
     */
    latitude?: number;
    /**
     * 
     * @type {Date}
     * @memberof CreateItemDto
     */
    expirationDate?: Date;
    /**
     * 
     * @type {number}
     * @memberof CreateItemDto
     */
    customerId?: number;
}

/**
 * Check if a given object implements the CreateItemDto interface.
 */
export function instanceOfCreateItemDto(value: object): value is CreateItemDto {
    return true;
}

export function CreateItemDtoFromJSON(json: any): CreateItemDto {
    return CreateItemDtoFromJSONTyped(json, false);
}

export function CreateItemDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateItemDto {
    if (json == null) {
        return json;
    }
    return {
        
        'description': json['description'] == null ? undefined : json['description'],
        'longitude': json['longitude'] == null ? undefined : json['longitude'],
        'latitude': json['latitude'] == null ? undefined : json['latitude'],
        'expirationDate': json['expirationDate'] == null ? undefined : (new Date(json['expirationDate'])),
        'customerId': json['customerId'] == null ? undefined : json['customerId'],
    };
}

export function CreateItemDtoToJSON(value?: CreateItemDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'description': value['description'],
        'longitude': value['longitude'],
        'latitude': value['latitude'],
        'expirationDate': value['expirationDate'] == null ? undefined : ((value['expirationDate']).toISOString()),
        'customerId': value['customerId'],
    };
}

