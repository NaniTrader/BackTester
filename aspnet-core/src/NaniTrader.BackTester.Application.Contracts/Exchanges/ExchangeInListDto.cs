﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NaniTrader.BackTester.Exchanges
{
    public class ExchangeInListDto : AuditedEntityDto<int>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
