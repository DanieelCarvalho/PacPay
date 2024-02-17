import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { Router } from '@angular/router';
import { HeaderComponent } from '../../components/header/header.component';
import { FooterComponent } from '../../components/footer/footer.component';

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [RouterLink, LoginComponent, HeaderComponent, FooterComponent],
})
export class HomeComponent {
  // constructor(private router: Router) {}
  // cadastro(): void {
  //   this.router.navigate(['/cadastro']);
  // }
}
