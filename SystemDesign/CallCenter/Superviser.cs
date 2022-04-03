namespace SystemDesign.CallCenter
{
    public class Superviser : Employee
    {
        public override int Priority()
        {
            return 2;
        }

        public Superviser(string name) : base(name)
        {
        }
    }
}