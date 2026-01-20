export interface Pessoa {
  id: string;
  nome: string;
  idade: number;
}

export interface Categoria {
  id: string;
  descricao: string;
  finalidade: number;
}

export interface Transacao {
  id: string;
  descricao: string;
  valor: number;
  tipo: number;
}
