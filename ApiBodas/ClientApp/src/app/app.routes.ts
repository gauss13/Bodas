import { Routes, RouterModule } from "@angular/router";
import { PagesComponent } from "./pages/pages.component";
import { LugarcenaComponent } from "./pages/lugarcena/lugarcena.component";


const appRoutes: Routes = [

    { path:'', component:PagesComponent, 
    loadChildren:'./pages/pages.module#PagesModule'
}
];

export const APP_ROUTES = RouterModule.forRoot(appRoutes, {useHash: true});