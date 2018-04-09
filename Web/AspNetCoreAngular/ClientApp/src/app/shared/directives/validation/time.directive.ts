import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";
import CleaveTime = require('cleave.js');

@Directive({ selector: "[time]", host: { "(input)": "onInput($event)" } })
export class TimeDirective {
	public cleaveTime: any;

	@Output() public ngModelChange = new EventEmitter();

	constructor(private elementRef: ElementRef) {
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name)) {
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	public onInit() {
		// setTimeout(x => { this.cleaveTime = new CleaveTime(`.${this.elementRef.nativeElement.name}`, {}); }, 0);
	}

	public onInput($event) {
		// this.cleaveTime.onChange();
		// this.ngModelChange.emit($event.target.value);
	}
}
