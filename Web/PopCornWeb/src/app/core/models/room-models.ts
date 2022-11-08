import { Chair } from './chair-model';

export interface RoomModel {
  name: string;
  quantity: number;
  chairs: Chair[];
  id: string;
  notifications: any[];
}
