namespace SportTestAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One team many members 
        public List<Member>Members { get; set; }=new List<Member>();
    }
}
