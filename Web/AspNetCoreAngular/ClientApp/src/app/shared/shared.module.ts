import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { ComponentsModule } from "./components/components.module";
import { DirectivesModule } from "./directives/directives.module";
import { GuardsModule } from "./guards/guards.module";
import { HandlersModule } from "./handlers/handlers.module";
import { InterceptorsModule } from "./interceptors/interceptors.module";
import { ServicesModule } from "./services/services.module";

@NgModule({
	exports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		ComponentsModule,
		DirectivesModule,
		GuardsModule,
		HandlersModule,
		InterceptorsModule,
		ServicesModule
	],
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,

		ComponentsModule,
		DirectivesModule,
		GuardsModule,
		HandlersModule,
		InterceptorsModule,
		ServicesModule
	]
})
export class SharedModule { }
