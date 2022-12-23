import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChoicePagePage } from './choice-page.page';

const routes: Routes = [
  {
    path: '',
    component: ChoicePagePage
  },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChoicePagePageRoutingModule {}
