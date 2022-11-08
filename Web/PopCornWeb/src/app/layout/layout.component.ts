import { Component, OnInit } from '@angular/core';
import { map, Observable, shareReplay } from 'rxjs';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { AuthService } from '../core/services/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
  menuItems: any[] = [];
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );
  email: string;

  constructor(
    private breakpointObserver: BreakpointObserver,
    private readonly authService: AuthService
  ) {
    this.email = '';
  }

  ngOnInit(): void {
    this.menuItems = [
      {
        name: 'Salas',
        to: '/home/salas',
        icon: 'home_outline',
        permission: 'Dashboard',
      },
      {
        name: 'Filmes',
        to: '/home/filmes',
        icon: 'home_outline',
        permission: 'Dashboard',
      },
      {
        name: 'Sessões',
        to: '/home/sessoes',
        icon: 'home_outline',
        permission: 'Dashboard',
      },
    ];
    const { token } = this.authService;
    this.email = token?.email || '';
  }

  get getHeigth() {
    var h = document.querySelector(
      'body > app-root > div > app-layout > mat-sidenav-container > mat-sidenav > div > mat-toolbar'
    )?.clientHeight;
    return `background: #5fa1d8; height: ${h}px;display: flex;justify-content: space-between;`;
  }
}
