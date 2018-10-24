import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PagesComponent } from './pages/pages.component';
import { SharedModule } from './shared/shared.module';
import { APP_ROUTES } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,    
    PagesComponent
  ],
  imports: [

    BrowserModule,
    APP_ROUTES,
    AppRoutingModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
