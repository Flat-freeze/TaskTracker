import { Component, OnInit } from '@angular/core';
import {OperationResult} from "../../interfaces/operation-result";
import {PagedList} from "../../interfaces/paged-list";
import {TeamService} from "../team.service";
import {ConfirmationService, MessageService} from "primeng/api";
import {Team} from "../team";

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.less']
})
export class TeamListComponent implements OnInit {
  Raw: OperationResult<PagedList<Team>>;
  Result: PagedList<Team>;

  Team: Team;

  SelectedTeams: Team[] | null;

  TeamDialog: boolean;

  submitted: boolean;

  constructor(private teamService: TeamService, private confirmationService: ConfirmationService, private messageService: MessageService) {
  }

  ngOnInit(): void {
    setInterval(() => this.refreshData(), 300000)
    this.refreshData();
  }

  openNew() {
    this.Team = {};
    this.submitted = false;
    this.TeamDialog = true;
    console.log(this.TeamDialog);
  }

  refreshData() {
    this.teamService.getPage().subscribe((data) => {
      this.updateTable(data);
      console.log(this.Raw)
    }, (err)=>{
      console.log(err);
    });
  }

  updateTable(data: OperationResult<PagedList<Team>>){
    this.Raw = data;
    if (this.Raw.ok) this.Result = this.Raw.result; else console.error(this.Raw.logs);
  }

  deleteSelected() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.teamService.deleteMany(this.SelectedTeams).subscribe(this.subscription("Team","Deleted"));
        this.SelectedTeams = null;
      }
    });
  }

  edit(team: Team) {
    this.Team = {...team};
    this.TeamDialog = true;
  }

  delete(team: Team) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + team.title + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.teamService.delete(team).subscribe(this.subscription("Team", "Deleted"));
        this.Team = {};
      },
    });
  }

  hideDialog() {
    this.TeamDialog = false;
    this.submitted = false;
  }

  save() {
    this.submitted = true;
    if (this.Team.title?.trim()) {
      if (this.Team.id) {
        this.teamService.update(this.Team).subscribe(this.subscription("Team", "Updated"));
      } else {
        this.teamService.add(this.Team).subscribe(this.subscription("Team", "Created"));
      }

      this.Result.source = [...this.Result.source];
      this.TeamDialog = false;
      this.Team = {};
    }
  }

  getValue(event: Event): string {
    return (event.target as HTMLInputElement).value;
  }

  subscription(targetName: string, action: string) {
    return {
      next: (data: any) => {
        this.messageService.add({severity: 'success', summary: 'Successful', detail: `${targetName} ${action}`, life: 3000});
        console.log(data);
      },
      error: (err: Error) => {
        this.messageService.add({severity: 'error', summary: 'Error', detail: `${targetName} not ${action}`, life: 3000});
        console.error(err);
      },
      complete: () => {
        this.refreshData()
      }
    }
  }

  paginate(event: any) {
    //event.first = Index of the first record
    //event.rows = Number of rows to display in new page
    //event.page = Index of the new page
    //event.pageCount = Total number of pages
    this.teamService.getPage(event.page, 7).subscribe((data)=>{
      this.updateTable(data);
      console.log(data);
    }, (err)=>{
      console.log(err);
    });
  }
}
