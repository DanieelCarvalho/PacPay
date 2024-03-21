import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { HeaderComponent } from '../../components/header/header.component';
import { FooterComponent } from '../../components/footer/footer.component';
import { CommonModule } from '@angular/common';
import { UsuarioService } from '../../servicos/usuario.service';
import { Credencial } from '../../models/Credencial';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [
    ReactiveFormsModule,
    HeaderComponent,
    FooterComponent,
    RouterLink,
    CommonModule,
  ],
})
export class LoginComponent {
  constructor(private rota: Router, private servico: UsuarioService) {}
  carregando: boolean = false;

  formulario = new FormGroup({
    cpf: new FormControl('', [
      Validators.required,
      Validators.maxLength(11),
      Validators.minLength(11),
    ]),
    senha: new FormControl('', Validators.required),
  });
  senhaIncorreta: boolean = false;

  autenticar(): void {
    this.carregando = true;
    this.servico.autenticar(this.formulario.value as Credencial).subscribe(
      (r) => {
        this.carregando = false;
        this.rota.navigateByUrl('/admin');
        localStorage.setItem('token', r.token);
        localStorage.setItem('nome', r.nome);
      },
      (error) => {
        this.carregando = false;
        if (error.status === 400) {
          this.senhaIncorreta = true;
          setTimeout(() => {
            this.senhaIncorreta = false;
          }, 5000);
        }
      }
    );
  }
}
