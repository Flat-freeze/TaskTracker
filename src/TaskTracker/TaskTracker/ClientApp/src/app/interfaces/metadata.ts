import {MetadataType} from "./metadata-type";

export interface Metadata {

    Message: string;

    Type: MetadataType;

    DataObject: object;
}
