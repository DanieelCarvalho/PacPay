import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-dados-pessoais',
  standalone: true,
  imports: [CommonModule],
  template: ` <div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5 "
        id="nome-cadastro"
        placeholder="name name"
        formControlName="nome"
        required
      />
      <label class="fs-5 pt-4" for="nome-cadastro">Nome Completo</label>
      <div
        *ngIf="
          formulario.controls['nome'].invalid &&
          (formulario.controls['nome'].dirty ||
            formulario.controls['nome'].touched)
        "
        class="text-danger ms-1"
      >
        Nome é obrigatório.
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5"
        id="cpf-cadastro"
        placeholder="000-000-000-00"
        formControlName="cpf"
        required
      />
      <label class="fs-5 pt-4" for="cpf-cadastro">CPF</label>
      <div
        *ngIf="
          formulario.controls['cpf'].invalid &&
          (formulario.controls['cpf'].dirty ||
            formulario.controls['cpf'].touched)
        "
        class="text-danger ms-1"
      >
        CPF é obrigatório.
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        [type]="isFocus ? 'date' : 'text'"
        class="form-control form-control-lg fs-5 pt-5"
        id="data-cadastro"
        placeholder="01/01/2001"
        (focus)="isFocus = true"
        (blur)="isFocus = false"
        formControlName="dataNascimento"
        required
      />
      <label class="fs-5 pt-4" for="data-cadastro">Data de Nascimento</label>
      <div
        *ngIf="
          formulario.controls['dataNascimento'].invalid &&
          (formulario.controls['dataNascimento'].dirty ||
            formulario.controls['dataNascimento'].touched)
        "
        class="text-danger ms-1"
      >
        Data de nascimento é obrigatório.
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        type="number"
        class="form-control form-control-lg fs-5 pt-5"
        id="telefone-cadastro"
        placeholder="(44) 9 8585-8585"
        pattern="[0-9]{2} [0-9]{5}-[0-9]{4}"
        formControlName="telefone"
        required
      />
      <label class="fs-5 pt-4" for="telefone-cadastro">Celular</label>
      <div
        *ngIf="
          formulario.controls['telefone'].invalid &&
          (formulario.controls['telefone'].dirty ||
            formulario.controls['telefone'].touched)
        "
        class="text-danger ms-1"
      >
        Telefone é obrigatório.
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        type="email"
        class="form-control form-control-lg fs-5 pt-5"
        id="email-cadastro"
        placeholder="name@gmiu.com"
        formControlName="email"
        required
      />
      <label class="fs-5 pt-4" for="email-cadastro">Email</label>
      <div
        *ngIf="
          formulario.controls['email'].invalid &&
          (formulario.controls['email'].dirty ||
            formulario.controls['email'].touched)
        "
        class="text-danger ms-1"
      >
        Email é obrigatório.
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        type="password"
        class="form-control form-control-lg fs-5 pt-5"
        id="senha-cadastro"
        placeholder="name@gmiu.com"
        formControlName="senha"
        (input)="validarSenha($event)"
        required
      />
      <label class="fs-5 pt-4" for="senha-cadastro">Senha</label>
      <ul>
        Sua senha deve ter no mínimo::
        <li
          id="caracteres"
          [ngClass]="{
            'text-danger': !caracteres,
            'text-success': caracteres
          }"
        >
          8 caracteres e no máximo 16 caracteres
        </li>
        <li
          id="letras"
          [ngClass]="{
            'text-danger': !letraMaiuscula,
            'text-success': letraMaiuscula
          }"
        >
          1 letra maiúscula
        </li>
        <li
          id="numeros"
          [ngClass]="{
            'text-danger': !numeros,
            'text-success': numeros
          }"
        >
          1 número
        </li>
        <li
          id="caracterEspecial"
          [ngClass]="{
            'text-danger': !especiais,
            'text-success': especiais
          }"
        >
          1 caracter expecial
        </li>
      </ul>
    </div>
    <button type="button" (click)="proximaEtapaEvent.emit()">
      Continuar
    </button>`,
  styleUrl: './dadosPessoais.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DadosPessoaisComponent {
  @Input() formulario!: FormGroup;
  @Output() usuario = new EventEmitter<any>();
  @Output() nomeChange = new EventEmitter<string>();
  @Output() cpfChange = new EventEmitter<string>();
  @Output() emailChange = new EventEmitter<string>();
  @Output() senhaChange = new EventEmitter<string>();
  @Output() proximaEtapaEvent = new EventEmitter<void>();

  isFocus = false;
  caracteres = false;
  letraMaiuscula = false;
  numeros = false;
  especiais = false;

  validarSenha(event: any) {
    const senha = event.target.value;

    if (senha === null) return;

    const reletraMaiuscula = /[A-Z]/;
    const reNumeros = /\d/;
    const reEspeciais = /[!@#$%^&*(),.?":{}|<>]/;

    if (senha.length >= 8 && senha.length <= 16) this.caracteres = true;
    else this.caracteres = false;

    if (reletraMaiuscula.test(senha)) this.letraMaiuscula = true;
    else this.letraMaiuscula = false;

    if (reNumeros.test(senha)) this.numeros = true;
    else this.numeros = false;

    if (reEspeciais.test(senha)) this.especiais = true;
    else this.especiais = false;
  }
}
