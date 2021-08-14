import { Component, Type, Input, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'ngbd-modal-confirm',
  templateUrl: './modal-focus.component.html'
})
export class ModalFocusComponent {

 
  constructor( public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }
  delete() {
    
    this.activeModal.close(true);
  }
  cancel() {
    this.activeModal.close(false);
  }
  
}
