import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SessionModel } from 'src/app/core/models/session-model';
import { SessionService } from 'src/app/core/services/session.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss'],
})
export class IndexComponent implements OnInit {
  sessions: SessionModel[] = [];
  constructor(
    private readonly service: SessionService,
    private readonly router: Router
  ) {
    this.getAll();
  }

  ngOnInit(): void {}
  getAll() {
    this.service.getAll().subscribe((sessions) => {
      this.sessions = sessions.data;
    });
  }
  convertHourToMinutes(hour: number) {
    return Number((hour * 60).toFixed(0));
  }
  goToBye(session: SessionModel) {
    this.router.navigate(['/home/sessoes/comprar'], {
      queryParams: {
        id: session.id,
      },
    });
  }

  create() {
    this.router.navigate(['/home/sessoes/formulario']);
  }
  edit(session: SessionModel) {
    this.router.navigate(['/home/sessoes/formulario', { id: session.id }]);
  }
  delete(session: SessionModel) {
    const dialog = confirm(
      `Deseja realmente excluir com filme ${session.movie.title}?`
    );
    if (dialog) {
      this.service.delete(session.id).subscribe(() => {
        this.getAll();
      });
    }
    this.router.navigate(['/home/sessoes']);
  }
}
