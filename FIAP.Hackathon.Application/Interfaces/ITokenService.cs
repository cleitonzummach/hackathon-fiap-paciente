using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.Application.Interfaces
{
    public interface ITokenService
    {
        string RetornarToken(string email, string senha);
    }
}
