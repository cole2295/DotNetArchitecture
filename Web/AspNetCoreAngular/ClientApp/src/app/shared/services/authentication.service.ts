import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationModel } from "../models/authentication.model";
import { HttpService } from "./http.service";
import { ModalService } from "./modal.service";

declare var UIkit: any;

@Injectable()
export class AuthenticationService {
	private token: string = "token";

	constructor(
		private readonly httpService: HttpService,
		private readonly modalService: ModalService,
		private readonly router: Router) { }

	public authenticate(authenticationModel: AuthenticationModel) {
		this.httpService.post("AuthenticationService/Authenticate", authenticationModel).subscribe((response) => {
			this.setToken(response);
			this.router.navigate(["/home"]);
		});
	}

	public getAuthenticated() {
		this.httpService.get("AuthenticationService/GetAuthenticatedUserId").subscribe((response) => {
			this.modalService.alert(`Authenticated UserId: ${response}`);
		});
	}

	public logout() {
		if (!this.isAuthenticated()) { return; }

		this.httpService.post("AuthenticationService/Logout").subscribe((response) => {
			this.setToken();
			this.router.navigate(["/login"]);
		});
	}

	public isAuthenticated() {
		return this.getToken() !== null;
	}

	public getToken() {
		return sessionStorage.getItem(this.token);
	}

	private setToken(token: string = null) {
		if (token) {
			sessionStorage.setItem(this.token, token);
		} else {
			sessionStorage.removeItem(this.token);
		}
	}
}
