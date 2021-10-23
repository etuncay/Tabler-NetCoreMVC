using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabler_NetCoreMVC.Models.Dto;

namespace Tabler_NetCoreMVC.Core.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserDTO user);
        string GetToken();
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);


    }
}
