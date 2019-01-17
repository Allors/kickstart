import { Component, EventEmitter, OnInit, Output, Self, OnDestroy } from '@angular/core';

import { ErrorService, Saved, ContextService, MetaService } from '../../../../../angular';
import { Enumeration, Locale, Person } from '../../../../../domain';
import { PullRequest, Sort, Equals } from '../../../../../framework';
import { Meta } from '../../../../../meta';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'person-inline',
  templateUrl: './person-inline.component.html'
})
export class PersonInlineComponent implements OnInit, OnDestroy {

  @Output()
  public saved: EventEmitter<Person> = new EventEmitter<Person>();

  @Output()
  public cancelled: EventEmitter<any> = new EventEmitter();

  public person: Person;

  public m: Meta;

  public locales: Locale[];
  public genders: Enumeration[];
  public salutations: Enumeration[];

  constructor(
    private allors: ContextService,
    public metaService: MetaService,
    private errorService: ErrorService) {

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    const { pull, x } = this.metaService;

    const pulls = [
    ];

    this.allors.context
      .load('Pull', new PullRequest({ pulls }))
      .subscribe((loaded) => {
        this.person = this.allors.context.create('Person') as Person;
      }, this.errorService.handler);
  }

  public ngOnDestroy(): void {
    if (!!this.person) {
      this.allors.context.delete(this.person);
    }
  }

  public cancel(): void {
    this.cancelled.emit();
  }

  public save(): void {
      this.saved.emit(this.person);
      this.person = undefined;
  }
}
