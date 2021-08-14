import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IProducto } from './product';
import { ProductosService } from './productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html'
})
/** productos component*/
export class ProductosComponent implements OnInit {
  /** productos ctor */
  constructor(private router: Router,
    private activatedRoute: ActivatedRoute, private fb: FormBuilder, private productoService: ProductosService) {
  }
  modoEdicion: boolean = false;
  productoId: number;
  cancelar: boolean = false;
  
  formGroup: FormGroup;
  ngOnInit() {
    
    this.formGroup = this.fb.group({

      Nombre: ['', [Validators.required, Validators.maxLength(50)]],
      Precio: ['',[ Validators.required, Validators.min(1), Validators.max(1000)]],
      Compania: ['', [Validators.required, Validators.maxLength(50)]],
      Descripcion: [' ', [Validators.maxLength(100)]],
      RestriccionEdad: [' ',[ Validators.min(0), Validators.max(100)]]
    });
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }
      this.modoEdicion = true;

      this.productoId = params["id"];

      this.productoService.retrieveProductById(this.productoId.toString())
        .subscribe(product => this.cargarFormulario(product),
          error => this.router.navigate(["/personas"]));
    });

  }

  cargarFormulario(producto: any) {
    this.formGroup = this.fb.group({

      Nombre: [producto.nombre, [Validators.required, Validators.maxLength(50)]],
      Precio: [producto.precio, [Validators.required, Validators.min(1), Validators.max(1000)]],
      Compania: [producto.compania, [Validators.required, Validators.maxLength(50)]],
      Descripcion: [producto.descripcion, [Validators.maxLength(100)]],
      RestriccionEdad: [producto.restriccionEdad, [Validators.min(0), Validators.max(100)]]
    });
    //this.formGroup.patchValue({
    //  Id: producto.id,
    //  Nombre: producto.nombre,
    //  Precio: producto.precio,
    //  Compania: producto.compania,
    //  Descripcion: producto.descripcion,
    //  RestriccionEdad: producto.restriccionEdad
    //});
    
  }

  save() {
    
    let prod: IProducto = Object.assign({}, this.formGroup.value);
    console.table(prod);
    
    if (this.modoEdicion) {
     
      //prod.Id = this.productoId;
      //let cadena: String = "Id: " + prod.Id + "Nombre: " + prod.Nombre + "Precio: " + prod.Precio + "Compañia: " + prod.Compania + "edad: " + prod.RestriccionEdad + "Descripcion: " + prod.Descripcion;
      //alert(cadena);
      this.productoService.updateProducto(this.productoId.toString(), prod)
        .subscribe(p => this.onSaveSuccess(),
          error => console.error(error));
    } else {
     
      this.productoService.createProducto(prod)
        .subscribe(p => this.onSaveSuccess(),
          error => console.error(error));
    }
  }

  onSaveSuccess() {
    this.router.navigate(["/"]);
  }
}
