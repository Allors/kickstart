import { Component, EventEmitter, OnInit, Output, Self, OnDestroy } from '@angular/core';

import {  Saved, ContextService, MetaService } from '../../../../../angular';
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
    public metaService: MetaService) {

    this.m = this.metaService.m;
  }

  public ngOnInit(): void {

    this.person = this.allors.context.create('Person') as Person;
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
