import { Component, OnInit } from '@angular/core';
import { LugarCena } from '../../models/lugarcena.model';
import { LugarcenaService } from 'src/app/services/service.index';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { HotelService } from 'src/app/services/hotel.service';
import { Hotel } from 'src/app/models/hotel.model';
import {mostrarErrorx, onCambioValorx} from '../../Utils/formUtils';
 
declare var $: any;

@Component({
  selector: 'app-lugarcena',
  templateUrl: './lugarcena.component.html',
  styles: []
})
export class LugarcenaComponent implements OnInit {

  // ***************************************************************************************
  //  1 - VARIABLES - Validacion formulario
  // ***************************************************************************************
textoDeValidacion: any;
errorCampos: any;
modoEdicion: boolean= false;
lugarId : number;
lugaresABorrar: number[] = [];
ignorarExistenCambiosPendientes: boolean = false;
// 
fg : FormGroup;

//Definicion de variables
lugares:LugarCena[] = [];// array vacio
totalRegistros : number =0;
hoteles:Hotel[] = [];// array vacio


constructor(public _servicio: LugarcenaService,
            private fb: FormBuilder,
            private _servicioHotel: HotelService) { 

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

  this.construirFormulario();
  this.cargarLugares();
  this.cargarHoteles();

  $(document).ready(function(){
    $('.modal').modal();  
  });
        
}

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

  //console.log('carga inicial');

  this._servicio.GetLugaresCena().subscribe( (resp:any) => {

   // console.log(resp);

this.totalRegistros = this._servicio.totalRegistros;
this.lugares = resp.lugarCena;

//console.log(resp.lugarCena);

  });
}

cargarHoteles()
{
  this._servicioHotel.GetHoteles().subscribe(  (resp:any) => {
  this.hoteles = resp;

  console.log(resp);

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

  // "10000".replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") # => "10,000"
  let itemLugar: LugarCena = Object.assign({}, this.fg.value)

console.log(itemLugar);

this._servicio.Crear(itemLugar).subscribe( (resp:any) => {


  console.log(resp);

});

}




}
