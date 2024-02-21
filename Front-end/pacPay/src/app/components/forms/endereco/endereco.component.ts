import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-endereco',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './endereco.component.html',
  styleUrl: './endereco.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EnderecoComponent {
  @Input() formulario!: FormGroup;
  @Output() proximaEtapaEvent = new EventEmitter<Event>();
  @Output() concluirCadastro = new EventEmitter<Event>();

  estados = [
    'AC',
    'AL',
    'AP',
    'AM',
    'BA',
    'CE',
    'DF',
    'ES',
    'GO',
    'MA',
    'MT',
    'MS',
    'MG',
    'PA',
    'PB',
    'PR',
    'PE',
    'PI',
    'RJ',
    'RN',
    'RS',
    'RO',
    'RR',
    'SC',
    'SP',
    'SE',
    'TO',
  ];

  async enviarCep(event: Event) {
    event.preventDefault();
    try {
      const cep = this.formulario.get('cep')?.value;

      const response = await fetch(`https://viacep.com.br/ws/${cep}/json/`);

      const dados = await response.json();

      this.formulario.controls['cep'].setValue(dados.cep);
      this.formulario.controls['rua'].setValue(dados.logradouro);
      this.formulario.controls['complemento'].setValue(dados.complemento);
      this.formulario.controls['bairro'].setValue(dados.bairro);
      this.formulario.controls['cidade'].setValue(dados.localidade);
      this.formulario.controls['estado'].setValue(dados.uf);
    } catch (error) {
      console.log('Erro ao buscar o CEP: ', error);
    }
  }

  
}
