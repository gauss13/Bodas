import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { HotelService } from 'src/app/services/hotel.service';
import { Hotel } from 'src/app/models/hotel.model';
import {mostrarErrorx, onCambioValorx} from '../../../Utils/formUtils';
import { ObjectUnsubscribedError } from 'rxjs';
import { Globalx } from 'src/app/config/global';
import { Router } from '@angular/router';

import { DivisaService, GenericoService  } from 'src/app/services/service.index';
import { Servicio } from 'src/app/models/servicio.model';

declare var $: any;
declare var M: any;

@Component({
  selector: 'app-servicio',
  templateUrl: './servicio.component.html',
  styles: []
})
export class ServicioComponent implements OnInit {

  textoDeValidacion: any;
  errorCampos: any;
  modoEdicion: boolean= false;
  ignorarExistenCambiosPendientes: boolean = false;
  selectedId: number=0;
  idEdicion: number = 0;
  cargando: boolean = true;  
  fg : FormGroup;

  uriServicio:string =  '/api/Servicio/';
  uriCategoria:string =  '/api/Categoria/';
  uriDepartamento:string ='api/';
  uriDepartamentoServicio:string ='api/';

  registroId : number;//categroria id
  listaABorrar: number[] = [];

  registros:any[] = [];// array vacio de catagorias
  totalRegistros : number =0;
  hoteles:Hotel[] = [];// array vacio
  divisas:any;
  categorias:any;

  constructor(private fb: FormBuilder,
    private _servicioHotel: HotelService,
    private _gbl: Globalx,
    private router:Router,
    private _servicioGenerico: GenericoService,
    public _divisaService: DivisaService,
    ) { 

      this.textoDeValidacion = {       
        
        
        descripcion: { required: 'El campo nombre de servicio es <strong>requerido</strong>.'  }  ,
        categoriaId: { required: 'El campo categoria es <strong>requerido</strong>.'  }  ,
        precioSugerido: { required: 'El campo precio Sugerido es <strong>requerido</strong>.'  }  ,
        divisaId: { required: 'El campo divisa es <strong>requerido</strong>.'  }  ,
        nota: { required: 'El campo nota es <strong>requerido</strong>.'  }         

      } 


      this.errorCampos = {                 
        descripcion: '',
        categoriaId: '',
        precioSugerido: '',
        divisaId: '',
        nota: ''
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
    //  this.cargarHoteles();
 this.cargaServicios();
 this.GetDivisas();
 this.GetCategorias();
 
 
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

// cargarHoteles()
// {
//   this._servicioHotel.GetHoteles().subscribe(  (resp:any) => {
//   this.hoteles = resp;
//   });
// }

cargaServicios()
{  const url = this.uriServicio+'/'+this._gbl.hotelIdSelected;
  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

if(resp.ok === true)
{
this.registros = resp.servicio;
this.cargando = false;
}
  });
}

GetDivisas()
{
    this._divisaService.GetDivisas().subscribe( (resp:any) => {
    this.divisas = resp.divisa;
    });
}

GetCategorias()
{
  const url = this.uriCategoria + '/'+this._gbl.hotelIdSelected;
  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) =>  {

    if(resp.ok == true)
    {
      this.categorias = resp.categoria;
    }


  })
}


// ************************************ CONSTRUIR FORMULARIO  *********************************

formChangesSub: any;

construirFormulario() {

  this.fg = this.fb.group({
    descripcion: ['', Validators.required],
    categoriaId: ['', Validators.required],
    precioSugerido: ['', Validators.required],
    divisaId: ['', Validators.required],
    nota: ['', Validators.required],
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
 

  descripcion:itemE.descripcion ,
  categoriaId:itemE.categoriaId ,
  precioSugerido:itemE.precioSugerido ,
  divisaId:itemE.divisaId ,
  nota:itemE.nota ,
  activo:itemE.activo 


});


this.initSelect();

$('#descripcionc').focus();



}


focusInput()
{
  $('#lugarc').focus();
}


// ********************************** GUARDAR - EDITAR ********************************************

save() {

  this.ignorarExistenCambiosPendientes = true;

  var url = this.uriServicio;

if(!this.modoEdicion)
{
  let itemNuevo: Servicio = Object.assign({}, this.fg.value)

this._servicioGenerico.CrearRegisto(itemNuevo,url).subscribe((resp:any) =>{

//validar ok
if(resp.ok === true)
{
  this.registros.push(resp.servicio)
  M.toast({html: '<strong> Se agregó el nuevo registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  
}
});


}
else // ACTUALIZAR
{

  var urle = this.uriServicio + this.idEdicion;

  let itemEditado: Servicio = Object.assign({}, this.fg.value)

  this._servicioGenerico.Actualizar(itemEditado,urle).subscribe((resp:any) =>{
  
  //validar ok
  if(resp.ok === true)
  {
    //Actualizar array
    let itemEncontrado = this.registros.find( item => item.id === this.idEdicion);

    let pos = this.registros.indexOf(itemEncontrado);

    this.registros[pos] = resp.servicio;

    M.toast({html: '<strong> Se actualizó el nuevo registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  
  }
  });


}

}

borrar(item:any)
{

}


}
