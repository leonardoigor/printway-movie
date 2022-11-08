import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path: 'home',
    redirectTo: 'home/salas',
    pathMatch: 'full',
  },
  {
    path: 'home',
    component: LayoutComponent,
    children: [
      {
        path: 'salas',
        loadChildren: () =>
          import('./modules/rooms/rooms.module').then((m) => m.RoomsModule),
      },
      {
        path: 'filmes',
        loadChildren: () =>
          import('./modules/movies/movies.module').then((m) => m.MoviesModule),
      },
      {
        path: 'sessoes',
        loadChildren: () =>
          import('./modules/sessions/sessions.module').then(
            (m) => m.SessionsModule
          ),
      },
    ],
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  // if path if home redirect to home/salas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
