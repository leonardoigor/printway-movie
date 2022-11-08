import { TokenModel } from './token-model';

export interface LoginResponseModel {
  token: TokenModel;
  expires: Date;
  tokenType: string;
  email: string;
}
