using NaniTrader.BackTester.Exchanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace NaniTrader.BackTester.NSEData.CashMarket
{
    public class BhavCopyManager : DomainService
    {
        private readonly IBhavCopyRepository _bhavCopyRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BhavCopyManager(IBhavCopyRepository bhavCopyRepository, IGuidGenerator guidGenerator)
        {
            _bhavCopyRepository = bhavCopyRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<BhavCopy> AddBhavCopyDataAsync(DateOnly date, byte[] fileData, string fileName, DateTime fileLastModified)
        {
            var existingBhavCopy = await _bhavCopyRepository.FindByDateAsync(date);
            if (existingBhavCopy != null)
            {
                throw new BhavCopyAlreadyExistsException(date);
            }

            var bhavCopyData = new BhavCopyData(fileData, fileName, fileLastModified);

            return new BhavCopy(_guidGenerator.Create(), date, FileStatus.Available, bhavCopyData);
        }

        public async Task<BhavCopy> AddNoBhavCopyEntryAsync(DateOnly date)
        {
            var existingBhavCopy = await _bhavCopyRepository.FindByDateAsync(date);
            if (existingBhavCopy != null)
            {
                throw new BhavCopyAlreadyExistsException(date);
            }

            return new BhavCopy(_guidGenerator.Create(), date, FileStatus.NotAvailable);
        }
    }
}
