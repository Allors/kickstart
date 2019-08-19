import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';

import { ids } from '../allors/meta/generated';

import { PersonCreateModule, PersonCreateComponent } from '../allors/material/custom/objects/person/create/person-create.module';

import { ObjectService, OBJECT_CREATE_TOKEN, OBJECT_EDIT_TOKEN } from '../allors/material/core/services/object';

export const create = {
  [ids.Person]: PersonCreateComponent,
};

export const edit = {
};

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,

    PersonCreateModule,
  ],
  entryComponents: [
    PersonCreateComponent,
  ],
  providers: [
    ObjectService,
    { provide: OBJECT_CREATE_TOKEN, useValue: create },
    { provide: OBJECT_EDIT_TOKEN, useValue: edit },
  ]
})
export class AppDialogModule {

  constructor(@Optional() @SkipSelf() core: AppDialogModule) {
    if (core) {
      throw new Error('Use FactoryModule from AppModule');
    }
  }
}
