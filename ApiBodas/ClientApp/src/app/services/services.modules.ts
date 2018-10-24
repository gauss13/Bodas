import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { LugarcenaService } from "./lugarcena.service";


@NgModule({

    imports:[CommonModule, HttpClientModule],
    providers:[LugarcenaService],
    declarations:[]

})

export class ServiceModule {}