import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { HotelService } from 'src/app/services/hotel.service';
import { Hotel } from 'src/app/models/hotel.model';
import {mostrarErrorx, onCambioValorx} from '../../../Utils/formUtils';
import { ObjectUnsubscribedError } from 'rxjs';
import { Globalx } from 'src/app/config/global';
import { Router } from '@angular/router';
import { GenericoService } from '../../../services/generico.service';

declare var $: any;

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html'
  
})
export class CategoriaComponent implements OnInit {

  textoDeValidacion: any;
  errorCampos: any;
  modoEdicion: boolean= false;
  ignorarExistenCambiosPendientes: boolean = false;
  selectedId: number=0;
  idEdicion: number = 0;
  cargando: boolean = true;
  uri:string =  '/api/Categoria/';
  fg : FormGroup;


  registroId : number;//categroria id
  listaABorrar: number[] = [];

  registros:any[] = [];// array vacio de catagorias
  totalRegistros : number =0;
  hoteles:Hotel[] = [];// array vacio


  constructor(private fb: FormBuilder,
              private _servicioHotel: HotelService,
              private _gbl: Globalx,
              private router:Router,
              private _servicioGenerico: GenericoService
              ) { 

                this.textoDeValidacion = {
                  hotelid:     { required: 'El campo hotel es <strong>requerido</strong>.'  },
                  descripcion: { required: 'El campo descripcion es <strong>requerido</strong>.'  }                 
                } 


                this.errorCampos = {                 
                  hotelid:   '',
                  descripcion: ' '
                }

              }

  ngOnInit() {

    // HOTEL SELECCIONADO
    if(!this._gbl.hotelSeleccionado)
    {
      this.router.navigate(['/dashboard']);
    }

    this._gbl.tituloModulo ="Categoria de Servicios";

    // GET DATA
    this.construirFormulario();   
    this.cargarHoteles();



   // READY JQUERY
    $(document).ready(function(){

      $('.modal').modal({ onOpenEnd: function () {  $('#lugarc').focus(); }});  
   
    });


  }

// ***************************************************************************************
//  Inicializar el Select 
// ***************************************************************************************
initSelect()
{
  $('select').formSelect();
}



// *************************************GET DATOS*****************************************

cargarHoteles()
{
  this._servicioHotel.GetHoteles().subscribe(  (resp:any) => {
  this.hoteles = resp;
  });
}




// ************************************ CONSTRUIR FORMULARIO  *********************************

formChangesSub: any;

construirFormulario() {

  this.fg = this.fb.group({
    lugar: ['', Validators.required],
    otro: ['', Validators.required],
    hotelid: ['', Validators.required],
    activo: ['', Validators.required]
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



// *********************************** MODALES - CREAR - EDITAR **************************


modalCrear()
{  
  
  this.resetFormulario();
  this.initSelect();
  this.modoEdicion = false;
  this.idEdicion = 0;
  this.selectedId = 0;
  //this.nameField.nativeElement.focus();
 // this.renderer.invokeElementMethod(this.nameField.nativeElement,"focus");
}


modalEdicion(itemE: any)
{

this.modoEdicion = true;
this.idEdicion = itemE.id;
this.selectedId = itemE.hotelId;

this.resetFormulario();



this.fg.patchValue({
  lugar :itemE.lugar,
  otro: 'otro x',
  hotelid: itemE.hotelId,
  activo: itemE.activo
});


this.initSelect();
$('#lugarc').focus();



}


focusInput()
{
  $('#lugarc').focus();
}



// ********************************** GUARDAR - EDITAR ********************************************

save() {

  this.ignorarExistenCambiosPendientes = true;
}



}// END CLASS
