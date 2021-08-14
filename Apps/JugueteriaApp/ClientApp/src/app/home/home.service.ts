import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProducto } from '../productos/product';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private retrieveAllProductsUrl = this.baseUrl + "api/RetrieveAllProducts/Getall";
  private deleteProductUrl = this.baseUrl + "api/DeleteProduct/Delete";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  getProductos(): Observable<any[]> {
    
    return this.http.get<any[]>(this.retrieveAllProductsUrl);
  }

  deleteProduct(productoId: string): Observable<IProducto> {
    return this.http.delete<IProducto>(this.deleteProductUrl + "/" + productoId);
  }
}
