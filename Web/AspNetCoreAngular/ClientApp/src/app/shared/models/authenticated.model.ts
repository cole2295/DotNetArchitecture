export class AuthenticatedModel {
	constructor(public userId: number, public roles: number[]) {
		this.roles = new Array<number>();
	}
}
