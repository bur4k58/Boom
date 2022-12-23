import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ChoicePagePageRoutingModule } from './choice-page-routing.module';

import { ChoicePagePage } from './choice-page.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ChoicePagePageRoutingModule
  ],
  declarations: [ChoicePagePage]
})
export class ChoicePagePageModule {}
