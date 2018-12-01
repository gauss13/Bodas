import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, FormArray, FormControl, ReactiveFormsModule   } from '@angular/forms';
import { Globalx } from 'src/app/config/global';
import { Router, ActivatedRoute } from '@angular/router';

import {  GenericoService  } from 'src/app/services/service.index';
import {mostrarErrorx, onCambioValorx, roundx} from '../../../Utils/formUtils';
import { Paquete } from 'src/app/models/paquete.model';

import { uriPaquete, uriServicio, uriPaqueteServicio  } from 'src/app/config/config';
import { PaqueteServicio } from 'src/app/models/paqueteservicio.model';
import { isNumber } from 'util';
import { alertSuccess, alertWarning } from '../../../config/config';

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
  addServicio: boolean = false;
  ignorarExistenCambiosPendientes: boolean = false;
  selectedId: number=0;
  idEdicion: number = 0;
  cargando: boolean = false;  
  fg : FormGroup;
  totalPaquete:number = 0;
  totalPaqueteReal:number = 0;

  paquete:any;
  // divisas:any[];
  servicios:any[];
  pqserv:PaqueteServicio[]=[];

  servicioSelected:number[]=[];

  registroId : number;//categroria id


  constructor(private fb: FormBuilder,  
              private _gbl: Globalx,
              private router:Router, 
              public activatedRoute: ActivatedRoute,
              private _servicioGenerico: GenericoService
               ) {

                this.textoDeValidacion = {       
             
                  descripcion: { required: 'El campo nombre de servicio es <strong>requerido</strong>.'  } , 
                  divisa: { required: 'El campo divisa  es <strong>requerido</strong>.'  } 
              
                }
                
                this.errorCampos = {                 
                  descripcion: '',
                  divisa:''                 
                }
          
                //PARAMS
                activatedRoute.params.subscribe(params => {

                  const id = params['id'];            

                  if( id !== 'nuevo') {
                        this.modoEdicion = true;
                        this.selectedId = id;
                    
                  }
                  
          });



               }

  ngOnInit() {

    this.construirFormulario('','',1,0);
    // HOTEL SELECCIONADO
    if(!this._gbl.hotelSeleccionado)
    {
      this.router.navigate(['/dashboard']);
    }
  
    this._gbl.tituloModulo ="Categoria de Servicios";

      // GET data init
      // this.GetDivisas();

      if(this.modoEdicion )
      {
        console.log('modo edicion');
       // this.construirFormulario(this.paquete.descripcion, this.paquete.clave, this.paquete.divisaId, this.paquete.total);
       this.GetDatosPaquete(this.selectedId);
       this.GetServiciosPaquete();

      }       
      

    // READY JQUERY
    $(document).ready(function(){
 

      //$('.collapsible').collapsible();

      // $('.modal').modal({ onOpenEnd: function () {  $('#lugarc').focus(); }});  
      
    });
    
    
    setTimeout(function(){  
      
      $('select').formSelect(); 
      M.updateTextFields(); 
    },3000);

  }


initSelect()
{


  $('select').formSelect();


}


// *************************************GET DATOS*****************************************

// GetDivisas()
// {
//     this._divisaService.GetDivisas().subscribe( (resp:any) => {

//         if(resp.ok)
//         {      
//            this.divisas = resp.divisa;   
//            this.initSelect();
//         }
//     });

// }

GetDatosPaquete(id:number)
{
  let url = uriPaquete+ this._gbl.hotelIdSelected+'/'+id;

      this._servicioGenerico.GetRegistros(url).subscribe((resp:any) => {

        if(resp.ok === true)
        {
            this.paquete = resp.paquete;
    
            this.totalPaquete = resp.paquete.total;
            this.totalPaqueteReal = resp.paquete.total;

          this.fg.patchValue({    
          descripcion: resp.paquete.descripcion,
          clave: resp.paquete.clave,
          divisa: resp.paquete.divisa,
          total: resp.paquete.total,
          nota: resp.paquete.nota,
        });

        }

      });
}
// ************************************ CONSTRUIR FORMULARIO  *********************************

formChangesSub: any;

