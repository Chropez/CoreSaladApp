import {
  Component,
  Input,
  Output,
  EventEmitter,
  Provider,
  forwardRef
} from '@angular/core';

import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  FormControl
} from "@angular/forms";

export function MakeProvider(type : any){
  return {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => type),
    multi: true
  };
}

export abstract class AbstractValueAccessor implements ControlValueAccessor {
  public _value: string = '';
  get value() { return this._value; }
  set value(val:string) {
    debugger;
    if (!val || this._value === val) {
      return;
    }

    this._value = val;
    this.onChange(val);
    this.onTouched();
  }
  onChange: any = () => { };
  onTouched: any = () => { };
  writeValue(val: string): void {
    if (val) {
      this.value = val;
    }
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
}
