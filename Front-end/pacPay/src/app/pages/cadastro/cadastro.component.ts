import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

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
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  constructor(private rota: Router, private fb: FormBuilder) {}
  isFocus = false;
  formulario!: FormGroup;
  etapa: number = 1;

  // formulario = new FormGroup({
  //   email: new FormControl('', [Validators.required, Validators.email]),
  //   senha: new FormControl('', Validators.required),
  // });

  ngOnInit(): void {
    this.formulario = this.fb.group({
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      endereco: this.fb.group({
        rua: ['', Validators.required],
        cidade: ['', Validators.required],
        estado: ['', Validators.required],
      }),
    });
  }
  proximaEtapa() {
    this.etapa++;
  }
  etapaAnterior() {
    this.etapa--;
  }

  cadastrar(): void {
    localStorage.setItem('email', this.formulario.value.email ?? '');
    localStorage.setItem('senha', this.formulario.value.senha ?? '');
    this.rota.navigateByUrl('/login');
  }
}
