import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ExchangeRoutingModule } from './exchange-routing.module';
import { ExchangeComponent } from './exchange.component';


@NgModule({
  declarations: [ExchangeComponent],
  imports: [SharedModule,ExchangeRoutingModule]
})
export class ExchangeModule { }
