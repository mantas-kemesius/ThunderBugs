namespace Foosball
{
    delegate string delegates<T1, T2>(T1 a, T2 b);

    class GenericDelegateClass
    {
        static string Addnum(int a, int b) => (a + b).ToString();

        static string Addfloat(double m, double n) => (m + n).ToString();

        static string Addstring(string s1, string s2) => (s1 + s2);
    }

}
