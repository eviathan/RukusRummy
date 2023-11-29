using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RukusRummy.BusinessLogic.Services;

namespace RukusRummy.BusinessLogic.Models
{
    public class AuthenticatedPlayer : IPlayer
    {
        private readonly PlayerService _playerService;

        public Guid Id { get; set; }

        public AuthenticatedPlayer(PlayerService playerService, Guid id)
        {
            _playerService = playerService;
            Id = id;
        }

        public async Task<PlayerDetails?> GetDetails()
        {
            var player = await _playerService.GetAsync(Id);

            if (player == null)
                return null;

            return new PlayerDetails
            {
                Name = player.Name,
                Decks = player.Decks,
                IsSpectator = player.IsSpectator
            };
        }
    }
}