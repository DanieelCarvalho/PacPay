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
  nomeCompleto: any = localStorage.getItem('nome');
  valorSaque?: number;
  valorDeposito?: number;
  valorTranferencia?: number;
  ContaDestino: string = '';
  saldo?: number;
  historicoDados: Historico[] = [];
  saldotest: Buscar[] = [];
  etapa: number = 1;
  primeiroNome: string = this.nomeCompleto.split(' ');
  cpfInvalido: boolean = false;
  errorDeposito: boolean = false;
  errorSaque: boolean = false;
  carregandoSaque: boolean = false;
  carregandoDeposito: boolean = false;
  carregandoTransfe: boolean = false;
  testeNpg?: number;

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
    this.carregandoSaque = true;
    const payload = { valor: this.valorSaque };
    console.log(this.valorSaque);

    this.saqueSubscription = this.servico.sacar(payload).subscribe(
      (resposta) => {
        console.log(resposta);
        this.carregandoSaque = false;
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorSaque = undefined;
      },
      (error) => {
        if (error.status == 400) {
          this.carregandoSaque = false;
          this.errorSaque = true;
          setTimeout(() => {
            this.errorSaque = false;
          }, 4000);
        }
      }
    );
  }

  depositar(): void {
    this.carregandoDeposito = true;
    const payload = { valor: this.valorDeposito };
    console.log(this.valorDeposito);
    this.depositarSubscription = this.servico.depositar(payload).subscribe(
      (resposta) => {
        this.carregandoDeposito = false;
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorDeposito = undefined;
      },
      (error) => {
        this.carregandoDeposito = false;
        if (error.status == 400) {
          this.errorDeposito = true;
          setTimeout(() => {
            this.errorDeposito = false;
          }, 4000);
        }
      }
    );
  }

  transferir(): void {
    this.carregandoTransfe = true;
    const payload = {
      valor: this.valorTranferencia,
      contaDestino: this.ContaDestino,
    };
    console.log(payload);
    this.transferirSubscription = this.servico.Transferencia(payload).subscribe(
      (resposta) => {
        this.carregandoTransfe = false;
        this.BuscarSaldo();
        this.buscarHistorico(1);
        this.valorTranferencia = undefined;
        this.ContaDestino = '';
        console.log('Transferência realizada com sucesso!');
      },
      (error) => {
        this.carregandoTransfe = false;
        if (error.status == 404 || error.status == 500 || error.status == 403) {
          this.cpfInvalido = true;
          setTimeout(() => {
            this.cpfInvalido = false;
          }, 4000);
          console.log(error, 'oi');
        }
      }
    );
  }

  alternarSaldo() {
    this.saldoVisivel = !this.saldoVisivel;
    this.olho = !this.olho;
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
    const proximaEtapa = this.etapa + 1;
    this.servico.pegarHistorico(proximaEtapa).subscribe((r) => {
      if (r.length > 0) {
        // Verifica se há algum item no histórico
        this.etapa++;
        this.buscarHistorico(this.etapa);
      } else {
        console.log('Não há folha disponível para a próxima etapa.');
        // Adicione aqui a lógica para lidar com o caso em que não há folha disponível
      }
    });
  }

  etapaAnterior() {
    if (this.etapa > 1) {
      // Verifica se a etapa atual não é a primeira
      this.etapa--;
      this.buscarHistorico(this.etapa);
    } else {
      console.log('Você já está na primeira etapa.');
      // Adicione aqui a lógica para lidar com o caso em que o usuário está na primeira etapa
    }
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
