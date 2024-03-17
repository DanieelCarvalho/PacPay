import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/Usuario';
import { Credencial } from '../models/Credencial';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private url: string = 'https://localhost:7054';

  constructor(private http: HttpClient) {}

  cadastrar(obj: Usuario): Observable<Usuario> {
    return this.http.post(`${this.url}/Criar`, obj);
  }

  autenticar(credential: Credencial): Observable<any> {
    return this.http.post(`${this.url}/Login`, credential);
  }
}
