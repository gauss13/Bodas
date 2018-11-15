
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

   // console.log(' cambio valor');
  
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


  function roundx(value, precision) {
    var multiplier = Math.pow(10, precision || 0);
    return Math.round(value * multiplier) / multiplier;
  }

// espera una fecha en formato dd-MM-yyyyT00:00:00
 function dateFormatYYYYMMDDx(f:string)
  {
    
    if(f === null)
    return null;
console.log(f);

         var separateTime = f.split("T");

         var str = separateTime[0].split("-");

         var strFecha = `${str[0]}-${str[1]}-${str[2]}`

         return strFecha;  
  
  }
//espera una fecha en formato dd/MM/yyyy y retorna yyyy/MM/dd
  function dateFormatYYYYMMDDxD(f:string)
  {
    
      var str = f.split("/");
  
      var strFecha = `${str[2]}-${str[1]}-${str[0]}`
      
      return strFecha;
    
  }

export { mostrarErrorx, onCambioValorx, roundx, dateFormatYYYYMMDDx, dateFormatYYYYMMDDxD};