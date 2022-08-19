import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AtmApiService } from 'src/app/services/atm-api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.css'],
})
export class RetiroComponent implements OnInit {
  monto: string = '';
  constructor(private apiService: AtmApiService, private router : Router) {}

  ngOnInit(): void {}

  limpiar(){
    this.monto = '';
  }

  atras(){
    this.router.navigate(['/Operaciones']);
  }

  salir() {
    this.apiService.cerrarSesion();
    this.router.navigate(['/']);
  }

  setMonto(numero: string) {
      this.monto = numero;
  }

  retirarMonto(){
    this.apiService.crearRetiro(this.monto).subscribe(
      (data) => {
        if (data.isSuccess) {
          this.router.navigate(['Operaciones/InfoRetiro']);
        }
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops :/',
          text: error.error.mensajeError,
        });
      }
    );
  }
}
