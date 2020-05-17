namespace Webapi.Core.IRepository
{
    public class TestRepository : ITestRepository
    {

        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
