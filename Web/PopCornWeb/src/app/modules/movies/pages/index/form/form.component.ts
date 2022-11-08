import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
  MovieId: any;
  form: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly activatedRoute: ActivatedRoute,
    // private readonly snackbar: MatSnackBar,
    private readonly service: MovieService,
    private readonly router: Router
  ) {
    this.form = this.formBuilder.group({
      title: ['', [Validators.required, Validators.maxLength(255)]],
      description: ['', [Validators.required]],
      minutes: ['', [Validators.required]],
      hours: ['', [Validators.required]],
      image: ['', [Validators.required]],
    });
    this.activatedRoute.params.subscribe((params) => {
      this.MovieId = params['id'];
      if (this.MovieId) {
        this.service.getById(this.MovieId).subscribe((response: any) => {
          this.form.patchValue(response.data);
        });
      }
    });
  }

  ngOnInit(): void {}
  submitForm() {
    if (this.form.valid) {
      if (this.MovieId) {
        const id = this.MovieId;
        this.service
          .update(this.MovieId, {
            id: id,
            movie: this.form.value,
          })
          .subscribe(
            (response: any) => {
              this.router.navigate(['home/filmes']);
            },
            (error) => {
              console.log(error);
            }
          );
      } else {
        this.service.create({ movie: this.form.value }).subscribe(
          (response: any) => {
            this.router.navigate(['home/filmes']);
          },
          (error) => {
            console.log(error);
          }
        );
      }
    }
  }
}
