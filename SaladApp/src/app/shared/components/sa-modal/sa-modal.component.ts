import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output
} from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'sa-modal',
  templateUrl: 'sa-modal.component.html',
  styleUrls: [ './sa-modal.component.css' ],
})
export class SaModalComponent {
  constructor() { }

  @Input() showModal: boolean;
  @Output() onClose = new EventEmitter(false);

  private readonly BODY_MODAL_OPEN = 'modal-open';

  ngOnInit() { }

  ngOnDestroy() {
    this.removeBodyModalOpenClass();
  }

  ngOnChanges(changes: any /* SimpleChanges typing not working */) {
    if (changes.showModal) {
      this.triggerVisibility();
    }
   }

   close() : void {
    if (!this.showModal) {
      return;
    }

    this.onClose.emit();
   }

   private triggerVisibility() : void {
     if (this.showModal) {
       this.addBodyModalOpenClass();
     } else {
       this.removeBodyModalOpenClass();
     }
   }

   private addBodyModalOpenClass() : void {
     if (!document.body.classList.contains(this.BODY_MODAL_OPEN)) {
      document.body.classList.add(this.BODY_MODAL_OPEN);
     }
   }

   private removeBodyModalOpenClass() : void {
     if (document.body.classList.contains(this.BODY_MODAL_OPEN)) {
      document.body.classList.remove(this.BODY_MODAL_OPEN);
     }
   }
}
