import { Component, OnInit, Input, EventEmitter, Output, ViewChild } from '@angular/core';

import { NewSaladFormComponent } from './new-salad-form.component'
import { Salad } from '../shared/models/salad';

@Component({
  moduleId: module.id,
  selector: 'new-salad',
  templateUrl: 'new-salad.component.html'
})
export class NewSaladComponent {
  constructor() { }

  @Input() show : boolean = false;
  @Output() onHide = new EventEmitter(false);
  @Output() onAddNewSalad = new EventEmitter(false);

  @ViewChild(NewSaladFormComponent) saladForm : NewSaladFormComponent;

  closeNewSaladModal() {
    this.show = false;
    this.onHide.emit();
  }

  submitForm() {
    this.saladForm.submit();
  }

  onSubmitForm(salad : Salad) {
    debugger;
  }
}
