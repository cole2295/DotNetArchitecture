import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";
import CleaveDecimal = require('cleave.js');

@Directive({ selector: "[decimal]", host: { "(input)": "onInput($event)" } })
export class DecimalDirective {
	public cleaveDecimal: any;

	@Output() public ngModelChange = new EventEmitter();

	constructor(private elementRef: ElementRef) {
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name)) {
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	public onInit() {
		setTimeout((x) => {
			this.cleaveDecimal = new CleaveDecimal(`.${this.elementRef.nativeElement.name}`, {
				delimiter: ".",
				numeral: true,
				numeralDecimalMark: ",",
				numeralDecimalScale: 2,
				numeralIntegerScale: 20,
			});
		}, 0);
	}

	public onInput($event) {
		this.cleaveDecimal.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}
