import { Component } from '@angular/core';
import { FooterComponent } from '../../components/footer/footer.component';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ContaService } from '../../servicos/conta.service';
import { Sacar } from '../../models/Sacar';
import { FormsModule, Validator } from '@angular/forms';
import { Transferencia } from '../../models/Transferencia';
import { Deposito } from '../../models/Deposito';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css',
  imports: [FooterComponent, CommonModule, FormsModule],
})
export class AdminComponent {
  constructor(private rota: Router, private servico: ContaService) {}

  saldoVisivel: boolean = true;
  olho: boolean = true;
  nome: any = localStorage.getItem('nome');
  valorSaque: number = 0.0;
  valorDeposito: number = 0;
  valorTranferencia: number = 0;
  ContaDestino: string = '';

  saque(): void {
    const payload = { valor: this.valorSaque };
    console.log(this.valorSaque);
    this.servico.sacar(payload as Sacar).subscribe((resposta) => {});
  }

  depositar(): void {
    const payload: Deposito = { valor: this.valorDeposito };
    console.log(this.valorDeposito);

    this.servico.sacar(payload as Deposito).subscribe((resposta) => {
      console.log('Novo saldo:', resposta.valor);
    });
  }
  transferir(): void {
    const payload: Transferencia = {
      valor: this.valorTranferencia,
      contaDestino: this.ContaDestino,
    };
    console.log(payload);
    this.servico
      .Transferencia(payload as Transferencia)
      .subscribe((resposta) => {
        console.log('Transferência realizada com sucesso!');
      });
  }

  alternarSaldo() {
    this.saldoVisivel = !this.saldoVisivel;
    this.olho = !this.olho;
    console.log(this.nome[0]);
  }
  sair(): any {
    localStorage.removeItem('token');
    localStorage.removeItem('nome');
    this.rota.navigateByUrl('/inicio');
  }
}
