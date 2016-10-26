import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from "@angular/forms";

import { MakeProvider, AbstractValueAccessor } from '../abstract-value-accessor';
import { IFormGeneral } from '../form-general.component';

@Component({
  moduleId: module.id,
  selector: 'form-input',
  templateUrl: 'form-input.component.html',
  providers: [ MakeProvider(FormInputComponent) ]
})
export class FormInputComponent extends AbstractValueAccessor implements IFormGeneral {
  constructor() {
    super();
   }

  @Input() type: string = 'text';
  @Input('value') _value : string;

  // IFormGeneral properties
  @Input() label: string;
  @Input() formControl: FormControl = new FormControl();
  @Input() errorMessages: Object;

}
