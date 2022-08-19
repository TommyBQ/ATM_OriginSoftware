import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AtmApiService } from 'src/app/services/atm-api.service';

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.css'],
})
export class OperacionesComponent implements OnInit {
  constructor(private apiService: AtmApiService, private router: Router) {}

  ngOnInit(): void {}

  goToBalance() {
    this.apiService.crearBalance().subscribe((data) => {
      console.log(data);
    });
    this.router.navigate(['/Operaciones/Balance']);
  }

  goToRetiro() {
    this.router.navigate(['/Operaciones/Retiro']);
  }

  salir() {
    this.apiService.cerrarSesion();
    this.router.navigate(['/']);
  }
}
