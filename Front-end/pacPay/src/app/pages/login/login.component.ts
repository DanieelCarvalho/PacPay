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

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [ReactiveFormsModule, HeaderComponent, FooterComponent, RouterLink],
})
export class LoginComponent {
  constructor(private rota: Router) {}
  formulario = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    senha: new FormControl('', Validators.required),
  });

  autenticar(): void {
    let usuarioAutenticado = false;

    let ultimoId = Number(localStorage.getItem('ultimoId')) || 0;

    for (let i = 1; i <= ultimoId; i++) {
      let usuarioJson = localStorage.getItem(i.toString());

      if (usuarioJson) {
        try {
          let usuario = JSON.parse(usuarioJson);

          if (
            usuario.email === this.formulario.value.email &&
            usuario.senha === this.formulario.value.senha
          ) {
            localStorage.setItem('nomeLogado', usuario.nome);
            usuarioAutenticado = true;
            break;
          }
        } catch (e) {
          console.error(`Erro ao analisar o usuário com id ${i}:`, e);
        }
      }
    }

    if (usuarioAutenticado) {
      this.rota.navigateByUrl('/admin');
    } else {
      alert('E-mail ou senha incorretos.');
    }
  }
}
