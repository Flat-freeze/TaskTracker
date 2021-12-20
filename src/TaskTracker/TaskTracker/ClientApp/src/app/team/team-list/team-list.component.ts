import {Component, OnInit} from '@angular/core';
import {OperationResult} from "../../interfaces/operation-result";
import {PagedList} from "../../interfaces/paged-list";
import {TeamService} from "../team.service";
import {ConfirmationService, MenuItem, MessageService} from "primeng/api";
import {Team} from "../team";
import {TeamFilter} from "../team-filter";

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.less']
})
export class TeamListComponent implements OnInit {
  Raw: OperationResult<PagedList<Team>>;
  Result: PagedList<Team>;
  Filter: TeamFilter;
  Team: Team;

  CurrentPage: number = 1;
  PageSize: number = 5;

  SelectedTeams: Team[] | null;

  TeamDialog: boolean;

  submitted: boolean;
  Columns: any[];

  items: MenuItem[];

  constructor(private teamService: TeamService, private confirmationService: ConfirmationService, private messageService: MessageService) {
    this.Filter = new TeamFilter();
  }

  ngOnInit(): void {
    // setInterval(() => this.refreshData(), 1000)
    this.refreshData();
    this.Columns = [
      { field: 'title', header: 'Title' },
      { field: 'description', header: 'Description' },
    ];
  }

  refreshData(page = this.CurrentPage-1) {
    this.teamService.getPage(page , this.PageSize, this.Filter).subscribe((data) => {
      this.updateTable(data);
      console.log(this.Raw)
    }, (err) => {
      console.log(err);
    });
  }

  updateTable(data: OperationResult<PagedList<Team>>) {
    this.Raw = data;
    if (this.Raw.ok) {
      this.Result = this.Raw.result;
      this.CurrentPage = this.Result.pageNumber;
      this.PageSize = this.Result.pageSize;
    } else console.error(this.Raw.logs);
  }

  deleteSelected() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected products?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.teamService.deleteMany(this.SelectedTeams).subscribe(this.subscription("Team", "Deleted"));
        this.SelectedTeams = null;
      }
    });
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

  getValue(event: Event): string {
    return (event.target as HTMLInputElement).value;
  }

  subscription(targetName: string, action: string) {
    return {
      next: (data: any) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: `${targetName} ${action}`,
          life: 3000
        });
        console.log(data);
      },
      error: (err: Error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: `${targetName} not ${action}`,
          life: 3000
        });
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
    this.refreshData(event.page);
  }

  filter(title: string) {
    this.Filter.title = title;
    this.refreshData();
  }
  log(log: any){
    console.log(log);
  }
  //region dialog

  openNew() {
    this.Team = {};
    this.submitted = false;
    this.TeamDialog = true;
  }

  edit(team: Team) {
    this.Team = {...team};
    this.TeamDialog = true;
  }

  cancel() {
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

      this.refreshData();
      this.TeamDialog = false;
      this.Team = {};
    }
  }
  //endregion
}
