using RukusRummy.DataAccess.Entities;

namespace RukusRummy.DataAccess
{
    public static class Defaults
    {
        public readonly static List<Deck> DefaultDecks = new List<Deck>
        {
            new Deck
            {
                Id = new("c8efe067-ce91-4f4f-9c25-cb8c65d9b150"),
                Name = "Days",
                Values = "0.5,1,1.5,2,2.5,3,>3,?,\u2615\uFE0F"
            },
            new Deck
            {
                Id = new ("81c7eaec-93aa-4f3c-9560-fa77e7063890"),
                Name = "Fibonacci",
                Values = "1,2,3,5,8,13,21,34,55,?,\u2615\uFE0F"
            },
            new Deck
            {
                Id = new ("bc20b8ca-a484-4342-ad04-6f23e0426ac5"),
                Name = "T-Shirt Sizes",
                Values = "XS,S,M,L,XL,?,\u2615\uFE0F"
            },
        };
    }
}