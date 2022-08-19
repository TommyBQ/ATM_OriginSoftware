import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AtmApiService } from 'src/app/services/atm-api.service';

@Component({
  selector: 'app-info-retiro',
  templateUrl: './info-retiro.component.html',
  styleUrls: ['./info-retiro.component.css']
})
export class InfoRetiroComponent implements OnInit {
  tarjetaLogueada: any = {
    nroTarjeta: '',
    balance: 0,
  };
  fechaHoraActual = "";
  montoRetirado: string = '';
  
  constructor(private apiService: AtmApiService, private router : Router) { }

  ngOnInit(): void {
    this.apiService.obtenerDatosTarjetaLogueada().subscribe((data) => {
      this.tarjetaLogueada.nroTarjeta = data.nroTarjeta;
      this.tarjetaLogueada.balance = data.balance;
    });
    this.apiService.getRetiros().subscribe((data) => {
      this.fechaHoraActual = data[data.length - 1].fechaHoraOperacion.substring(0, 10) + " " + data[data.length - 1].fechaHoraOperacion.substring(11, 16);
      this.montoRetirado = data[data.length - 1].montoRetirado;
    });
  }

  atras(){
    this.router.navigate(['/Operaciones']);
  }

  salir() {
    this.apiService.cerrarSesion();
    this.router.navigate(['/']);
  }

}
