namespace Application.DTOs.Rating;

public class UpdateRatingInputModel
{
        public Guid Id { get; set; }
        public Guid BlogId { get; set; }
        public int RatingValue { get; set; }
}