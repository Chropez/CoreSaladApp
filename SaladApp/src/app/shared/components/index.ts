import { SaNavbarComponent } from './sa-navbar/sa-navbar.component';
import { SaModalComponent } from './sa-modal/sa-modal.component';
import { SaModalHeaderComponent, SaModalBodyComponent, SaModalFooterComponent } from './sa-modal/sa-modal-helpers.components';

import { FormInputComponent } from './form/form-input/form-input.component';
import { FormTextareaComponent } from './form/form-textarea/form-textarea.component';
import { FormSelectComponent } from './form/form-select/form-select.component';
import { FormGeneralComponent } from './form/form-general.component';

export let SharedComponents : Array<any> = [
  SaNavbarComponent,
  SaModalComponent,
  SaModalHeaderComponent,
  SaModalBodyComponent,
  SaModalFooterComponent,

  FormInputComponent,
  FormTextareaComponent,
  FormSelectComponent,
  FormGeneralComponent
];
