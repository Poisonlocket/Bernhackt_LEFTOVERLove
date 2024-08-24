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
import type { ItemState } from './ItemState';
import {
    ItemStateFromJSON,
    ItemStateFromJSONTyped,
    ItemStateToJSON,
} from './ItemState';

/**
 * 
 * @export
 * @interface ItemDto
 */
export interface ItemDto {
    /**
     * 
     * @type {number}
     * @memberof ItemDto
     */
    id?: number;
    /**
     * 
     * @type {string}
     * @memberof ItemDto
     */
    description?: string | null;
    /**
     * 
     * @type {number}
     * @memberof ItemDto
     */
    longitude?: number;
    /**
     * 
     * @type {number}
     * @memberof ItemDto
     */
    latitude?: number;
    /**
     * 
     * @type {Date}
     * @memberof ItemDto
     */
    expirationDate?: Date;
    /**
     * 
     * @type {Array<string>}
     * @memberof ItemDto
     */
    picturePaths?: Array<string> | null;
    /**
     * 
     * @type {ItemState}
     * @memberof ItemDto
     */
    state?: ItemState;
    /**
     * 
     * @type {Date}
     * @memberof ItemDto
     */
    creationDate?: Date;
    /**
     * 
     * @type {number}
     * @memberof ItemDto
     */
    customerId?: number;
}



/**
 * Check if a given object implements the ItemDto interface.
 */
export function instanceOfItemDto(value: object): value is ItemDto {
    return true;
}

export function ItemDtoFromJSON(json: any): ItemDto {
    return ItemDtoFromJSONTyped(json, false);
}

export function ItemDtoFromJSONTyped(json: any, ignoreDiscriminator: boolean): ItemDto {
    if (json == null) {
        return json;
    }
    return {
        
        'id': json['id'] == null ? undefined : json['id'],
        'description': json['description'] == null ? undefined : json['description'],
        'longitude': json['longitude'] == null ? undefined : json['longitude'],
        'latitude': json['latitude'] == null ? undefined : json['latitude'],
        'expirationDate': json['expirationDate'] == null ? undefined : (new Date(json['expirationDate'])),
        'picturePaths': json['picturePaths'] == null ? undefined : json['picturePaths'],
        'state': json['state'] == null ? undefined : ItemStateFromJSON(json['state']),
        'creationDate': json['creationDate'] == null ? undefined : (new Date(json['creationDate'])),
        'customerId': json['customerId'] == null ? undefined : json['customerId'],
    };
}

export function ItemDtoToJSON(value?: ItemDto | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'id': value['id'],
        'description': value['description'],
        'longitude': value['longitude'],
        'latitude': value['latitude'],
        'expirationDate': value['expirationDate'] == null ? undefined : ((value['expirationDate']).toISOString()),
        'picturePaths': value['picturePaths'],
        'state': ItemStateToJSON(value['state']),
        'creationDate': value['creationDate'] == null ? undefined : ((value['creationDate']).toISOString()),
        'customerId': value['customerId'],
    };
}

