import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared/shared.module";
import { LugarcenaComponent } from './lugarcena/lugarcena.component';
import { PAGES_ROUTES } from "./pages.routes";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";



@NgModule({
    declarations:[LugarcenaComponent],
    exports:[LugarcenaComponent],
    imports:[CommonModule, FormsModule, ReactiveFormsModule,
            SharedModule,
            PAGES_ROUTES],

})

export class PagesModule {}