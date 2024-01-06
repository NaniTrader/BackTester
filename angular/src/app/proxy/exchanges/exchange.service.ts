import type { CreateUpdateExchangeDto, ExchangeDto, ExchangeInListDto, ExchangeListFilterDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExchangeService {
  apiName = 'Default';
  

  create = (input: CreateUpdateExchangeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExchangeDto>({
      method: 'POST',
      url: '/api/app/exchange',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/exchange/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ExchangeDto>({
      method: 'GET',
      url: `/api/app/exchange/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: ExchangeListFilterDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ExchangeInListDto>>({
      method: 'GET',
      url: '/api/app/exchange',
      params: { name: input.name, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
