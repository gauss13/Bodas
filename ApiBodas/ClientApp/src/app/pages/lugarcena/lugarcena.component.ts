import { Component, OnInit } from '@angular/core';
import { LugarCena } from '../../models/lugarcena.model';
import { LugarcenaService } from 'src/app/services/service.index';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';

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


//Definicion de variables
lugares:LugarCena[] = [];// array vacio
totalRegistros : number =0;


// formGroup = new  FormGroup({
//   lugar : new FormControl(''),
//   hotelid : new FormControl(''),
//   activo : new FormControl('')
// });

constructor(public _servicio: LugarcenaService, private fb: FormBuilder) { 

// ***************************************************************************************
// 2 Mensaje de validacion del formulario 
// ***************************************************************************************
this.textoDeValidacion = {
  Lugar: { required: 'El campo Lugar es <strong>requerido</strong>.' },
  HotelId: { required: 'Seleccione un Hotel <strong>requerido</strong>.' },
  activo: { required: 'El campo activo es <strong>requerido</strong>.'  }
}

// ***************************************************************************************
//  3 Validacion inicial
// ***************************************************************************************
this.errorCampos = {
  Lugar: '',
  HotelId: '',
  activo: ''
}

} // <- contructor

fg : FormGroup;

ngOnInit() {
  this.construirFormulario();
  this.cargarLugares();
}



// captura evento
 formChangesSub: any;



// ***************************************************************************************
//  Contruir Formulario 
// ***************************************************************************************
construirFormulario() {

this.fg = this.fb.group({
  lugar: ['', Validators.required]
});

this.formChangesSub = this.fg.valueChanges.subscribe( data => this.onCambioValor());

this.fg.touched;

}

// ***************************************************************************************
//   Muestra el mensaje de error
// ***************************************************************************************
mostrarError(campo) {


  if (!this.fg) { return; }
  if (this.fg.get(campo).valid) { return; }


  //if (this.formGroup.get(campo).touched || this.formGroup.get(campo).dirty && !this.formGroup.get(campo).valid)
  if (this.fg.get(campo).touched && this.errorCampos[campo] === '' && !this.fg.get(campo).valid) {

    if (this.textoDeValidacion[campo].required !== 'undefined')
      this.errorCampos[campo] = this.textoDeValidacion[campo].required;

  }


}

// ***************************************************************************************
//   Cambio Valor
// ***************************************************************************************
onCambioValor() {

  console.log(' cambio valor');

  // no hacer nada
  if (!this.fg) { return; }

  // funcion set error
  const _setTextoError = (control: AbstractControl, errorCampo: any, campo: string) => {

    if (control && control.dirty && control.invalid) {

      // devuleve un objeto con los mensajes de validacion
      const mensajeError = this.textoDeValidacion[campo];

      for (const item in control.errors) {

        // revisamos si errors tiene la propiedad con el nombre del item
        if (control.errors.hasOwnProperty(item)) {
          // buscamos en 
          errorCampo[campo] = mensajeError[item] + '<br>';
        }

      }

    }

  };

  // Revisamos los errors por campo
  for (const campo in this.errorCampos) {
    // si en 
    if (this.errorCampos.hasOwnProperty(campo)) {

      // establecemos a vacio el mensaje del campo
      this.errorCampos[campo] = '';
      //
      _setTextoError(this.fg.get(campo), this.errorCampos, campo);

    }

  }

}







existenCambiosPendientes(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.fg.pristine; //pristine indica si el formulario ha sido editado

}







  


// ***************************************************************************************
//  Cargar los lugares de cena 
// ***************************************************************************************

cargarLugares() {

  console.log('carga inicial');

  this._servicio.GetLugaresCena().subscribe( (resp:any) => {

    console.log(resp);

this.totalRegistros = this._servicio.totalLugaresCena;
this.lugares = resp.lugarCena;

console.log(resp.lugarCena);

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


}




}
