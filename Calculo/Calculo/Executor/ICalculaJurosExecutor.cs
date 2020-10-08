using Calculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculo.Executor
{
    public interface ICalculaJurosExecutor
    {
        public string CalcularJuros(JurosCompostos jurosCompostos);
    }
}
