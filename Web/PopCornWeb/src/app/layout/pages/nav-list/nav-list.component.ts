import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-list',
  templateUrl: './nav-list.component.html',
  styleUrls: ['./nav-list.component.scss'],
})
export class NavListComponent implements OnInit {
  @Input()
  menuItems: any[] = [];

  constructor() {}

  ngOnInit(): void {}

  hasPermission(permission?: string): boolean {
    if (permission) {
      const hast_permission = this.menuItems.some(
        (item) =>
          item.permission?.toLocaleLowerCase() ===
          permission.toLocaleLowerCase()
      );
      return hast_permission;
    }
    return false;
  }
}
