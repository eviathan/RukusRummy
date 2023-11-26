using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.DataAccess.Entities;

namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class GameDTO
    {
        public Guid Id { get; set; }

        public GameStateType State { get; set; }

        public string Name { get; set; }

        public DeckDTO Deck { get; set; }

        public List<PlayerDTO> Players { get; set; }

        public List<RoundDTO> Rounds { get; set; }

        public bool AutoReveal { get; set; }
        
        public bool EnableFunFeatures { get; set; }

        public bool ShowAverage { get; set; }
        
        public bool AutoCloseSession { get; set; }
        
        public PlayerPermissionType ManageIssuesPermission { get; set; }

        public PlayerPermissionType RevealCardsPermission { get; set; }

        public GameDTO(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            State = game.State;
            Deck = new DeckDTO(game.Deck);
            Players = game.Players.Select(x => new PlayerDTO(x)).ToList();
            Rounds = game.Rounds
                .Select(x => new RoundDTO(x))
                .OrderBy(x => x.StartDate)
                .ToList();
            AutoReveal = game.AutoReveal;
            EnableFunFeatures = game.EnableFunFeatures;
            ShowAverage = game.ShowAverage;
            AutoCloseSession = game.AutoCloseSession;
            ManageIssuesPermission = game.ManageIssuesPermission;
            RevealCardsPermission = game.RevealCardsPermission;
        }
    }
}