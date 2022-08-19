import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { TecladoNumericoComponent } from './components/teclado-numerico/teclado-numerico.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { OperacionesComponent } from './components/operaciones/operaciones.component';
import { BalanceComponent } from './components/balance/balance.component';
import { RetiroComponent } from './components/retiro/retiro.component';
import { InfoRetiroComponent } from './components/info-retiro/info-retiro.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    TecladoNumericoComponent,
    OperacionesComponent,
    BalanceComponent,
    RetiroComponent,
    InfoRetiroComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SweetAlert2Module.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
