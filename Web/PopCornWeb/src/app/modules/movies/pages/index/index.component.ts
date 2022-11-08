import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { MovieModel } from 'src/app/core/models/movie-model';
import { MovieService } from 'src/app/core/services/movie.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss'],
})
export class IndexComponent implements OnInit {
  Add() {
    this.router.navigate(['home/filmes/novo']);
  }
  delete(model: MovieModel) {
    this.service.remove(model.id).subscribe(
      (response: any) => {
        this.getAll();
      },
      (error) => {
        console.log(error);
      }
    );
  }
  edit(model: MovieModel) {
    this.router.navigate(['home/filmes/novo', { id: model.id }]);
  }
  displayedColumns: string[];
  dataSource: MovieModel[] = [];
  dataSource_map: MovieModel[] = [];
  filters = {
    start: new Date(),
    end: new Date(),
  };
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  previousPageIndex = 0;
  pageIndex = 0;
  form: FormGroup;

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly router: Router,
    private readonly service: MovieService
  ) {
    this.dataSource_map = [];
    this.displayedColumns = ['title', 'description', 'hours', 'Actions'];
    this.form = this.formBuilder.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      hours: ['', [Validators.required]],
    });

    this.getAll();
  }

  ngOnInit(): void {}
  getAll() {
    this.service.getAll().subscribe(
      (response: any) => {
        this.dataSource_map = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getDuration(hour: number, minutes: number) {
    let h = hour.toString();
    h = h.padStart(2, '0');
    let m = minutes.toString();
    m = m.padStart(2, '0');
    return `${h}:${m}`;
  }
}
