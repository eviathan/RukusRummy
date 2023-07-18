using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.BusinessLogic.Services
{
    public interface IGameExportService
    {
        string Serialise(Game game);
    }
}