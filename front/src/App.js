import React, { useState } from 'react';
import './App.css';
import api from './service/api.js';

function App() {
  const [valorDeclarado, setValorDeclarado] = useState();
  const [tempoMeses, setTempoMeses] = useState();
  const [results, setResults] = useState([]);

  async function handleRegister(e) {
    e.preventDefault();

    let tempo =  parseInt(tempoMeses);
    let valorInicial = parseFloat(valorDeclarado)

    const jurosCompostos = {
      valorInicial,
      tempo
    };
    try {
      var response = await api.post("/calculajuros", jurosCompostos);
      setResults(response.data);

    } catch (err) {
      alert(`Erro no cálculo: ${err}`);
    }
  }

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Insira o valor inicial e a quantidade de mês para o cálculo do juros composto.
        </p>

        <form onSubmit={handleRegister}>
          <input
            placeholder="Valor Inicial"
            value={valorDeclarado}
            onChange={e => setValorDeclarado(e.target.value)}
          />
          <input
            placeholder="Tempo em meses"
            type="number"
            min="0"
            value={tempoMeses}
            onChange={e => setTempoMeses(e.target.value)}
          />
          <button className="button" type="submit">
            Calcular
          </button>
        </form>
        <p> O valor com o Juros depois desse tempo é: {results}</p>
      </header>
    </div>
  );
}

export default App;
