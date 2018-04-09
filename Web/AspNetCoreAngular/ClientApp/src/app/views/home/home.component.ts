import { Component } from "@angular/core";

import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({ selector: "app-home", templateUrl: "./home.component.html" })
export class HomeComponent {
	constructor(private readonly authenticationService: AuthenticationService) { }

	public authenticated() {
		this.authenticationService.getAuthenticated();
	}
}
