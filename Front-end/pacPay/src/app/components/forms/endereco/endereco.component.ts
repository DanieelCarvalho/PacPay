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
  selector: 'app-endereco',
  standalone: true,
  imports: [CommonModule],
  template: `<div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5"
        id="cep-cadastro"
        placeholder="55555-000"
        formControlName="cep"
        required
      />
      <label class="fs-5 pt-4" for="cep-cadastro">CEP</label>
    </div>
    <div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5"
        id="rua-cadastro"
        placeholder="name name"
        formControlName="rua"
        required
      />
      <label class="fs-5 pt-4" for="rua-cadastro">Rua</label>
    </div>
    <div class="row">
      <div class="col-md-6">
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control form-control-lg fs-5 pt-5"
            id="numero-cadastro"
            placeholder="01/01/2001"
            formControlName="numero"
            required
          />
          <label class="fs-5 pt-4" for="numero-cadastro">Número</label>
        </div>
      </div>
      <div class="col-md-6">
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control form-control-lg fs-5 pt-5"
            id="complemento-cadastro"
            placeholder="(44) 9 8585-8585"
            pattern="[0-9]{2} [0-9]{5}-[0-9]{4}"
            formControlName="complemento"
            required
          />
          <label class="fs-5 pt-4" for="complemento-cadastro"
            >Complemento</label
          >
        </div>
      </div>
    </div>
    <div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5"
        id="bairro-cadastro"
        placeholder="name@gmiu.com"
        formControlName="bairro"
        required
      />
      <label class="fs-5 pt-4" for="bairro-cadastro">Bairro</label>
    </div>
    <div class="row">
      <div class="col-md-10">
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control form-control-lg fs-5 pt-5"
            id="cidade-cadastro"
            placeholder="martins"
            formControlName="cidade"
            required
          />
          <label class="fs-5 pt-4" for="cidade-cadastro">Cidade</label>
        </div>
      </div>
      <div class="col-md-2">
        <div class="form-floating mb-3">
          <select
            *ngIf="estados"
            class="form-select form-select-lg fs-5 align-middle py-1 px-3"
            id="estado-cadastro"
            formControlName="estado"
            required
          >
            <option *ngFor="let estado of estados">
              {{ estado }}
            </option>

            <label for="estado-cadastro">Estado</label>
          </select>
        </div>
      </div>
    </div>

    <div class="form-floating mb-3">
      <input
        type="text"
        class="form-control form-control-lg fs-5 pt-5"
        id="referencia-cadastro"
        placeholder="name@gmiu.com"
        formControlName="referencia"
        required
      />
      <label class="fs-5 pt-4" for="referencia-cadastro"
        >Ponto de referência</label
      >
    </div>
    <button type="button" (click)="proximaEtapaEvent.emit()">Voltar</button> `,
  styleUrl: './endereco.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EnderecoComponent {
  @Input() formulario!: FormGroup;
  @Output() proximaEtapaEvent = new EventEmitter<void>();
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
}
