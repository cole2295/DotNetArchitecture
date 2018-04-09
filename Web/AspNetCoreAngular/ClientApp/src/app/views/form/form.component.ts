import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Option } from "../../shared/models/option.model";
import { FormChildModel } from "./form.child.model";
import { FormModel } from "./form.model";

@Component({ selector: "app-form", templateUrl: "./form.component.html" })
export class FormComponent {
	public disabled: boolean = false;
	public model: FormModel;
	public options: Option[];
	public reactiveForm: FormGroup;

	constructor(private readonly formBuilder: FormBuilder) {
		this.createOptions();
		this.createModel();
		this.createReactiveForm();
	}

	public createOptions() {
		this.options = new Array<Option>();

		for (let i = 1; i <= 10; i++) {
			this.options.push(new Option(`Option ${i}`, i));
		}
	}

	public createModel() {
		this.model = new FormModel();
		this.model.child = new FormChildModel();
	}

	public createReactiveForm() {
		this.reactiveForm = this.formBuilder.group({
			child: this.formBuilder.group({
				string: []
			}),
			number: [],
			string: []
		});
	}

	public templateFormSubmit(form) {
	}

	public templateFormSearch() {
	}

	public reactiveFormSubmit(form) {
	}

	public reactiveFormsSearch() {
	}
}
