import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Endereco } from '../models/Endereco';

@Injectable({
  providedIn: 'root',
})
export class CEPService {
  constructor(private http: HttpClient) {}

  retornarEndereco(cep: string): Observable<Endereco> {
    return this.http.get<Endereco>(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
