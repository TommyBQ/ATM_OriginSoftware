import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AtmApiService {
  myAppUrl = 'https://localhost:7069';
  MyApiUrl = '/api';

  constructor(private http: HttpClient) { }

  getTarjetas(): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl);
  }

  validarNroTarjeta(nroTarjeta: string): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl + '/Tarjeta/ValidarNroTarjeta/id?nroTarjeta=' + nroTarjeta);
  }

  loguearTarjeta(pin: string): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl + '/Tarjeta/LoguearTarjeta/pin?pin=' + pin);
  }

  cerrarSesion(): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl + '/Tarjeta/CerrarSesion');
  }

  crearBalance(): Observable<any> {
    return this.http.post(this.myAppUrl + this.MyApiUrl + '/Balance/Create', "");
  }

  obtenerDatosTarjetaLogueada(): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl + '/Tarjeta/GetTarjetaLogueada');
  }

  crearRetiro(monto: string): Observable<any> {
    return this.http.post(this.myAppUrl + this.MyApiUrl + '/Retiro/Create?montoARetirar='+ monto, "");
  }

  getRetiros(): Observable<any> {
    return this.http.get(this.myAppUrl + this.MyApiUrl + '/Retiro/GetAll');
  }
}
