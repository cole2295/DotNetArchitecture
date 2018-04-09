import { Injectable } from "@angular/core";

declare var UIkit: any;

@Injectable()
export class ModalService {
	public alert(message): void {
		UIkit.modal.alert(message);
	}
}
