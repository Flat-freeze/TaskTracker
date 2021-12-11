import {Metadata} from "./metadata";

export interface OperationResult<TResult> {

  activityId: string;

  metadata: Metadata;

  exception: Error;

  logs: string[];

  result:TResult;

  ok:boolean;
}
