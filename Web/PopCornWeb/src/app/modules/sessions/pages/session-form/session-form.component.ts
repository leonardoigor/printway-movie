import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieModel } from 'src/app/core/models/movie-model';
import { RoomModel } from 'src/app/core/models/room-models';
import { MovieService } from 'src/app/core/services/movie.service';
import { RoomService } from 'src/app/core/services/room.service';
import { SessionService } from 'src/app/core/services/session.service';

@Component({
  selector: 'app-session-form',
  templateUrl: './session-form.component.html',
  styleUrls: ['./session-form.component.scss'],
})
export class SessionFormComponent implements OnInit {
  SessionId: string = '';
  form: FormGroup;
  moviesList: MovieModel[] = [];
  roomsList: RoomModel[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly activatedRoute: ActivatedRoute,
    // private readonly snackbar: MatSnackBar,
    private readonly service: SessionService,
    private readonly serviceMovie: MovieService,
    private readonly serviceRoom: RoomService,
    private readonly router: Router
  ) {
    this.form = this.formBuilder.group({
      date: ['', Validators.required],
      startDate: ['', Validators.required],
      price: ['', Validators.required],
      typeAnimation: ['', Validators.required],
      isDubbed: ['', Validators.required],
      roomId: ['', Validators.required],
      movieId: ['', Validators.required],
    });
    this.activatedRoute.params.subscribe((params) => {
      this.SessionId = params['id'];
      if (this.SessionId) {
        this.service.getById(this.SessionId).subscribe((response: any) => {
          this.form.patchValue(response.data);
        });
      }
    });
    this.getDatas();
  }
  getDatas(): void {
    this.serviceMovie.getAll().subscribe((response: any) => {
      this.moviesList = response.data;
    });
    this.serviceRoom.getAll().subscribe((response: any) => {
      this.roomsList = response;
    });
  }
  ngOnInit(): void {
    // check if id is passed
    this.activatedRoute.params.subscribe((params) => {
      this.SessionId = params['id'];
      if (this.SessionId) {
        this.service.getById(this.SessionId).subscribe((response: any) => {
          this.form.patchValue(response.data);
        });
      }
    });
  }
  submitForm(): void {
    let value = this.form.value;
    value.typeAnimation = Number(value.typeAnimation);
    if (this.form.valid) {
      if (this.SessionId) {
        this.service
          .update(this.SessionId, value)
          .subscribe((response: any) => {
            this.router.navigate(['/home/sessoes']);
          });
      } else {
        this.service.create(value).subscribe((response: any) => {
          this.router.navigate(['/home/sessoes']);
        });
      }
    }
  }
}
