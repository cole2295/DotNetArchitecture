import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";
import CleaveCurrency = require('cleave.js');

@Directive({ selector: "[currency]", host: { "(input)": "onInput($event)" } })
export class CurrencyDirective {
	public cleaveCurrency: any;

	@Output() public ngModelChange = new EventEmitter();

	constructor(private elementRef: ElementRef) {
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name)) {
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	public onInit() {
		setTimeout((x) => {
			this.cleaveCurrency = new CleaveCurrency(`.${this.elementRef.nativeElement.name}`, {
				delimiter: ".",
				numeral: true,
				numeralDecimalMark: ",",
				numeralDecimalScale: 2,
				numeralIntegerScale: 20,
				prefix: "R$ ",
			});
		}, 0);
	}

	public onInput($event) {
		this.cleaveCurrency.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}
