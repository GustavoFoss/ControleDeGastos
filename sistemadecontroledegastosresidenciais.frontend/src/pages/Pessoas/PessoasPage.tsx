import { useEffect, useState } from "react";
import { api } from "../../services/api";
import { Pessoa } from "../../types/models";

export default function PessoasPage() {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const [nome, setNome] = useState("");
  const [idade, setIdade] = useState<number>(0);

  function carregarPessoas() {
    api.get<Pessoa[]>("/pessoas")
      .then(res => setPessoas(res.data));
  }

  useEffect(() => {
    carregarPessoas();
  }, []);

  function cadastrarPessoa() {
    api.post("/pessoas", { nome, idade })
      .then(() => {
        setNome("");
        setIdade(0);
        carregarPessoas();
      });
  }

  return (
    <div>
      <h2>Pessoas</h2>

      <div>
        <input
          placeholder="Nome"
          value={nome}
          onChange={e => setNome(e.target.value)}
        />
        <input
          type="number"
          placeholder="Idade"
          value={idade}
          onChange={e => setIdade(Number(e.target.value))}
        />
        <button onClick={cadastrarPessoa}>Cadastrar</button>
      </div>

      <ul>
        {pessoas.map(p => (
          <li key={p.id}>
            {p.nome} - {p.idade} anos
          </li>
        ))}
      </ul>
    </div>
  );
}
