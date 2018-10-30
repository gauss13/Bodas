import { RouterModule, Routes } from "@angular/router";
import { Component } from '@angular/core';
import { LugarcenaComponent } from "./lugarcena/lugarcena.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { AgendaComponent } from "./agenda/agenda.component";
import { VerificaTokenGuard } from "../services/guards/verifica-token.guard";


const pagesRoutes: Routes = [

// {path: '', component:,data:{}}
{path: 'dashboard', component: DashboardComponent ,data:{titulo:'Dashborad'}, canActivate:[VerificaTokenGuard]},
{path: 'lugarcena', component: LugarcenaComponent ,data:{titulo:'Lugar Cena'}},
{path: 'agenda', component: AgendaComponent ,data:{titulo:'Agenda'}},

{path: '', redirectTo: '/dashboard', pathMatch : 'full'}

];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
