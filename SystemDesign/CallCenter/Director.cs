namespace SystemDesign.CallCenter
{
    public class Director : Employee
    {
        public override int Priority()
        {
            return 3;
        }

        public Director(string name) : base(name)
        {
        }
    }
}