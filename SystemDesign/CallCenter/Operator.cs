namespace SystemDesign.CallCenter
{
    public class Operator : Employee
    {
        public override int Priority()
        {
            return 1;
        }

        public Operator(string name) : base(name)
        {
        }
    }
}