import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClienteService, Cliente } from '../../services/cliente';

@Component({
  selector: 'app-consulta-clientes',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './consulta-clientes.html',
  styleUrls: ['./consulta-clientes.css'],
})
export class ConsultaClientesComponent {
  terminoBusqueda: string = '';
  clientes: Cliente[] = [];
  isLoading: boolean = false;

  constructor(private clienteService: ClienteService) {}

  buscarClientes() {
    if (!this.terminoBusqueda.trim()) return;

    this.isLoading = true;
    this.clienteService.buscarClientes(this.terminoBusqueda).subscribe({
      next: (data) => {
        this.clientes = data;
        this.isLoading = false;
      },
      error: () => (this.isLoading = false),
    });
  }

  onEnterKeyPress() {
    this.buscarClientes();
  }
}
