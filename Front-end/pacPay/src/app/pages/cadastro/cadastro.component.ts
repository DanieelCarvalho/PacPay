import { CommonModule, NgIf, NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { DadosPessoaisComponent } from '../../components/forms/dadosPessoais/dadosPessoais.component';
import { EnderecoComponent } from '../../components/forms/endereco/endereco.component';

import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { Router } from '@angular/router';

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
  ],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  constructor(private rota: Router, private fb: FormBuilder) {}

  formulario!: FormGroup;
  etapa: number = 1;
  dadosPessoaisPreenchidos: boolean = false;

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

  proximaEtapa() {
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
  etapaAnterior() {
    this.etapa--;
  }

  cadastrar(): void {
    //

    localStorage.setItem('email', this.formulario.value.email ?? '');
    localStorage.setItem('senha', this.formulario.value.endereco.cidade ?? '');
    this.rota.navigateByUrl('/login');
  }
}
