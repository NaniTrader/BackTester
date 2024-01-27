using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NaniTrader.BackTester.NSEData.CashMarket
{
    public class BhavCopyData : FullAuditedEntity<int>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private BhavCopyData() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public byte[] Data { get; private set; }

        public string FileName { get; private set; }

        public DateTime FileLastModified { get; private set; }

        public BhavCopyData(byte[] fileData, string fileName, DateTime fileLastModified)
        {
            Data = fileData;
            FileName = fileName;
            FileLastModified = fileLastModified;
        }
    }
}
