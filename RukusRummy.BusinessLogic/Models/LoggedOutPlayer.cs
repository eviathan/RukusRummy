using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models
{
    public class LoggedOutPlayer : IPlayer
    {
        public Guid Id => throw new NotImplementedException();

        public Task<PlayerDetails?> GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}