import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { HomeService } from './home.service';
import { IProducto } from '../productos/product';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ModalFocusComponent } from '../modal-focus/modal-focus.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  productos: any[];
  constructor(private router: Router, private homeService: HomeService, public modalService: NgbModal) {

  }
  ngOnInit() {
    this.cargarData();
  }
  delete(productoId: string) {
    
    const modalRef = this.modalService.open(ModalFocusComponent);

    modalRef.result.then((result) => {
      
      if (result === true) {
        
        this.homeService.deleteProduct(productoId)
          .subscribe(p => this.cargarData(),
            error => console.error(error));
      }
    });
  }
  cargarData() {
    this.homeService.getProductos().subscribe(personasdesdews =>
      this.productos = personasdesdews, error => console.error(error));
  }
}

