import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RoomModel } from 'src/app/core/models/room-models';
import { RoomService } from 'src/app/core/services/room.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss'],
})
export class IndexComponent implements OnInit {
  displayedColumns: string[];
  dataSource: RoomModel[] = [];
  dataSource_map: RoomModel[] = [];
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
    private readonly service: RoomService
  ) {
    this.dataSource_map = [];
    this.displayedColumns = ['name', 'quantity'];
    this.form = this.formBuilder.group({
      name: ['', [Validators.required]],
      quantity: ['', [Validators.required]],
    });
    this.getAll();
  }

  ngOnInit(): void {}
  getAll() {
    this.service.getAll().subscribe((response: any) => {
      this.dataSource = response;
      this.dataSource_map = response;
    });
  }
}
