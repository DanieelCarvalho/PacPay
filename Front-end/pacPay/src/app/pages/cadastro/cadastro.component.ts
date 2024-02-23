import { CommonModule, NgIf, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { DadosPessoaisComponent } from '../../components/forms/dadosPessoais/dadosPessoais.component';
import { EnderecoComponent } from '../../components/forms/endereco/endereco.component';
import { FooterComponent } from '../../components/footer/footer.component';

import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  FormBuilder,
  ValidationErrors,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    NgIf,
    NgFor,
    DadosPessoaisComponent,
    EnderecoComponent,
    FooterComponent,
    RouterLink,
  ],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  constructor(private rota: Router, private fb: FormBuilder) {}

  formulario!: FormGroup;
  etapa: number = 1;

  ngOnInit(): void {
    this.formulario = this.fb.group({
      nome: new FormControl('', Validators.required),
      cpf: new FormControl('', Validators.required),
      dataNascimento: new FormControl('', Validators.required),
      telefone: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      senha: new FormControl('', Validators.required),

      cep: new FormControl('', Validators.required),
      rua: new FormControl('', Validators.required),
      numero: new FormControl(''),
      complemento: new FormControl(''),
      bairro: new FormControl(''),
      cidade: new FormControl('', Validators.required),
      estado: new FormControl('', Validators.required),
      referencia: new FormControl(''),
    });
  }

  proximaEtapa(event: Event) {
    event.preventDefault();
    if (
      this.formulario.get('nome')?.valid &&
      this.formulario.get('cpf')?.valid &&
      this.formulario.get('dataNascimento')?.valid &&
      this.formulario.get('telefone')?.valid &&
      this.formulario.get('email')?.valid &&
      this.formulario.get('senha')?.valid
    ) {
      this.etapa++;
    }
  }

  etapaAnterior(event: Event) {
    event.preventDefault();
    this.etapa--;
  }

  cadastrar(event: Event): void {
    event.preventDefault();
    if (this.formulario.valid) {
      let ultimoId = Number(localStorage.getItem('ultimoId')) || 0;
      let novoId = ultimoId + 1;
      localStorage.setItem('ultimoId', novoId.toString());
      localStorage.setItem(`${novoId}`, JSON.stringify(this.formulario.value));

      this.rota.navigateByUrl('/login');
    } else {
      console.log('Formulário inválido');

      Object.keys(this.formulario.controls).forEach((key) => {
        const control = this.formulario.get(key);
        if (control) {
          const controlErrors: ValidationErrors = control.errors!;
          if (controlErrors != null) {
            Object.keys(controlErrors).forEach((keyError) => {
              console.log(
                `Nome: ${key}
  Erro: ${keyError}
  Valor: ${controlErrors[keyError]}`
              );
            });
          }
        }
      });
    }
  }
}
