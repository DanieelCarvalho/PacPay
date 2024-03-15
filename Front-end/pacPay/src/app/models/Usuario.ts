export interface Usuario {
  cliente?: {
    nome: string;
    documento: string;
    email: string;
    dataNascimento: string;
    endereco: {
      cep: string;
      rua: string;
      numero: string;
      complemento: string;
      bairro: string;
      cidade: string;
      estado: string;
    };
  };
  senha?: string;
}
