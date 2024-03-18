import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sacar } from '../models/Sacar';
import { Observable } from 'rxjs';
import { Deposito } from '../models/Deposito';
import { Transferencia } from '../models/Transferencia';

@Injectable({
  providedIn: 'root',
})
export class ContaService {
  private url: string = 'https://localhost:7054';

  constructor(private http: HttpClient) {}

  sacar(obj: Sacar): Observable<Sacar> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });

    return this.http.post(`${this.url}/Saque`, obj, { headers });
  }
  depositar(obj: Deposito): Observable<Sacar> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });
    return this.http.post(`${this.url}/Deposito`, obj, { headers });
  }
  Transferencia(obj: Transferencia): Observable<Transferencia> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      Authorization: token ? token : '',
    });
    return this.http.post(`${this.url}/Transferencia`, obj, { headers });
  }
}
