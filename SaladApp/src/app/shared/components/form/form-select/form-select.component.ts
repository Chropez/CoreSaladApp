import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from "@angular/forms";

import { MakeProvider, AbstractValueAccessor } from '../abstract-value-accessor';
import { IFormGeneral } from '../form-general.component';

export class FormSelectOption {
  constructor(public value:any, public label:string) { }
}

@Component({
  moduleId: module.id,
  selector: 'form-select',
  templateUrl: 'form-select.component.html',
  providers: [ MakeProvider(FormSelectComponent) ]
})
export class FormSelectComponent extends AbstractValueAccessor implements IFormGeneral {
  constructor() {
    super();
   }

  @Input('value') _value : string;
  @Input() options: FormSelectOption[];
  @Input() errorMessages: Object;

  // IFormGeneral properties
  @Input() label: string;
  @Input() formControl: FormControl = new FormControl();
}

