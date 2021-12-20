import {Titled} from "../interfaces/titled";

export class TeamFilter implements Titled{
  private _title: string;
  private _orderBy: string;
  private _desc: boolean = false;
  private _isChanged:boolean = false;

  get isChanged(): boolean {
    return this._isChanged;
  }

  get title(): string {
    return this._title;
  }

  set title(value: string) {
    this._title = value;
    this._isChanged = true;
  }

  get orderBy(): string {
    return this._orderBy;
  }

  set orderBy(value: string) {
    this._orderBy = value;
    this._isChanged = true;
  }

  get desc(): boolean {
    return this._desc;
  }

  set desc(value: boolean) {
    this._desc = value;
    this._isChanged = true;
  }
}
