import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { LugarcenaService } from "./lugarcena.service";
import { HeaderService } from "./header.service";


@NgModule({

    imports:[CommonModule, HttpClientModule],
    providers:[LugarcenaService, HeaderService],
    declarations:[]

})

export class ServiceModule {}