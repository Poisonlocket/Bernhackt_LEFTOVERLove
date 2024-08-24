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
 * @interface CreateCustomerDto
 */
export interface CreateCustomerDto {
    /**
     * 
     * @type {string}
     * @memberof CreateCustomerDto
     */
    firstName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateCustomerDto
     */
    lastName?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateCustomerDto
     */
    longitude?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateCustomerDto
     */
    latitude?: string | null;
    /**
     * 
     * @type {number}
     * @memberof CreateCustomerDto
     */
    points?: number;
}

/**
 * Check if a given object implements the CreateCustomerDto interface.
 */
export function instanceOfCreateCustomerDto(value: object): value is CreateCustomerDto {
    return true;
}

export function CreateCustomerDtoFromJSON(json: any): CreateCustomerDto {
    return CreateCustomerDtoFromJSONTyped(json, false);
}

export function CreateCustomerDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateCustomerDto {
    if (json == null) {
        return json;
    }
    return {
        
        'firstName': json['firstName'] == null ? undefined : json['firstName'],
        'lastName': json['lastName'] == null ? undefined : json['lastName'],
        'longitude': json['longitude'] == null ? undefined : json['longitude'],
        'latitude': json['latitude'] == null ? undefined : json['latitude'],
        'points': json['points'] == null ? undefined : json['points'],
    };
}

export function CreateCustomerDtoToJSON(value?: CreateCustomerDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'firstName': value['firstName'],
        'lastName': value['lastName'],
        'longitude': value['longitude'],
        'latitude': value['latitude'],
        'points': value['points'],
    };
}
