import { RouterModule, Routes } from "@angular/router";
import { Component } from '@angular/core';
import { LugarcenaComponent } from "./lugarcena/lugarcena.component";
import { DashboardComponent } from "./dashboard/dashboard.component";


const pagesRoutes: Routes = [

// {path: '', component:,data:{}}
{path: 'dashboard', component: DashboardComponent ,data:{titulo:'Lugar Cena'}},
{path: 'lugarcena', component: LugarcenaComponent ,data:{titulo:'Lugar Cena'}}


];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
