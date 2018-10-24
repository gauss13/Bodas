import { NgModule } from "@angular/core";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { HeaderComponent } from './header/header.component';



@NgModule({

    imports:[RouterModule, CommonModule],
    declarations:[SidebarComponent, HeaderComponent],
    exports:[SidebarComponent, HeaderComponent]

})

export class SharedModule { }