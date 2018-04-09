import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";
import CleaveInteger = require('cleave.js');

@Directive({ selector: "[integer]", host: { "(input)": "onInput($event)" } })
export class IntegerDirective {
	public cleaveInteger: any;

	@Output() public ngModelChange = new EventEmitter();

	constructor(private elementRef: ElementRef) {
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name)) {
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	public onInit() {
		setTimeout((x) => {
			this.cleaveInteger = new CleaveInteger(
				`.${this.elementRef.nativeElement.name}`,
				{ blocks: [20], numericOnly: true }
			);
		}, 0);
	}

	public onInput($event) {
		this.cleaveInteger.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}
