
namespace RukusRummy.BusinessLogic.Models.DTOs
{
    public class AddDeckToPlayerRequestDTO
    {
        public Guid PlayerId { get; set; }
        public Guid DeckId { get; set; }
    }
}