import { HttpClient, HttpEvent } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HttpService {
	constructor(private http: HttpClient) { }

	public get<T>(url: string, data?: any): Observable<HttpEvent<T>> | any {
		return this.http.get<T>(this.getUrl(url), data);
	}

	public post<T>(url: string, data?: any): Observable<T> | any {
		return this.http.post<T>(this.getUrl(url), data);
	}

	private getUrl(url: string): string {
		return url.startsWith("http") ? url : document.getElementsByTagName("base")[0].href + url;
	}
}
