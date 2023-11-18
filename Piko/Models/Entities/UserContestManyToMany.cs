namespace Piko.Models.Entities
{
    public class UserContestsPassed
    {
        public int UserId { get; set; }
        public int ContestId { get; set; }
    }
    public class UserContestsLiked
    {
        public int UserId { get; set; }
        public int ContestId { get; set; }
    }
}