import { Component, OnInit } from '@angular/core';
import { Chair } from 'src/app/core/models/chair-model';

@Component({
  selector: 'app-chairs',
  templateUrl: './chairs.component.html',
  styleUrls: ['./chairs.component.scss'],
})
export class ChairsComponent implements OnInit {
  chairs: Chair[] = [];
  constructor() {
    this.chairs = [
      {
        sizeByCollumn: 20,
        name: 'A-1',
        index: 0,
      },
      {
        sizeByCollumn: 20,
        name: 'A-2',
        index: 1,
      },
      {
        sizeByCollumn: 20,
        name: 'A-3',
        index: 2,
      },
      {
        sizeByCollumn: 20,
        name: 'A-4',
        index: 3,
      },
      {
        sizeByCollumn: 20,
        name: 'A-5',
        index: 4,
      },
      {
        sizeByCollumn: 20,
        name: 'A-6',
        index: 5,
      },
      {
        sizeByCollumn: 20,
        name: 'A-7',
        index: 6,
      },
      {
        sizeByCollumn: 20,
        name: 'A-8',
        index: 7,
      },
      {
        sizeByCollumn: 20,
        name: 'A-9',
        index: 8,
      },
      {
        sizeByCollumn: 20,
        name: 'A-10',
        index: 9,
      },
      {
        sizeByCollumn: 20,
        name: 'A-11',
        index: 10,
      },
      {
        sizeByCollumn: 20,
        name: 'A-12',
        index: 11,
      },
      {
        sizeByCollumn: 20,
        name: 'A-13',
        index: 12,
      },
      {
        sizeByCollumn: 20,
        name: 'A-14',
        index: 13,
      },
      {
        sizeByCollumn: 20,
        name: 'A-15',
        index: 14,
      },
      {
        sizeByCollumn: 20,
        name: 'A-16',
        index: 15,
      },
      {
        sizeByCollumn: 20,
        name: 'A-17',
        index: 16,
      },
      {
        sizeByCollumn: 20,
        name: 'A-18',
        index: 17,
      },
      {
        sizeByCollumn: 20,
        name: 'A-19',
        index: 18,
      },
      {
        sizeByCollumn: 20,
        name: 'A-20',
        index: 19,
      },
      {
        sizeByCollumn: 20,
        name: 'B-1',
        index: 20,
      },
      {
        sizeByCollumn: 20,
        name: 'B-2',
        index: 21,
      },
      {
        sizeByCollumn: 20,
        name: 'B-3',
        index: 22,
      },
      {
        sizeByCollumn: 20,
        name: 'B-4',
        index: 23,
      },
      {
        sizeByCollumn: 20,
        name: 'B-5',
        index: 24,
      },
      {
        sizeByCollumn: 20,
        name: 'B-6',
        index: 25,
      },
      {
        sizeByCollumn: 20,
        name: 'B-7',
        index: 26,
      },
      {
        sizeByCollumn: 20,
        name: 'B-8',
        index: 27,
      },
      {
        sizeByCollumn: 20,
        name: 'B-9',
        index: 28,
      },
      {
        sizeByCollumn: 20,
        name: 'B-10',
        index: 29,
      },
      {
        sizeByCollumn: 20,
        name: 'B-11',
        index: 30,
      },
      {
        sizeByCollumn: 20,
        name: 'B-12',
        index: 31,
      },
      {
        sizeByCollumn: 20,
        name: 'B-13',
        index: 32,
      },
      {
        sizeByCollumn: 20,
        name: 'B-14',
        index: 33,
      },
      {
        sizeByCollumn: 20,
        name: 'B-15',
        index: 34,
      },
      {
        sizeByCollumn: 20,
        name: 'B-16',
        index: 35,
      },
      {
        sizeByCollumn: 20,
        name: 'B-17',
        index: 36,
      },
      {
        sizeByCollumn: 20,
        name: 'B-18',
        index: 37,
      },
      {
        sizeByCollumn: 20,
        name: 'B-19',
        index: 38,
      },
      {
        sizeByCollumn: 20,
        name: 'B-20',
        index: 39,
      },
      {
        sizeByCollumn: 20,
        name: 'C-1',
        index: 40,
      },
      {
        sizeByCollumn: 20,
        name: 'C-2',
        index: 41,
      },
      {
        sizeByCollumn: 20,
        name: 'C-3',
        index: 42,
      },
      {
        sizeByCollumn: 20,
        name: 'C-4',
        index: 43,
      },
      {
        sizeByCollumn: 20,
        name: 'C-5',
        index: 44,
      },
      {
        sizeByCollumn: 20,
        name: 'C-6',
        index: 45,
      },
      {
        sizeByCollumn: 20,
        name: 'C-7',
        index: 46,
      },
      {
        sizeByCollumn: 20,
        name: 'C-8',
        index: 47,
      },
      {
        sizeByCollumn: 20,
        name: 'C-9',
        index: 48,
      },
      {
        sizeByCollumn: 20,
        name: 'C-10',
        index: 49,
      },
    ];
  }

  getClassChair(chair: any) {
    let ischecked = chair.index == this.chooSedChair ? 'checked' : '';
    return `chair ${ischecked}`;
  }

  chooSedChair = -1;
  choosedChair(index: number) {
    this.chooSedChair = index;
  }
  ngOnInit(): void {}

  get getChairs() {
    // split array into chunks
    const chunk = (arr: any, size: any) =>
      Array.from({ length: Math.ceil(arr.length / size) }, (v, i) =>
        arr.slice(i * size, i * size + size)
      );
    return chunk(this.chairs, this.chairs[0].sizeByCollumn);
  }
}
