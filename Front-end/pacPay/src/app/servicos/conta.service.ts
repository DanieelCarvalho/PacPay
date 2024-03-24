import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sacar } from '../models/Sacar';
import { BehaviorSubject, Observable } from 'rxjs';
import { Deposito } from '../models/Deposito';
import { Transferencia } from '../models/Transferencia';
import { Buscar } from '../models/Buscar';
import { Historico } from '../models/Historico';
import { ApagarConta } from '../models/ApagarConta';

@Injectable({
  providedIn: 'root',
})
export class ContaService {
  private url: string = 'https://localhost:7054';

  constructor(private http: HttpClient) {}
  public saldoAtualizado = new BehaviorSubject<Buscar>({ saldo: 0 });
  public historico = new BehaviorSubject<Historico[]>([]);

  sacar(obj: Sacar): Observable<string> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ?? '',
    });

    return this.http.post(`${this.url}/Saque`, obj, {
      headers,
      responseType: 'text',
    });
  }
  depositar(obj: Deposito): Observable<string> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ?? '',
    });
    return this.http.post(`${this.url}/Deposito`, obj, {
      headers,
      responseType: 'text',
    });
  }

  Transferencia(obj: Transferencia): Observable<string> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ?? '',
    });
    return this.http.post(`${this.url}/Transferencia`, obj, {
      headers,
      responseType: 'text',
    });
  }
  buscarSaque(): Observable<Buscar> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });
    return this.http.get(`${this.url}/Buscar`, { headers });
  }
  buscarDados(): Observable<Buscar[]> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });
    return this.http.get<Buscar[]>(`${this.url}/Buscar`, { headers });
  }

  pegarHistorico(numeroDaPagina: number): Observable<Historico[]> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });
    return this.http.get<Historico[]>(
      `${this.url}/Historico/${numeroDaPagina}`,
      {
        headers,
      }
    );
  }

  apagarConta(credential: ApagarConta): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });

    return this.http.delete(`${this.url}/Desativar`, {
      headers,
      body: credential,
    });
  }
}
