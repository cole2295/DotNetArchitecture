import { Component, ElementRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";
import { Option } from "../../models/option.model";

@Component({
	inputs: ["options"],
	providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectComponent, multi: true }],
	selector: "app-select",
	templateUrl: "./select.component.html"
})
export class AppSelectComponent implements ControlValueAccessor {
	public options: Option[];

	public required: any;

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
