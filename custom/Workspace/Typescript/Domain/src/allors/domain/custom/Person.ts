import { domain } from '../domain';
import { Person } from '../generated/Person.g';

declare module '../generated/Person.g' {
    interface Person {
        displayName;
    }
}

domain.extend((workspace) => {

    const obj: Person = workspace.prototypeByName['Person'];

    Object.defineProperty(obj, 'displayName', {
        get(this: Person): string {
            if (this.FirstName || this.LastName) {
                let name = null;
                if (this.FirstName) {
                    name = this.FirstName;
                }

                if (this.MiddleName) {
                    if (name != null) {
                        name += ' ' + this.MiddleName;
                    } else {
                        name = this.MiddleName;
                    }
                }

                if (this.LastName) {
                    if (name != null) {
                        name += ' ' + this.LastName;
                    } else {
                        name = this.LastName;
                    }
                }

                return name;
            }

            if (this.UserName) {
                return this.UserName;
            }

            return 'N/A';
        },
    });
});
