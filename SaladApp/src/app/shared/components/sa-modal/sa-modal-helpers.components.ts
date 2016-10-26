import { Component } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'sa-modal-header',
  template: `<ng-content></ng-content>`
})
export class SaModalHeaderComponent { }

@Component({
  moduleId: module.id,
  selector: 'sa-modal-body',
  template: `<ng-content></ng-content>`
})
export class SaModalBodyComponent { }

@Component({
  moduleId: module.id,
  selector: 'sa-modal-footer',
  template: `<ng-content></ng-content>`
})
export class SaModalFooterComponent { }
