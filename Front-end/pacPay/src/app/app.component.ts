import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { HeaderComponent } from './components/header/header.component';
import { PerfilComponent } from './pages/perfil/perfil.component';
import { ContaService } from './servicos/conta.service';
import { Buscar } from './models/Buscar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    HomeComponent,
    LoginComponent,
    CadastroComponent,
    HeaderComponent,
    PerfilComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'pacPay';
}
