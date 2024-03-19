import { Component } from '@angular/core';
import { FooterComponent } from '../../components/footer/footer.component';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ContaService } from '../../servicos/conta.service';
import { Sacar } from '../../models/Sacar';
import { FormsModule, Validator } from '@angular/forms';
import { Transferencia } from '../../models/Transferencia';
import { Deposito } from '../../models/Deposito';
import { Buscar } from '../../models/Buscar';
import { Historico } from '../../models/Historico';
import { Subscription } from 'rxjs';

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
  valorSaque?: number;
  valorDeposito?: number;
  valorTranferencia?: number;
  ContaDestino: string = '';
  saldo?: number;
  historicoDados: Historico[] = [];
  saldotest: Buscar[] = [];
  etapa: number = 1;

  private buscarSaldoSubscription: Subscription | undefined;
  private saqueSubscription: Subscription | undefined;
  private depositarSubscription: Subscription | undefined;
  private transferirSubscription: Subscription | undefined;

  ngOnDestroy(): void {
    this.buscarSaldoSubscription?.unsubscribe();
    this.saqueSubscription?.unsubscribe();
    this.depositarSubscription?.unsubscribe();
    this.transferirSubscription?.unsubscribe();
  }

  BuscarSaldo(): void {
    this.buscarSaldoSubscription = this.servico.buscarSaque().subscribe((r) => {
      if (r.saldo !== undefined) {
        console.log(r);
        this.saldo = r.saldo;
        const saldoAtualizado: any = { saldo: this.saldo };
        this.servico.saldoAtualizado.next(saldoAtualizado);
      }
    });
  }

  saque(): void {
    const payload = { valor: this.valorSaque };
    console.log(this.valorSaque);
    this.saqueSubscription = this.servico
      .sacar(payload)
      .subscribe((resposta) => {
        console.log(resposta);
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorSaque = undefined;
      });
  }

  depositar(): void {
    const payload = { valor: this.valorDeposito };
    console.log(this.valorDeposito);
    this.depositarSubscription = this.servico.depositar(payload).subscribe(
      (resposta) => {
        console.log('Depósito realizado com sucesso!');
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorDeposito = undefined;
      },
      (error) => {
        console.error('Erro ao realizar o depósito:', error);
      }
    );
  }

  transferir(): void {
    const payload = {
      valor: this.valorTranferencia,
      contaDestino: this.ContaDestino,
    };
    console.log(payload);
    this.transferirSubscription = this.servico
      .Transferencia(payload)
      .subscribe((resposta) => {
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorTranferencia = undefined;
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

  buscarHistorico(numeroDaPagina: number): void {
    this.servico.pegarHistorico(numeroDaPagina).subscribe((r) => {
      console.log(r);
      const historico = r.map((t) => {
        return {
          ...t,
        };
      });

      this.servico.historico.next(historico);
      this.historicoDados = historico;
    });
  }
  proximaetapa() {
    this.etapa++;
    this.buscarHistorico(this.etapa);
  }
  etapaAnterior() {
    this.etapa--;
    this.buscarHistorico(this.etapa);
  }
  perfil() {
    this.rota.navigateByUrl('/perfil');
    console.log('oi');
  }

  ngOnInit(): void {
    this.BuscarSaldo();
    this.buscarHistorico(1);
  }
}
