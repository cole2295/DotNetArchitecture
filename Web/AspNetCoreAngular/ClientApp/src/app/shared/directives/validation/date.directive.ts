import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";
import CleaveDate = require('cleave.js');

@Directive({ selector: "[date]", host: { "(input)": "onInput($event)" } })
export class DateDirective {
	public cleaveDate: any;

	@Output() public ngModelChange = new EventEmitter();

	constructor(private elementRef: ElementRef) {
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name)) {
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	public onInit() {
		setTimeout((x) => {
			this.cleaveDate = new CleaveDate(
				`.${this.elementRef.nativeElement.name}`,
				{ date: true, datePattern: ["d", "m", "Y"] }
			);
		}, 0);
	}

	public onInput($event) {
		this.cleaveDate.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}
