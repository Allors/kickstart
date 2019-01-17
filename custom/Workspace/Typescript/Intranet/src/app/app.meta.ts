import { Meta } from '../allors/meta';
import { WorkspaceService } from '../allors/angular';

export function appMeta(workspaceService: WorkspaceService) {

  const { metaPopulation } = workspaceService;
  const m = metaPopulation as Meta;

  m.Person.list = '/contacts/people';
  m.Person.overview = '/contacts/person/:id';
  m.Organisation.list = '/contacts/organisations';
  m.Organisation.overview = '/contacts/organisation/:id';
}
