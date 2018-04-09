import { Component } from "@angular/core";

import { HttpService } from "../../shared/services/http.service";

@Component({ selector: "app-service", templateUrl: "./service.component.html" })
export class ServiceComponent {
	public list: any;

	constructor(private readonly httpService: HttpService) {
		const url = "https://jsonplaceholder.typicode.com/users";
		this.httpService.get(url).subscribe((response) => this.list = response);
	}
}
