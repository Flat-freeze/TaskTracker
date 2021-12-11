import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthorizeGuard} from '../api-authorization/authorize.guard';
import {HomeComponent} from './home/home.component';
import {TeamListComponent} from "./team/team-list/team-list.component";

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'teams', component: TeamListComponent, canActivate: [AuthorizeGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
