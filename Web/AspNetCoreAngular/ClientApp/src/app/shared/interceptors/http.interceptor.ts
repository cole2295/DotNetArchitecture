import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import "rxjs/add/operator/do";
import { AuthenticationService } from "../services/authentication.service";

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {
	private authenticationService: AuthenticationService;

	constructor(private readonly injector: Injector) { }

	public intercept(request: HttpRequest<any>, next: HttpHandler) {
		this.authenticationService = this.injector.get(AuthenticationService);

		request = request.clone({
			setHeaders: {
				Authorization: `Bearer ${this.authenticationService.getToken()}`
			}
		});

		return next.handle(request).do((event: HttpEvent<any>) => {
			if (event instanceof HttpResponse) { /* Response */ }
		});
	}
}
