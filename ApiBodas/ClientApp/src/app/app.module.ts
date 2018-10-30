import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PagesComponent } from './pages/pages.component';
import { SharedModule } from './shared/shared.module';
import { APP_ROUTES } from './app.routes';
import { ServiceModule } from './services/services.modules';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login/login.component';
// import { AutofocusDirective } from './directives/autofocus.directive';

@NgModule({
  declarations: [
    AppComponent,    
    PagesComponent, LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
FormsModule,
ReactiveFormsModule,
    APP_ROUTES,
    AppRoutingModule,
    SharedModule,
    ServiceModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
