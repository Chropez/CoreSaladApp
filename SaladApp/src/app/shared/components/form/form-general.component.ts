import { Component, Input, Output, ElementRef } from '@angular/core';
import { FormControl, ControlValueAccessor } from '@angular/forms';

import { MakeProvider, AbstractValueAccessor } from './abstract-value-accessor';

@Component({
  moduleId: module.id,
  selector: 'form-general',
  templateUrl: './form-general.component.html',
  styleUrls: ['./form-general.component.css'],
  providers: [ MakeProvider(FormGeneralComponent)]
})
export class FormGeneralComponent extends AbstractValueAccessor implements IFormGeneral {
  constructor() {
    super();
   }

  @Input() formControl: FormControl;
  @Input() label: string;
  @Input() errorMessages: Object = {};

  //@Input() isRequired: boolean = false;
  @Input() isRequiredErrorMessage: string = '';

  get isRequired(): any {
    return this.formControl.validator !== null
      && this.formControl.validator(this.formControl) !== null
      && this.formControl.validator(this.formControl)['required'];
  }

  get isValid() : boolean {
    return this.formControl.valid && !this.formControl.pristine;
  }

  get isInvalid() : boolean {
    return !this.formControl.valid && !this.formControl.pristine;
  }

  get hasFeedback() : boolean {
    return this.isValid || this.isInvalid;
  }

}

export interface IFormGeneral {
  label: string;
  formControl: FormControl;
  errorMessages: Object;
}
