import { Component } from '@angular/core';

import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  isFocus = false;

  constructor(private rota: Router) {}

  formulario = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    senha: new FormControl('', Validators.required),
  });

  cadastrar(): void {
    localStorage.setItem('email', this.formulario.value.email ?? '');
    localStorage.setItem('senha', this.formulario.value.senha ?? '');

    this.rota.navigateByUrl('/login');
  }
}
