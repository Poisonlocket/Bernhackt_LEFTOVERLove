import {Configuration, ConfigurationParameters, ItemApi} from "@/lib/leftoverlove_client";

const baseUrl = "http://localhost:5000";

const parameter: ConfigurationParameters = {basePath: baseUrl}
const config = new Configuration(parameter)
export const itemApi = new ItemApi(config);

export function pictureUrl(assetPath: string):string {
    return `${baseUrl}${assetPath}`;
}