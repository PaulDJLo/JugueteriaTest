import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IProducto } from '../productos/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  private createProductURL = this.baseUrl + "api/CreateProduct/Create";
  private updateProductURL = this.baseUrl + "api/UpdateProduct/Update/";
  private retrieveProductByIdURL = this.baseUrl + "api/RetrieveById/GetById/";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  createProducto(product: IProducto): Observable<IProducto> {
    return this.http.post<IProducto>(this.createProductURL, product);
  }

  updateProducto(id: String, product: IProducto): Observable<IProducto> {

    return this.http.post<IProducto>(this.updateProductURL + id, product);
  }

  retrieveProductById(personaId: string): Observable<any> {

    return this.http.get<any>(this.retrieveProductByIdURL + personaId);
  }
}
