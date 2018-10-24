import { RouterModule, Routes } from "@angular/router";
import { Component } from '@angular/core';
import { LugarcenaComponent } from "./lugarcena/lugarcena.component";


const pagesRoutes: Routes = [

// {path: '', component:,data:{}}
{path: 'lugarcena', component: LugarcenaComponent ,data:{titulo:'Lugar Cena'}}


];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
