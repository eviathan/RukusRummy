using RukusRummy.BusinessLogic.Models;

namespace RukusRummy.BusinessLogic
{
    public static class Defaults
    {
        public readonly static List<Deck> DefaultDecks = new List<Deck>
        {
            new Deck
            {
                Id = Guid.NewGuid(),
                Name = "Days",
                Values = "0.5,1,1.5,2,2.5,3,>3,?,\u2615\uFE0F"
            },
            new Deck
            {
                Id = Guid.NewGuid(),
                Name = "Fibonacci",
                Values = "1,2,3,5,8,13,21,34,55,?,\u2615\uFE0F"
            },
            new Deck
            {
                Id = Guid.NewGuid(),
                Name = "T-Shirt Sizes",
                Values = "XS,S,M,L,XL,?,\u2615\uFE0F"
            },
        };
    }
}