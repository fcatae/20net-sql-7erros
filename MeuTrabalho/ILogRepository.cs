using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho
{
    public interface ILogRepository
    {
        int TotalRegistros();
        void CriarLog(string texto);
    }
}
