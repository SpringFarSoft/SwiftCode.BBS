using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices;
using System;

namespace SwiftCode.BBS.Services
{
    public class CalculateService : ICalculateService
    {
        ICalculateRepository _calculateRepository;

        public CalculateService(ICalculateRepository calculateRepository)
        {
            _calculateRepository = calculateRepository;
        }

        public int Sum(int i, int j)
        {
            return _calculateRepository.Sum(i, j);
        }
    }
}
