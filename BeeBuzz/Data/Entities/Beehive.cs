using BeeBuzz.Data.Enums;

namespace BeeBuzz.Data.Entities
{
    public class Beehive
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Location = string.Empty;
        public BeehiveStatus Status { get; set; }
        public DeactivationReason DeactivationReason { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
