import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateExchangeDto {
  name: string;
  description: string;
}

export interface ExchangeDto extends AuditedEntityDto<number> {
  name?: string;
  description?: string;
}

export interface ExchangeInListDto extends AuditedEntityDto<number> {
  name?: string;
  description?: string;
}

export interface ExchangeListFilterDto extends PagedAndSortedResultRequestDto {
  name?: string;
}
