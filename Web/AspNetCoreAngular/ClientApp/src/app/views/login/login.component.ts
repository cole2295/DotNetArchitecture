import { Component } from "@angular/core";

import { AuthenticationModel } from "../../shared/models/authentication.model";
import { ApplicationService } from "../../shared/services/application.service";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class LoginComponent {
	public authenticationModel = new AuthenticationModel();

	constructor(
		private readonly applicationService: ApplicationService,
		private readonly authenticationService: AuthenticationService
	) {
		this.authenticationService.logout();
		this.authenticationModel.login = "admin";
		this.authenticationModel.password = "admin";
	}

	public submit() {
		this.authenticationService.authenticate(this.authenticationModel);
	}

	public authenticated() {
		this.authenticationService.getAuthenticated();
	}

	public callServerOnlyOnce() {
		this.applicationService.get().subscribe((response) => {
			alert(response);
		});
	}
}
