import { Injectable } from "@angular/core";
import { ReplaySubject } from "rxjs/ReplaySubject";
import { HttpService } from "./http.service";

@Injectable()
export class ApplicationService {
	private application = new ReplaySubject(1);

	constructor(private readonly httpService: HttpService) { }

	public get() {
		if (!this.application.observers.length) {
			this.httpService.get("ApplicationService/Get").subscribe(
				(response) => {
					this.application.next(response);
				},
				(error) => {
					this.application.error(error);
					this.application = new ReplaySubject(1);
				});
		}

		return this.application;
	}
}
