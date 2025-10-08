import { Routes } from '@angular/router';
import { ConsultaClientesComponent } from './components/consulta-clientes/consulta-clientes';

export const routes: Routes = [
  { path: '', redirectTo: 'consulta', pathMatch: 'full' },
  { path: 'consulta', component: ConsultaClientesComponent },
];
