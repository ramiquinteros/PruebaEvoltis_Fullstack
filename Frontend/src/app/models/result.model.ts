export interface Result<T> {
    succeeded: boolean;
    response: T;
    message: string;
    code: number;
  }
  