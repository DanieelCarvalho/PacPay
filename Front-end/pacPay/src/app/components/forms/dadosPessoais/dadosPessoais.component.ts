import { CommonModule, NgIf } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

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
  @Output() proximaEtapaEvent = new EventEmitter<Event>();

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
    } else {
      this.caracteres = false;
      tudoCerto = false;
    }

    if (reletraMaiuscula.test(senha)) {
      this.letraMaiuscula = true;
    } else {
      this.letraMaiuscula = false;
      tudoCerto = false;
    }

    if (reNumeros.test(senha)) {
      this.numeros = true;
    } else {
      this.numeros = false;
      tudoCerto = false;
    }

    if (reEspeciais.test(senha)) {
      this.especiais = true;
    } else {
      this.especiais = false;
      tudoCerto = false;
    }

    if (tudoCerto) this.formulario.controls['senha'].setValue(senha);
  }
}
function ngOnInit() {
  throw new Error('Function not implemented.');
}
