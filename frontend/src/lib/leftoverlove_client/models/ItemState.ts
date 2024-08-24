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


/**
 * 
 * @export
 */
export const ItemState = {
    Ready: 'Ready',
    Commited: 'Commited',
    Recieved: 'Recieved'
} as const;
export type ItemState = typeof ItemState[keyof typeof ItemState];


export function instanceOfItemState(value: any): boolean {
    for (const key in ItemState) {
        if (Object.prototype.hasOwnProperty.call(ItemState, key)) {
            if (ItemState[key as keyof typeof ItemState] === value) {
                return true;
            }
        }
    }
    return false;
}

export function ItemStateFromJSON(json: any): ItemState {
    return ItemStateFromJSONTyped(json, false);
}

export function ItemStateFromJSONTyped(json: any, ignoreDiscriminator: boolean): ItemState {
    return json as ItemState;
}

export function ItemStateToJSON(value?: ItemState | null): any {
    return value as any;
}

