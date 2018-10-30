import { Routes, RouterModule } from "@angular/router";
import { PagesComponent } from "./pages/pages.component";
import { LugarcenaComponent } from "./pages/lugarcena/lugarcena.component";
import { Component } from '@angular/core';
import { LoginComponent } from "./login/login/login.component";
import { LoginGuardGuard } from "./services/service.index";


const appRoutes: Routes = [

    {path: 'login', component: LoginComponent},
    { path:'', component:PagesComponent, canActivate:[LoginGuardGuard], loadChildren:'./pages/pages.module#PagesModule'
}
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, {useHash: true});