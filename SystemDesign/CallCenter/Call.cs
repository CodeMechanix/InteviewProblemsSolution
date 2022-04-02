namespace SystemDesign.CallCenter
{
    public class Call
    {
        public int Id { get; set; }
        public int Duration { get; set; } 

        public Call(int id, int duration)
        {
            Id = id;
            Duration = duration;
        }
    }
}