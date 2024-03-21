import { Component } from '@angular/core';
import { Buscar } from '../../models/Buscar';
import { ContaService } from '../../servicos/conta.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-perfil',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './perfil.component.html',
  styleUrl: './perfil.component.css',
})
export class PerfilComponent {
  constructor(private servico: ContaService) {}

  DadosUsuario?: any;

  buscarDados(): void {
    this.servico.buscarDados().subscribe((r) => {
      this.DadosUsuario = r;
    });
  }

  ngOnInit(): void {
    this.buscarDados();
  }
}
