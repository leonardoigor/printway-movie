import { MovieModel } from './movie-model';
import { RoomModel } from './room-models';

export interface SessionModel {
  date: Date;
  startDate: Date;
  endDate: Date;
  price: number;
  typeAnimation: number;
  isDubbed: boolean;
  movie: MovieModel;
  room: RoomModel;
  roomId: string;
  movieId: string;
  id: string;
  notifications: any[];
}
