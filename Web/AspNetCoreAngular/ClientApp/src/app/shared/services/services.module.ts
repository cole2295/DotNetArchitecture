import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";

import { ApplicationService } from "./application.service";
import { AuthenticationService } from "./authentication.service";
import { HttpService } from "./http.service";
import { ModalService } from "./modal.service";
import { ValidationService } from "./validation.service";

@NgModule({
	imports: [
		HttpClientModule
	],
	providers: [
		ApplicationService,
		AuthenticationService,
		HttpService,
		ModalService,
		ValidationService
	]
})
export class ServicesModule { }
