namespace Application.DTOs.Rating;

public class UpdateRatingDto
{
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public int RatingValue { get; set; }
}