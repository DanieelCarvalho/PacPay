import { Component } from '@angular/core';
import { Buscar } from '../../models/Buscar';
import { ContaService } from '../../servicos/conta.service';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ApagarConta } from '../../models/ApagarConta';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-perfil',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink],
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css',
})
export class PerfilComponent {
  constructor(private servico: ContaService, private rota: Router) {}

  DadosUsuario?: any;
  deletionError: string | null = null;
  deletionSuccess: string | null = null;
  errorApagarConta: boolean = false;
  error: boolean = false;

  senhaForm = new FormGroup({
    senha: new FormControl('', Validators.required),
  });

  buscarDados(): void {
    this.servico.buscarDados().subscribe((r) => {
      this.DadosUsuario = r;
    });
  }

  Apagarconta(): void {
    this.servico.apagarConta(this.senhaForm.value as ApagarConta).subscribe(
      (r) => {
        localStorage.removeItem('token');
        localStorage.removeItem('nome');
        this.rota.navigateByUrl('/inicio');
      },
      (error) => {
        if (error.status === 500 || error.status === 401) {
          this.errorApagarConta = true;
          setTimeout(() => {
            this.errorApagarConta = false;
          }, 4000);
        } else if (error.status == 403) {
          this.error = true;
          setTimeout(() => {
            this.error = false;
          }, 4000);
        }
      }
    );
  }

  ngOnInit(): void {
    this.buscarDados();
  }
}
