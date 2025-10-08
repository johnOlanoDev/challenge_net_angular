import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cliente {
  id: number;
  ruc: string;
  razonSocial: string;
  telefono: string;
  correo: string;
  direccion: string;
}

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  private apiUrl = 'https://localhost:7106/api/Clientes';

  constructor(private http: HttpClient) {}

  buscarClientes(term: string): Observable<Cliente[]> {
    let params = new HttpParams();
    if (term && term.trim() !== '') {
      params = params.set('search', term);
    }

    return this.http.get<Cliente[]>(this.apiUrl, { params });
  }
}
