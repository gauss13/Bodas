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

import { Categoria } from '../../../models/categoria.model';
import { Departamento } from 'src/app/models/departamento.model';
import { uriServicio, uriDepartamento, uriCategoria, uriDepartamentoServicio } from 'src/app/config/config';



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
  textoDeValidacionCat: any;
  errorCamposCat: any;

  modoEdicion: boolean= false;
  setDataComplete:boolean= false;
  ignorarExistenCambiosPendientes: boolean = false;
  selectedId: number=0;
  idEdicion: number = 0;
  cargando: boolean = true;  
  fg : FormGroup;
  fgcat : FormGroup;

 

  registroId : number;//categroria id
  listaABorrar: number[] = [];

  registros:any[] = [];// array vacio de catagorias
  totalRegistros : number =0;
  hoteles:Hotel[] = [];// array vacio
  divisas:any[] = [];
  categorias:any[] = [];
  departamentos:Departamento[] = [];

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
        divisa: { required: 'El campo divisa es <strong>requerido</strong>.'  }  ,
        nota: { required: 'El campo nota es <strong>requerido</strong>.'  }         

      } 

      this.textoDeValidacionCat = {       
            
        descripcion: { required: 'El campo nombre de servicio es <strong>requerido</strong>.'  }      

      } 


      this.errorCampos = {                 
        descripcion: '',
        categoriaId: '',
        precioSugerido: '',
        divisa: '',
        nota: ''
      }

      this.errorCamposCat = {                 
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
 
     // GET DATA
     this.construirFormulario();   
     this.construirFormularioCat();
    //  this.cargarHoteles();
    //  this.GetDivisas();
    //this.GetCategorias();
    this.loadData()
    this.GetDepartamentos();
   // this.setDataLeft();

 
    // READY JQUERY
     $(document).ready(function(){
 
       $('.modal').modal({ onOpenEnd: function () {  $('#lugarc').focus(); }});  
    
     });

// cargar servicios
//this.cargaServicios(); 

  }

  // ***************************************************************************************
//  Inicializar el Select 
// ***************************************************************************************
initSelect()
{
  $('select').formSelect();
}

// *************************************GET DATOS*****************************************



loadData()
{
 
     if(this.GetCategorias())
     {
       this.cargaServicios();
     }
   
}


cargaServicios()
{  const url = uriServicio+this._gbl.hotelIdSelected;
  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

    if(resp.ok === true)
    {
         this.registros = resp.servicio;

         this.totalRegistros = resp.total;        
    }
},
    (error) => {},
    () => { 
        this.setDataPromesa().then();
    }
);

this.cargando = false;
}


setDataPromesa(): Promise<boolean> {

return new Promise<boolean>( (resolve, reject ) => {

let contador = 0;

const intervalo = setInterval(() => {

contador += 1;

console.log('contador : '+ contador);

if( this.setDataComplete === false)
this.setDataLeft();

if(contador === 3)
{
  clearInterval(intervalo);
  resolve(true); 
}

},500);



})

}

setDataLeft()
{


if(this.categorias.length > 0 && this.divisas.length > 0 && this.registros.length > 0)
{
  for(var i= 0; i < this.registros.length; i++)
  {    
        if(this.categorias.length > 0 && this.divisas.length > 0)
        {          
          let itemCat = this.categorias.find( item => { return  item.id === this.registros[i].categoriaId });
          // let itemDiv = this.divisas.find( item => { return  item.id === this.registros[i].divisa });

             if(itemCat !== 'undefined')
             {
               this.registros[i].strCategoria = itemCat.descripcion;
              //  this.registros[i].strDivisa = itemDiv.clave;
             }

        }//cat       

  }//for

  this.setDataComplete = true;
}  

}



GetCategorias()
{
  const url = uriCategoria + '/'+this._gbl.hotelIdSelected;
  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) =>  {

    if(resp.ok == true)
    {
      this.categorias = resp.categoria;  

      return true;
    }

  });

  return true;
}

GetDepartamentos()
{

  const url = uriDepartamento + '/'+this._gbl.hotelIdSelected;

  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

      if(resp.ok === true)
      {
       this.departamentos = resp.departamento;
      
      // this.departamentos[0].selected = true;     
            
      }
  })

}

GetDepartamentoServicio(ids:number)
{
  this.InicializarSelectDepartamentos();
  const url = uriDepartamentoServicio + ids;

  this._servicioGenerico.GetRegistros(url).subscribe( (resp:any) => {

    if(resp.ok === true)
    {
      for(var i= 0; i < this.departamentos.length; i++)
      {
             var iteme = resp.dservicio.find( ds => {return ds.departamentoId === this.departamentos[i].id });

            if(iteme !== undefined)
            {
              this.departamentos[i].selected = true;
            }
      }
  }

 });

}

InicializarSelectDepartamentos()
{
  this.departamentos.forEach(function(ele, index) {        
      ele.selected = false;
  });
}

// ************************************ CONSTRUIR FORMULARIO  *********************************

formChangesSub: any;


