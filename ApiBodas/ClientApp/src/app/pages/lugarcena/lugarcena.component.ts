import { Component, OnInit, ViewChild, ElementRef, Renderer } from '@angular/core';
import { LugarCena } from '../../models/lugarcena.model';
import { LugarcenaService, HeaderService } from 'src/app/services/service.index';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { HotelService } from 'src/app/services/hotel.service';
import { Hotel } from 'src/app/models/hotel.model';
import {mostrarErrorx, onCambioValorx} from '../../Utils/formUtils';
import { ObjectUnsubscribedError } from 'rxjs';
import { Globalx } from 'src/app/config/global';
import { Router } from '@angular/router';
 
declare var $: any;

@Component({
  selector: 'app-lugarcena',
  templateUrl: './lugarcena.component.html',
  styles: []
})
export class LugarcenaComponent implements OnInit {

  @ViewChild("lugarh") nameField: ElementRef;

  // ***************************************************************************************
  //  1 - VARIABLES - Validacion formulario
  // ***************************************************************************************
textoDeValidacion: any;
errorCampos: any;
modoEdicion: boolean= false;
lugarId : number;
lugaresABorrar: number[] = [];
ignorarExistenCambiosPendientes: boolean = false;
selectedId: number=0;
idEdicion: number = 0;
cargando: boolean = true;
// 
fg : FormGroup;

//Definicion de variables
lugares:LugarCena[] = [];// array vacio
totalRegistros : number =0;
hoteles:Hotel[] = [];// array vacio


constructor(public _servicio: LugarcenaService,
            private fb: FormBuilder,
            private _servicioHotel: HotelService,
            private _headerService: HeaderService,
            private renderer: Renderer,
            private _gbl: Globalx,
            private router:Router
     ) { 

// ***************************************************************************************
// 2 Mensaje de validacion del formulario 
// ***************************************************************************************
this.textoDeValidacion = {
  lugar: { required: 'El campo Lugar es <strong>requerido</strong>.' },
  otro: { required: 'El campo otro es <strong>requerido</strong>.' },
  hotelid: { required: 'Seleccione un Hotel <strong>requerido</strong>.' },
  activo: { required: 'El campo activo es <strong>requerido</strong>.'  }
}

// ***************************************************************************************
//  3 - Validacion inicial - 
// ***************************************************************************************
this.errorCampos = {
  lugar: ' ',
  otro: ' ',
  hotelid: ' ',
  activo: ' '
}

} // <- contructor



ngOnInit() {

if(!this._gbl.hotelSeleccionado)
{
  this.router.navigate(['/dashboard']);
}

  this._gbl.tituloModulo ="Lu Cena";
  //this._headerService.setTitle('lugar Cena xx');

  this.construirFormulario();
  this.cargarLugares();
  this.cargarHoteles();

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

// captura evento
 formChangesSub: any;



// ***************************************************************************************
//  Contruir Formulario 
// ***************************************************************************************
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

// ***************************************************************************************
//   Muestra el mensaje de error 123
// ***************************************************************************************
mostrarError(campo){
mostrarErrorx(campo, this.fg, this.textoDeValidacion, this.errorCampos);
}

// mostrarError(campo)
// {
//   if (!this.fg) { return; }

//   if (this.fg.get(campo).valid) { return; }

//   //if (this.formGroup.get(campo).touched || this.formGroup.get(campo).dirty && !this.formGroup.get(campo).valid)
//   if (this.fg.get(campo).touched && this.errorCampos[campo] === '' && !this.fg.get(campo).valid) {

//     if (this.textoDeValidacion[campo].required !== 'undefined')
//       this.errorCampos[campo] = this.textoDeValidacion[campo].required;

//   }

// }



// ***************************************************************************************
//   Cambio Valor
// ***************************************************************************************

onCambioValor()
{
  onCambioValorx( this.fg, this.textoDeValidacion, this.errorCampos);
}

// onCambioValor() {

//   // no hacer nada
//   if (!this.fg) { return; }

//   // funcion set error
//   const _setTextoError = (control: AbstractControl, errorCampo: any, campo: string) => {

// console.log('cmv :', control);

//     if (control && control.dirty && control.invalid || control.touched) {

//       // devuleve un objeto con los mensajes de validacion
//       const mensajeError = this.textoDeValidacion[campo];

//       for (const item in control.errors) {

//         // revisamos si errors tiene la propiedad con el nombre del item
//         if (control.errors.hasOwnProperty(item)) {
//           // buscamos en 
//           errorCampo[campo] = mensajeError[item] + '<br>';
//         }

//       }

//     }

//   };

//   // Revisamos los errors por campo
//   for (const campo in this.errorCampos) {
//     // si en 
//     if (this.errorCampos.hasOwnProperty(campo)) {

//       // establecemos a vacio el mensaje del campo
//       this.errorCampos[campo] = '';
//       //
//       _setTextoError(this.fg.get(campo), this.errorCampos, campo);

//     }

//   }

// }







existenCambiosPendientes(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.fg.pristine; //pristine indica si el formulario ha sido editado

}



// ***************************************************************************************
//  Cargar los lugares de cena 
// ***************************************************************************************

cargarLugares() {

  this._servicio.GetLugaresCena().subscribe( (resp:any) => {
   

this.totalRegistros = this._servicio.totalRegistros;
this.lugares = resp.lugarCena;

this.cargando = false;

  });
}

cargarHoteles()
{
  this._servicioHotel.GetHoteles().subscribe(  (resp:any) => {
  this.hoteles = resp;
  });
}


// ***************************************************************************************
//   Crear
// ***************************************************************************************
crearLugarCena(formulario)
{
console.log(formulario.nuevoLugar);
}

save() {

  this.ignorarExistenCambiosPendientes = true;


if(!this.modoEdicion)
{
  // "10000".replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") # => "10,000"
  let itemLugar: LugarCena = Object.assign({}, this.fg.value)
  this._servicio.Crear(itemLugar).subscribe( (resp:any) => {

// var objR:  LugarCena = {
//   id : resp.id,
//   lugar : resp.lugar,
//   hotelId : resp.hotelId,
//   activo : resp.activo,
//   hotel: { resp.hotel }
// };


this.lugares.push(resp);
this.resetFormulario();

//M.toast({html: 'Se guardo el registro correctamente!'});

});
}
else
{

  let itemEdit: LugarCena = Object.assign({}, this.fg.value);

  this._servicio.Actualizar(this.idEdicion, itemEdit).subscribe(
    (resp:any) =>{

      let itemEncontrado = this.lugares.find( item => item.id === this.idEdicion);

      let pos = this.lugares.indexOf(itemEncontrado);
      
      this.lugares[pos] = resp;

     // M.toast({html: 'Se edito el registro correctamente!', outDuration:400 });

    });

}


}

// ***************************************************************************************
//  BORRAR Lugar Cena 
// ***************************************************************************************
borrarLugar(lugar: LugarCena)
{


  var r = confirm("¿Esta seguro que desea eliminar " + lugar.lugar  +'?');

  if(r)
  {
this._servicio.Borrar(lugar.id).subscribe( borrado => {

let itemEncontrado = this.lugares.find( item => item.id === lugar.id);

let pos = this.lugares.indexOf(itemEncontrado);

this.lugares.splice(pos, 1);


});
}
}

// ***************************************************************************************
//  MODAL  
// ***************************************************************************************
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


// ***************************************************************************************
//  Focus input 
// ***************************************************************************************
 focusInput()
{
  $('#lugarc').focus();
}


// ***************************************************************************************
//  MODAL EDITAR 
// ***************************************************************************************
modalEdicion(itemE: LugarCena)
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

// ***************************************************************************************
//  RESET 
// ***************************************************************************************
resetFormulario() {
  this.fg.reset();
  this.selectedId = 0;
}




}
