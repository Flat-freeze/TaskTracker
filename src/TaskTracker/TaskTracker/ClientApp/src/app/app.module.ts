import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {ApiAuthorizationModule} from 'src/api-authorization/api-authorization.module';
import {AuthorizeInterceptor} from 'src/api-authorization/authorize.interceptor';
import {AccordionModule} from 'primeng/accordion'; //accordion and accordion tab
import {ButtonModule} from "primeng/button";
import {MessagesModule} from "primeng/messages";
import {RatingModule} from "primeng/rating";
import {ToolbarModule} from "primeng/toolbar";
import {FileUploadModule} from "primeng/fileupload";
import {ConfirmationService, MessageService} from "primeng/api";
import {TableModule} from "primeng/table";
import {RippleModule} from "primeng/ripple";
import {ToastModule} from "primeng/toast";
import {DialogModule} from "primeng/dialog";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {InputTextModule} from "primeng/inputtext";
import {InputTextareaModule} from "primeng/inputtextarea";
import {PaginatorModule} from "primeng/paginator";
import { TeamListComponent } from './team/team-list/team-list.component';
import {PanelMenuModule} from "primeng/panelmenu";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TeamListComponent,
  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        ApiAuthorizationModule,
        AppRoutingModule,
        AccordionModule,
        ButtonModule,
        MessagesModule,
        RatingModule,
        ToolbarModule,
        FileUploadModule,
        TableModule,
        RippleModule,
        ToastModule,
        DialogModule,
        ConfirmDialogModule,
        BrowserAnimationsModule,
        InputTextModule,
        InputTextareaModule,
        PaginatorModule,
        PanelMenuModule
    ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true},
    MessageService, ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