construirFormulario(des:string, clave:string, idd:number, total:number) {

  this.fg = this.fb.group({    
    descripcion: ['', Validators.required],
    clave: ['', Validators.required],
    divisa: ['', Validators.required],
    total: ['0.00', Validators.required],
    nota: ['', Validators.required]    
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

  if(!this.modoEdicion )
  {
    var url = uriPaquete;

    let itemNuevo: Paquete = Object.assign({}, this.fg.value);

    itemNuevo.hotelId = this._gbl.hotelIdSelected;
    itemNuevo.activo = true;

    this._servicioGenerico.CrearRegisto(itemNuevo,url).subscribe((resp:any) =>{

      //validar ok
      if(resp.ok === true)
      {
        this.selectedId = resp.paquete.id;
        this.addServicio = true;
        this.modoEdicion = true;
        this.paquete = resp.paquete;
        M.toast({html: '<strong> Se agregó el nuevo registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  

        // mostrar servicios
        this.GetServiciosPaquete();
      }

    });
  }
  else //Actualizar
  {
    var url = uriPaquete +  this.selectedId;
    let itemNuevo: Paquete = Object.assign({}, this.fg.value);

    itemNuevo.hotelId = this._gbl.hotelIdSelected;

    this._servicioGenerico.Actualizar(itemNuevo,url).subscribe((resp:any) =>{

      //validar ok
      if(resp.ok === true)
      {
        this.addServicio = true;
        this.modoEdicion = true;
        M.toast({html: '<strong> Se actualizó el registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  
        this.GetServiciosPaquete();
      }

    });
  }


}

// ********************************* GET DATA SERVICIOS  ****************************************************

GetServiciosPaquete()
{

  
  const url = uriPaqueteServicio +this._gbl.hotelIdSelected +'/' + this.selectedId;

  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

    if(resp.ok === true)
    {      
         this.servicios = resp.servicio;                 
    }
},
    (error) => {},
    () => { //complete
        
    }
);

}

// ********************************* FORMULARIO ADD SERVICIO **************************************

cambioAgregar(event, sta:number, item:any)
{

  item.selected = !item.selected;

if(item.selected)
{
 
  const url = uriPaqueteServicio;

  this._servicioGenerico.CrearRegisto(item, url).subscribe((resp:any) => {

      if(resp.ok === true)
      {
        
        //this.totalPaqueteReal += item.total;

        this.actualizarPaqueteTotal();

        M.toast({html: '<strong> Se agregó el servicio al paquete. <strong>', classes:alertSuccess});  
      }
      else
      {
        M.toast({html: resp.mensaje, classes:alertWarning});  
        // this.actualizarPaqueteTotal();
      }

  });

}
else // quitar 
{
  const url = uriPaqueteServicio + item.paqueteId+'/'+item.servicioId;

  this._servicioGenerico.Borrar(url).subscribe((resp:any) => {

      if(resp.ok === true)
      {
        //this.totalPaqueteReal -= item.total;
        this.actualizarPaqueteTotal();
        M.toast({html: '<strong> Se quitó el servicio del paquete. <strong>', classes:' rounded  pink darken-2'});  
        
      }

  });

}

 

}

actualizarPaqueteTotal()
{ 
    var url = uriPaquete +'total/'+  this.selectedId;
  
    this._servicioGenerico.Actualizar(this.paquete,url).subscribe((resp:any) =>{
  
    //validar ok
    if(resp.ok === true)
    {
      this.totalPaqueteReal = resp.paquete.total;      
      this.fg.patchValue({  total: this.totalPaqueteReal });
    }
  
  });
  
}





setPrecio(precio, item:any)
{
  if(isNaN(precio))
  {
    M.toast({html: '<strong> Solo se aceptan numeros <strong>', classes:' rounded  pink darken-2'}); 

    return;
  }
  
  
  
if(precio.length <= 0) 
{
  item.changeValue= false;
  return;
} 

  let r = precio * item.cantidad;

  item.total = r;
  item.changeValue= true;
  this.sumarTotalServicios();
}


setCantidad(cantidad, item:any)
{

  if(isNaN(cantidad))
  {
    M.toast({html: '<strong> Solo se aceptan numeros <strong>', classes:' rounded  pink darken-2'}); 

    return;
  }


  if(cantidad.length <= 0)
  {
    item.changeValue= false;
    return;
  } 

    let r = cantidad * item.precioUnitario;
    item.total = r;
    item.changeValue= true;
    this.sumarTotalServicios();
}


sumarTotalServicios()
{
    var totalr = 0;

   this.servicios.forEach(function(ele){  

    if(ele.selected)
    totalr += ele.total;

   });
   
    this.totalPaquete = roundx(totalr,2); //totalr;
}

sumarTotalServiciosPromise()
{

return new Promise((resolve, reject ) => {

  var totalr = 0;

  this.servicios.forEach(function(ele){  

   if(ele.selected)
       totalr += ele.total;

  });
  
      this.totalPaquete = roundx(totalr,2); //totalr;

     resolve(this.totalPaquete);

});//fin promesa

    
}




RegCambio(item:any)
{
     //guardar cambio

    if(item.selected)
    {     
      
      const url = uriPaqueteServicio + item.servicioId;

      this._servicioGenerico.Actualizar(item, url).subscribe((resp:any) => {
    
          if(resp.ok === true)
          {

            M.toast({html: '<strong> Se actualizó el servicio al paquete. <strong>', classes:' rounded  pink darken-2'});  
          
           // this.totalPaqueteReal += item.total;

            this.actualizarPaqueteTotal();
            item.changeValue = false;

          }
    
      });
    
    }

}




}
