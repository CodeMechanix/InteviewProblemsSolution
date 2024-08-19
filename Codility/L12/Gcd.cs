namespace Codility.L12
{
    internal class Gcd
    {
        private readonly int _a;
        private readonly int _b;

        public Gcd(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Result()
        {
            return CalcRecursive(_a, _b);

        }

        private int CalcRecursive(int a, int b)
        {

            int residue = a % b;
            if (residue == 0)
            {
                return b;
            }

            return CalcRecursive(b, residue);
        }
    }
}
