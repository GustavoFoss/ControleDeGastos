import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import PessoasPage from "./pages/Pessoas/PessoasPage";
import CategoriasPage from "./pages/Categorias/CategoriasPage";

export default function App() {
  return (
    <BrowserRouter>
      <nav style={{ marginBottom: 20 }}>
        <Link to="/pessoas">Pessoas</Link> |{" "}
        <Link to="/categorias">Categorias</Link> |{" "}
        <Link to="/relatorios/pessoas">Relatório</Link>
      </nav>

      <Routes>
        <Route path="/pessoas" element={<PessoasPage />} />
        <Route path="/categorias" element={<CategoriasPage />} />
        <Route path="/relatorios/pessoas" element={<RelatorioPessoasPage />} />
      </Routes>
    </BrowserRouter>
  );
}
