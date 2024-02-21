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
    if (
      this.formulario.value.email === localStorage.getItem('email') &&
      this.formulario.value.senha === localStorage.getItem('senha')
    ) {
      this.rota.navigateByUrl('/admin');
    } else {
      alert('E-mail ou senha incorretos.');
    }
  }
}
