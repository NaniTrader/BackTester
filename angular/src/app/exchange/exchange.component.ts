import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ExchangeService, ExchangeDto, ExchangeInListDto } from '@proxy/exchanges';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-exchange',
  templateUrl: './exchange.component.html',
  styleUrls: ['./exchange.component.scss'],
  providers: [ListService]
})
export class ExchangeComponent implements OnInit {

  exchange = { items: [], totalCount: 0 } as PagedResultDto<ExchangeInListDto>;
  isModalOpen = false;
  form: FormGroup;
  selectedExchange = {} as ExchangeDto;

  constructor(
    public readonly list: ListService,
    private exchangeService: ExchangeService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit() {
    const exchangeStreamCreator = (query) => this.exchangeService.getList(query);

    this.list.hookToQuery(exchangeStreamCreator).subscribe((response) => {
      this.exchange = response;
    });
  }

  createExchange() {
    this.selectedExchange = {} as ExchangeDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedExchange.name || '', Validators.required],
      description: [this.selectedExchange.description || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    this.exchangeService.create(this.form.value).subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }

  delete(id: number) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
      .subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.exchangeService.delete(id).subscribe(() => this.list.get());
        }
      });
  }
}
