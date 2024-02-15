import { Routes } from '@angular/router';
import { AdminComponent } from './pages/admin/admin.component';
import { autenticarGuard } from './seguranca/autenticar.guard';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
  { path: 'inicio', component: HomeComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent, canActivate: [autenticarGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];
