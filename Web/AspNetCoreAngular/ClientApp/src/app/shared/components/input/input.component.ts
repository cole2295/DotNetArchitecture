import { Component, ElementRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

@Component({
	inputs: ["type"],
	providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputComponent, multi: true }],
	selector: "app-input",
	templateUrl: "./input.component.html"
})
export class AppInputComponent implements ControlValueAccessor {
	public required: any;

	public type: string;

	public value: any;

	constructor(private readonly el: ElementRef) {
		this.required = el.nativeElement.attributes.required;
	}

	public onChange(value: any) { this.writeValue(value); }

	public registerOnChange(fn: any): void { this.onChange = fn; }

	public registerOnTouched(fn: any): void { }

	public setDisabledState(isDisabled: boolean): void { }

	public writeValue(obj: any): void { this.value = obj; }
}
