import { Component } from '@angular/core';

import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { NgIf } from '@angular/common';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  isFocus = false;
  value: unknown;

  constructor(private rota: Router) {}

  formulario = new FormGroup({
    nome: new FormControl('', Validators.required),
    cpf: new FormControl('', Validators.required),
    dataNascimento: new FormControl('', Validators.required),
    telefone: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    senha: new FormControl('', [Validators.required. validators.minLength(8)], Validators.maxLength(16), Validators.pattern(/^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,16}$/)),
    cep: new FormControl('', Validators.required),
    rua: new FormControl('', Validators.required),
    numero: new FormControl('', Validators.required),
    complemento: new FormControl('', Validators.required),
    bairro: new FormControl('', Validators.required),
    cidade: new FormControl('', Validators.required),
    referencia: new FormControl('', Validators.required),
  });

  cadastrar(): void {
    if (this.formulario.valid) {
      console.log(this.formulario.value.email);
      console.log(this.formulario.value.senha);
      console.log(this.formulario.value);
    } else {
      Object.keys(this.formulario.controls).forEach((field) => {
        const control = this.formulario.get(field);
        if (control) {
          control.markAsTouched({ onlySelf: true });
        }
      });
    }
  }

  validarSenha(event: Event): boolean {
    const value = (event.target as HTMLInputElement).value;
    if (value === null) return false;

    if (value.length < 8 || value.length > 16) return false;

    const letras = value.match(/[a-zA-Z]/g);
    if (!letras || letras.length < 2) return false;

    const numeros = value.match(/\d/g);
    if (!numeros || numeros.length < 2) return false;

    const especiais = value.match(/[^a-zA-Z0-9]/g);
    if (!especiais || especiais.length < 1) return false;

    return true;
  }
}
