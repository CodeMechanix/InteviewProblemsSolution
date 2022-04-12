namespace SystemDesign.JukeBox
{
    public class Song
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public override string ToString()
        {
            return $"Song - {nameof(Name)}: {Name}, {nameof(Duration)}: {Duration} Sec";
        }
    }
}