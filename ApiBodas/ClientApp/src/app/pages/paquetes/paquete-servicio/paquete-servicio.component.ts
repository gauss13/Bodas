import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { Globalx } from 'src/app/config/global';
import { Router } from '@angular/router';

import { DivisaService, GenericoService  } from 'src/app/services/service.index';
import {mostrarErrorx, onCambioValorx} from '../../../Utils/formUtils';

declare var $: any;
declare var M: any;

@Component({
  selector: 'app-paquete-servicio',
  templateUrl: './paquete-servicio.component.html',
  styles: []
})
export class PaqueteServicioComponent implements OnInit {


  textoDeValidacion: any;
  errorCampos: any;
  modoEdicion: boolean= false;
  ignorarExistenCambiosPendientes: boolean = false;
  selectedId: number=0;
  idEdicion: number = 0;
  cargando: boolean = false;  
  fg : FormGroup;
  totalPaquete:number = 0;

  divisas:any[];

  registroId : number;//categroria id

  constructor(private fb: FormBuilder,  
              private _gbl: Globalx,
              private router:Router, 
              private _servicioGenerico: GenericoService,
              public _divisaService: DivisaService ) {

                this.textoDeValidacion = {       
             
                  descripcion: { required: 'El campo nombre de servicio es <strong>requerido</strong>.'  }  
              
                }
                
                this.errorCampos = {                 
                  descripcion: ''                  
                }
          

               }

  ngOnInit() {

    // HOTEL SELECCIONADO
    if(!this._gbl.hotelSeleccionado)
    {
      this.router.navigate(['/dashboard']);
    }
  
    this._gbl.tituloModulo ="Categoria de Servicios";

    // GET data init
      this.GetDivisas();
      this.construirFormulario();
      

    // READY JQUERY
    $(document).ready(function(){
 
      // $('.modal').modal({ onOpenEnd: function () {  $('#lugarc').focus(); }});  
      
    });
    
    
    setTimeout(function(){   $('select').formSelect(); }, 3000);

  }


initSelect()
{


  $('select').formSelect();


}


// *************************************GET DATOS*****************************************

GetDivisas()
{
    this._divisaService.GetDivisas().subscribe( (resp:any) => {

        if(resp.ok)
        {      
           this.divisas = resp.divisa;   
           this.initSelect();
        }
    });

}

// ************************************ CONSTRUIR FORMULARIO  *********************************

formChangesSub: any;

construirFormulario() {

  this.fg = this.fb.group({
    descripcion: ['', Validators.required],
    clave: ['', Validators.required],
    divisaId: ['', Validators.required],
    total: ['', Validators.required]    
  });
  
  // manejador del evento de cambio de valor en los inputs
  this.formChangesSub = this.fg.valueChanges.subscribe( data => this.onCambioValor());
  
  this.fg.touched;
  
  this.fg.markAsTouched();
  
  }

 mostrarError(campo){
    mostrarErrorx(campo, this.fg, this.textoDeValidacion, this.errorCampos);
    }

onCambioValor()
{
  onCambioValorx( this.fg, this.textoDeValidacion, this.errorCampos);
}

existenCambiosPendientes(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.fg.pristine; //pristine indica si el formulario ha sido editado

}

resetFormulario() {
  this.fg.reset();
  this.selectedId = 0;
}


// ********************************** GUARDAR - EDITAR ********************************************
save()
{

}



}
