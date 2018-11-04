import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
// import { LugarcenaService } from './lugarcena.service';
import { HeaderService } from "./header.service";



import { LoginGuardGuard, LugarcenaService, 
    UsuarioService,
    AgendaService,
    HoraService,
    LugarceremoniaService,
TipoceremoniaService, 
BackupService, PaqueteService, AgenciaService, DivisaService, HotelService } from './service.index';







@NgModule({

    imports:[CommonModule, HttpClientModule],
    providers:[LugarcenaService, 
               HeaderService, 
               LoginGuardGuard, 
               UsuarioService, 
               AgendaService,
               HoraService, 
               LugarceremoniaService,
               TipoceremoniaService, 
               BackupService,
               PaqueteService,
               AgenciaService,
               DivisaService,
            HotelService],
    declarations:[]

})

export class ServiceModule {}