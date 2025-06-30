using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerarTokenAsync(Empleado empleado);

        public Task<string> GenerarRefreshTokenAsync(Empleado empleado);

        public Task<int> ValidarTokenAsync(string token);

    }
}
