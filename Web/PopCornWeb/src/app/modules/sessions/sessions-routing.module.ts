import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChairsComponent } from './pages/chairs/chairs.component';
import { IndexComponent } from './pages/index/index.component';
import { SessionFormComponent } from './pages/session-form/session-form.component';

const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
  },
  {
    path: 'comprar',
    component: ChairsComponent,
  },
  {
    path: 'formulario',
    component: SessionFormComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SessionsRoutingModule {}
