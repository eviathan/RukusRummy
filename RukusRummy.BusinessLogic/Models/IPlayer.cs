using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RukusRummy.BusinessLogic.Models
{
    public interface IPlayer
    {
        Guid Id { get; }
        Task<PlayerDetails?> GetDetails();
    }
}