namespace SportTestAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; } //Foreign Key 

        public Team team { get; set; } //Navigation Property 
    }
}
