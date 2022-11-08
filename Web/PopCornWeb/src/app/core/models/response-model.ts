export interface ResponseModel<T> {
  statusCode: number;
  success: boolean;
  messages: any[];
  data: T;
}
