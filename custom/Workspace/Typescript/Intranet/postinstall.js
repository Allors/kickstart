#! /usr/bin/env node

const path = require('path');
const lnk = require('lnk');

function link(src, dst){
    const basename = path.basename(src);

    lnk([src], dst, {force: true})
    .then(() => console.log(basename + ' linked') )
    .catch(() =>  console.log(basename + ' already linked'))
}

link ('../../../../allors/Platform/Framework/Typescript/framework', 'src/allors');

link ('../../../../allors/Core/Workspace/Typescript/Domain/src/allors/meta/core', 'src/allors/meta');
link ('../../../../allors/Core/Workspace/Typescript/Domain/src/allors/domain/core', 'src/allors/domain');
link ('../../../../allors/Core/Workspace/Typescript/Angular/src/allors/angular/core', 'src/allors/angular');
link ('../../../../allors/BaCorese/Workspace/Typescript/Material/src/allors/material/core', 'src/allors/material');

link ('../Domain/src/allors/domain/custom', 'src/allors/domain');
