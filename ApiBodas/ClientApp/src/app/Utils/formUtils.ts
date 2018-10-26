
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';


function mostrarErrorx(campo:string, fg:FormGroup, textoDeValidacion: any, errorCampos: any) {

    if (!fg) { return; }
    if (fg.get(campo).valid) { return; }
  
    //if (this.formGroup.get(campo).touched || this.formGroup.get(campo).dirty && !this.formGroup.get(campo).valid)
    if (fg.get(campo).touched && errorCampos[campo] === '' && !fg.get(campo).valid) {
  
      if (textoDeValidacion[campo].required !== 'undefined')
        errorCampos[campo] = textoDeValidacion[campo].required;
    }
  }


 function onCambioValorx(fg:FormGroup, textoDeValidacion: any, errorCampos: any) {

    console.log(' cambio valor');
  
    // console.log(this.errorCampos);
  
    //console.log(this.textoDeValidacion);
  
  
    // no hacer nada
    if (!fg) { return; }
  
    // funcion set error
    const _setTextoError = (control: AbstractControl, errorCampo: any, campo: string) => {
  
      if (control && control.dirty && control.invalid || control.touched) {
  
        // devuleve un objeto con los mensajes de validacion
        const mensajeError = textoDeValidacion[campo];
  
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
    for (const campo in errorCampos) {
      // si en 
      if (errorCampos.hasOwnProperty(campo)) {
  
        // establecemos a vacio el mensaje del campo
        errorCampos[campo] = '';
        //
        _setTextoError(fg.get(campo), errorCampos, campo);
  
      }
  
    }
  
  }


export { mostrarErrorx, onCambioValorx};