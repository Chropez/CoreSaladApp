import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Salad } from '../shared/models/salad';
import { FormSelectOption } from '../shared/components/form/form-select/form-select.component';

@Component({
  moduleId: module.id,
  selector: 'new-salad-form',
  templateUrl: 'new-salad-form.component.html',
  styleUrls: ['new-salad-form.component.css']
})
export class NewSaladFormComponent {
  constructor(private formBuilder : FormBuilder) {
    this.model = new Salad(0, '', '', 0, 50);
    this.buildForm();
  }

  public form : FormGroup;
  public model : Salad;

  private buildForm() {
    this.form = this.formBuilder.group({
      name:        [ this.model.name, Validators.required  ],
      ingredients: [ this.model.ingredients, Validators.maxLength(5) ],
      saladType:   [ this.model.saladType.toString(), Validators.required],
      price:       [ this.model.price ]
    });
  }

  public saladTypeOptions : FormSelectOption[] = [
    new FormSelectOption(0, 'Grön'),
    new FormSelectOption(1, 'Pasta')
  ];

  public errorMessages : Object = {
    name : {
      required: 'Namn måste anges'
    },
    ingredients: {
      maxLength: 'Kan vara högst 5 tecken'
    },
    saladType: {
      required: 'Salladstyp måste anges'
    }
  }

  @Output() public onSubmit = new EventEmitter();

  public submit() {
    let s = this.form;
    debugger;
    this.onSubmit.emit(this.model);
  }
}
