import { RouterModule, Routes } from "@angular/router";
import { Component } from '@angular/core';
import { LugarcenaComponent } from "./lugarcena/lugarcena.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { AgendaComponent } from "./agenda/agenda.component";
import { VerificaTokenGuard } from "../services/guards/verifica-token.guard";
import { CategoriaComponent } from "./paquetes/categoria/categoria.component";
import { ServicioComponent } from "./paquetes/servicio/servicio.component";
import { PaqueteComponent } from "./paquetes/paquete/paquete.component";
import { PaqueteServicioComponent } from "./paquetes/paquete-servicio/paquete-servicio.component";
import { MasterFileComponent } from "./masterfile/master-file/master-file.component";


const pagesRoutes: Routes = [

// {path: '', component:,data:{}}
{path: 'dashboard', component: DashboardComponent ,data:{titulo:'Dashborad'}, canActivate:[VerificaTokenGuard]},
{path: 'lugarcena', component: LugarcenaComponent ,data:{titulo:'Lugar Cena'}},
{path: 'agenda/:abc', component: AgendaComponent ,data:{titulo:'Agenda'}},
{path: 'categoria', component: CategoriaComponent ,data:{titulo:'Categoria de Servicios'}},
{path: 'servicios', component: ServicioComponent ,data:{titulo:'Servicios'}},
{path: 'paquetes', component: PaqueteComponent ,data:{titulo:'Paquetes'}},
{path: 'paqueteservicio/:id', component: PaqueteServicioComponent ,data:{titulo:'Paquetes Servicio'}},
// id de la agenda - la consulta lo hace por id agenda y id hotel
{path: 'masterfile/:ida', component: MasterFileComponent ,data:{titulo:'Master File'}},

{path: '', redirectTo: '/dashboard', pathMatch : 'full'}

];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
