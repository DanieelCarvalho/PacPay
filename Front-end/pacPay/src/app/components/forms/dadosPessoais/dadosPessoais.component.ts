import { CommonModule, NgIf } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-dados-pessoais',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, NgIf],
  templateUrl: './dadosPessoais.component.html',
  styleUrl: './dadosPessoais.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DadosPessoaisComponent {
  @Input() formulario!: FormGroup;
  @Output() proximaEtapaEvent = new EventEmitter<void>();

  isFocus = false;

  caracteres = false;
  letraMaiuscula = false;
  numeros = false;
  especiais = false;

  validarSenha(event: any) {
    const senha = event.target.value;
    let tudoCerto = true;

    if (senha === null) return;

    const reletraMaiuscula = /[A-Z]/;
    const reNumeros = /\d/;
    const reEspeciais = /[!@#$%^&*(),.?":{}|<>]/;

    if (senha.length >= 8 && senha.length <= 16) {
      this.caracteres = true;
      tudoCerto = false;
    } else this.caracteres = false;

    if (reletraMaiuscula.test(senha)) {
      this.letraMaiuscula = true;
      tudoCerto = false;
    } else this.letraMaiuscula = false;

    if (reNumeros.test(senha)) {
      this.numeros = true;
      tudoCerto = false;
    } else this.numeros = false;

    if (reEspeciais.test(senha)) {
      this.especiais = true;
      tudoCerto = false;
    } else this.especiais = false;

    if (tudoCerto) this.formulario.controls['senha'].setValue(senha);
  }
}
