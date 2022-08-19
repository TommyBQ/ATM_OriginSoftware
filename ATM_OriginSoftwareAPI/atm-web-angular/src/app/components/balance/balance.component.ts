import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AtmApiService } from 'src/app/services/atm-api.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent implements OnInit {
  tarjetaLogueada: any = {
    nroTarjeta: '',
    balance: 0,
    fechaVencimiento: '',
  };

  constructor(private apiService: AtmApiService, private router : Router) { }

  ngOnInit(): void {
    this.apiService.obtenerDatosTarjetaLogueada().subscribe((data) => {
      this.tarjetaLogueada.nroTarjeta = data.nroTarjeta;
      this.tarjetaLogueada.balance = data.balance;
      this.tarjetaLogueada.fechaVencimiento = data.fechaVencimiento.substring(0, 7);
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
