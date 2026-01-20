import { useEffect, useState } from "react";
import { api } from "../../services/api";
import { Categoria } from "../../types/models";

export default function CategoriasPage() {
  const [categorias, setCategorias] = useState<Categoria[]>([]);
  const [descricao, setDescricao] = useState("");
  const [finalidade, setFinalidade] = useState<number>(1);

  function carregarCategorias() {
    api.get<Categoria[]>("/categorias")
      .then(res => setCategorias(res.data));
  }

  useEffect(() => {
    carregarCategorias();
  }, []);

  function cadastrarCategoria() {
    api.post("/categorias", { descricao, finalidade })
      .then(() => {
        setDescricao("");
        carregarCategorias();
      });
  }

  return (
    <div>
      <h2>Categorias</h2>

      <div>
        <input
          placeholder="Descrição"
          value={descricao}
          onChange={e => setDescricao(e.target.value)}
        />

        <select
          value={finalidade}
          onChange={e => setFinalidade(Number(e.target.value))}
        >
          <option value={1}>Despesa</option>
          <option value={2}>Receita</option>
          <option value={3}>Ambas</option>
        </select>

        <button onClick={cadastrarCategoria}>Cadastrar</button>
      </div>

      <ul>
        {categorias.map(c => (
          <li key={c.id}>
            {c.descricao} - Finalidade: {c.finalidade}
          </li>
        ))}
      </ul>
    </div>
  );
}
