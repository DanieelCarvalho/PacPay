import { Component } from '@angular/core';
import { FooterComponent } from "../../components/footer/footer.component";

@Component({
    selector: 'app-admin',
    standalone: true,
    templateUrl: './admin.component.html',
    styleUrl: './admin.component.css',
    imports: [FooterComponent]
})
export class AdminComponent {
    saldoVisivel = true;
  
    alternarSaldo() {
      this.saldoVisivel = !this.saldoVisivel;
    }
  }
