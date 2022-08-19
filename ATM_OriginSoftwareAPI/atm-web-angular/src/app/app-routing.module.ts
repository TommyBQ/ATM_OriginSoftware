import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BalanceComponent } from './components/balance/balance.component';
import { InfoRetiroComponent } from './components/info-retiro/info-retiro.component';
import { LoginComponent } from './components/login/login.component';
import { OperacionesComponent } from './components/operaciones/operaciones.component';
import { RetiroComponent } from './components/retiro/retiro.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'Operaciones',
    component: OperacionesComponent,
  },
  {
    path: 'Operaciones/Balance',
    component: BalanceComponent,
  },
  {
    path: 'Operaciones/Retiro',
    component: RetiroComponent,
  },
  {
    path: 'Operaciones/InfoRetiro',
    component: InfoRetiroComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