construirFormulario() {

  this.fg = this.fb.group({
    descripcion: ['', Validators.required],
    categoriaId: ['', Validators.required],
    precioSugerido: [0, Validators.required],
    divisa: ['USD', Validators.required],
    nota: ['', Validators.required],
    activo: ['', Validators.required]
    // departamento: ['', Validators.required]
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

/****************************** FORMULARIO DE CATEGORIA ************************************/


formChangesSubCat: any;

  construirFormularioCat() {



    this.fgcat = this.fb.group( {
      descripcion: ['', Validators.required]    
    });
    
    // manejador del evento de cambio de valor en los inputs
    this.formChangesSubCat = this.fgcat.valueChanges.subscribe( data => this.onCambioValorCat());
    
    // this.fgcat.touched;
    
    // this.fgcat.markAsTouched();
    
    }

  mostrarErrorCat(campo){
    mostrarErrorx(campo, this.fgcat, this.textoDeValidacionCat, this.errorCamposCat);
    }

onCambioValorCat()
{
  onCambioValorx( this.fgcat, this.textoDeValidacionCat, this.errorCamposCat);
}

existenCambiosPendientesCat(): boolean {

  if (this.ignorarExistenCambiosPendientes) { return false;}

  return !this.fgcat.pristine; //pristine indica si el formulario ha sido editado

}

resetFormularioCat() {
  this.fgcat.reset();
  //this.selectedId = 0;
}




// *********************************** MODALES - CREAR - EDITAR **************************


modalCrear()
{ 
  this.resetFormulario();
  this.InicializarSelectDepartamentos();
  this.initSelect();
  this.modoEdicion = false;
  this.idEdicion = 0;
  this.selectedId = 0;
  //this.nameField.nativeElement.focus();
  // this.renderer.invokeElementMethod(this.nameField.nativeElement,"focus");
}

modalCrearCat()
{  
  
  this.resetFormularioCat();

}


modalEdicion(itemE: any)
{

this.modoEdicion = true;
this.idEdicion = itemE.id;
this.selectedId = itemE.hotelId;

this.resetFormulario();

this.GetDepartamentoServicio(itemE.id);


this.fg.patchValue({
 

  descripcion:itemE.descripcion ,
  categoriaId:itemE.categoriaId ,
  precioSugerido:itemE.precioSugerido ,
  divisa:itemE.divisa ,
  nota:itemE.nota ,
  activo:itemE.activo 


});


this.initSelect();

$('#descripcionc').focus();

$('select').formSelect();

}


focusInput()
{
  $('#descripcionc').focus();
}


// ********************************** GUARDAR - EDITAR ********************************************

save() {

  this.ignorarExistenCambiosPendientes = true;

  var url = uriServicio;

if(!this.modoEdicion)
{
  let itemNuevo: Servicio = Object.assign({}, this.fg.value)

  itemNuevo.hotelId = this._gbl.hotelIdSelected;
  var depasArray = $('#multidepa').val();


this._servicioGenerico.CrearRegisto(itemNuevo,url).subscribe((resp:any) =>{

//validar ok
if(resp.ok === true)
{
  var itemdb:Servicio;
  itemdb = resp.servicio;

  let itemCat = this.categorias.find( item => { return  item.id === itemdb.categoriaId });
  // let itemDiv = this.divisas.find( item => { return  item.id === itemdb.divisa });

  itemdb.strCategoria = itemCat.descripcion;
  // itemdb.strDivisa = itemDiv.clave;


  this.registros.push(resp.servicio)
  M.toast({html: '<strong> Se agregó el nuevo registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  

  //registrar la configuracion depa-servicio
  
      var depaservicio:any=[];

      for(var i =0;  i< depasArray.length; i++)
      {
        var itds = {ServicioId:itemdb.id, DepartamentoId:depasArray[i]}
        depaservicio.push(itds);

      }

      var url = uriDepartamentoServicio+'/'+itemdb.id;
        this._servicioGenerico.CrearRegisto(depaservicio,url).subscribe((resp:any) => {
            console.log('deap-serv:' , resp);
      });
  //



}
});


}
else // ACTUALIZAR
{

  var urle = uriServicio + this.idEdicion;

  let itemEditado: Servicio = Object.assign({}, this.fg.value)

  itemEditado.hotelId = this._gbl.hotelIdSelected;

  this._servicioGenerico.Actualizar(itemEditado,urle).subscribe((resp:any) =>{
  
  //validar ok
        if(resp.ok === true)
        {
             //Actualizar array
             let itemEncontrado = this.registros.find( item => item.id === this.idEdicion);

             let pos = this.registros.indexOf(itemEncontrado);

             var itemdb:Servicio;
             itemdb = resp.servicio;


             let itemCat = this.categorias.find( item => { return  item.id === itemdb.categoriaId });
            //  let itemDiv = this.divisas.find( item => { return  item.id === itemdb.divisa });

            //  itemdb.strCategoria = itemCat.descripcion;
            //  itemdb.strDivisa = itemDiv.clave;

             this.registros[pos] = itemdb;

             M.toast({html: '<strong> Se actualizó el nuevo registro, correctamente. <strong>', classes:' rounded  pink darken-2'});  
        }

  });


}


}


saveCategoria()
{
  this.ignorarExistenCambiosPendientes = true;

  var url = uriCategoria;

  let itemNuevo: Categoria = Object.assign({}, this.fgcat.value)

  itemNuevo.hotelId = this._gbl.hotelIdSelected;

console.log(itemNuevo);

this._servicioGenerico.CrearRegisto(itemNuevo,url).subscribe((resp:any) =>{

//validar ok
if(resp.ok === true)
{
 
  this.categorias.push(resp.categoria)
  M.toast({html: '<strong> Se agregó el nuevo registro Categoria, correctamente. <strong>', classes:' rounded  pink darken-2'});  
}
});





}



borrar(item:any)
{

}


}
