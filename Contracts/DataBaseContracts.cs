using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamDesktop.Contracts
{
    public record IdContract(int id);

    public record AuthorizationContract(string Login,string Password);

}
