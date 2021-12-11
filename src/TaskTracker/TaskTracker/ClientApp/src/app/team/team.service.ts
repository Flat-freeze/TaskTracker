import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {OperationResult} from "../interfaces/operation-result";
import {PagedList} from "../interfaces/paged-list";
import {Team} from "./team";

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private readonly apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.apiUrl = baseUrl + "api/team";
  }

  public getPage(pageNumber: number = 0, pageCount = 7) {
    console.log(pageNumber.toString()+" | "+pageCount.toString());
    return this.http.get<OperationResult<PagedList<Team>>>(this.apiUrl +`?page=${pageNumber+1}&count=${pageCount}`);
  }

  public add(team: Team) {
    return this.http.post(this.apiUrl, team);
  }

  public deleteMany(selectedTeams: Team[] | null) {
    return this.http.post(this.apiUrl + "/delete", selectedTeams);
  }

  public delete(team: Team) {
    return this.http.delete(this.apiUrl + "/" + team.id, {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    });
  }

  public update(team: Team) {
    return this.http.put(this.apiUrl+"/"+team.id, team);
  }
}
