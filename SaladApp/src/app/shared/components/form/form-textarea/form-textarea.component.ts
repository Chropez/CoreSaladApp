import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, ControlValueAccessor } from "@angular/forms";

import { MakeProvider, AbstractValueAccessor } from '../abstract-value-accessor';
import { IFormGeneral } from '../form-general.component';

@Component({
  moduleId: module.id,
  selector: 'form-textarea',
  templateUrl: 'form-textarea.component.html',
  providers: [ MakeProvider(FormTextareaComponent) ]
})

export class FormTextareaComponent extends AbstractValueAccessor implements IFormGeneral {
  constructor() {
    super();
  }

  @Input('value') _value : string;
  @Input() formControl: FormControl = new FormControl();

  // IFormGeneral properties
  @Input() label: string;
  @Input() isRequired: boolean;
  @Input() errorMessages: Object;
}
