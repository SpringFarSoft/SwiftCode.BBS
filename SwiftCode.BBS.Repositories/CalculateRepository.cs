using SwiftCode.BBS.IRepositories;
using System;

namespace SwiftCode.BBS.Repositories
{
    public class CalculateRepository : ICalculateRepository
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }
    }
}
