import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CEPService } from '../../../servicos/cep.service';

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

  constructor(private servico: CEPService) {}

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

  enviarCep(event: Event) {
    event.preventDefault();

    this.servico.retornarEndereco(this.formulario.value.cep).subscribe(
      (retorno) => {
        this.formulario.controls['rua'].setValue(retorno.logradouro);
        this.formulario.controls['complemento'].setValue(retorno.complemento);
        this.formulario.controls['bairro'].setValue(retorno.bairro);
        this.formulario.controls['cidade'].setValue(retorno.localidade);
        this.formulario.controls['estado'].setValue(retorno.uf);
      },
      (error) => {
        console.log('Erro ao buscar o CEP: ', error);
      }
    );
  }
}
