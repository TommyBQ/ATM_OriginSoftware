import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-teclado-numerico',
  templateUrl: './teclado-numerico.component.html',
  styleUrls: ['./teclado-numerico.component.css'],
})
export class TecladoNumericoComponent implements OnInit {
  @Output() newNroTarjetaEvent = new EventEmitter<string>();
  @Output() newMontoEvent = new EventEmitter<string>();
  num: string = '';
  monto: string = '';
  cantidadCaracteres: number = 0;
  constructor() {}

  ngOnInit(): void {}

  enviarNumero(numero: string) {
    if (this.cantidadCaracteres < 19) {
      if (
        this.num.length == 4 ||
        this.num.length == 9 ||
        this.num.length == 14
      ) {
        this.num += '-' + numero;
      } else {
        this.num += numero;
      }
      this.cantidadCaracteres = this.num.length;
      this.newNroTarjetaEvent.emit(this.num);
    }
  }

  enviarMonto(numero: string){
    this.monto += numero;
    this.newMontoEvent.emit(this.monto);
  }

  limpiarNumero() {
    this.num = '';
    this.cantidadCaracteres = 0;
  }

  limpiarMonto(){
    this.monto = '';
  }
  
}
