import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { DataSharingService } from './services/datasharing.service';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        LayoutModule,
        SharedModule,
        HttpClientModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot({
            timeOut: 3000,
            extendedTimeOut: 1000,
            progressBar: true,
            enableHtml: true,
            closeButton: true,
            tapToDismiss: true,
            progressAnimation: 'increasing',
        })
    ],
    providers: [
        CookieService,
        DataSharingService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
