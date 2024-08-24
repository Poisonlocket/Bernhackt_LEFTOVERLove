import {Configuration, ConfigurationParameters, ItemApi} from "@/lib/leftoverlove_client";

const parameter: ConfigurationParameters = {basePath: "http://localhost:5000"}
const config = new Configuration(parameter)
export const itemApi = new ItemApi(config);