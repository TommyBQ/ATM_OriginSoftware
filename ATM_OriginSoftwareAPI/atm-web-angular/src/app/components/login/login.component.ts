import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AtmApiService } from 'src/app/services/atm-api.service';
import Swal from 'sweetalert2';
import { TecladoNumericoComponent } from '../teclado-numerico/teclado-numerico.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  nroTarjeta: string = '';
  pin: string = '';
  tarjetaValida: boolean = false;

  constructor(private apiService: AtmApiService, private router : Router) {}

  ngOnInit(): void {}

  setNumeros(numero: string) {
    if (!this.tarjetaValida) {
      this.nroTarjeta = numero;
    } else {
      if (this.pin.length < 4) {
        this.pin = numero;
      }
    }
  }

  limpiarInputs() {
    if (!this.tarjetaValida) {
      this.nroTarjeta = '';
      this.pin = '';
    } else {
      this.pin = '';
    }
  }
  salir(){
    this.tarjetaValida = false;
    this.limpiarInputs();
  }

  verificarNumero() {
    if (!this.tarjetaValida){
    const expression = /-/g;

    this.apiService
      .validarNroTarjeta(this.nroTarjeta.replace(expression, ''))
      .subscribe(
        (data) => {
          if (data.isSuccess) {
            this.tarjetaValida = true;
          }
        },
        (error) => {
          Swal.fire({
            icon: 'error',
            title: 'Oops :/',
            text: error.error.mensajeError,
          });
          this.limpiarInputs();
        }
      );
      } else {
        this.apiService.loguearTarjeta(this.pin).subscribe(
          (data) => {
            if (data.isSuccess) {
              this.router.navigate(['/Operaciones']);
            }
          },
          (error) => {
            console.log(error);
            Swal.fire({
              icon: 'error',
              title: 'Oops :/',
              text: 'PIN Incorrecto.',
            });
            this.limpiarInputs();
          }
        );
      }
  }
}
