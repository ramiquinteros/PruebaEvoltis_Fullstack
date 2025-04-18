import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { User } from '../models/user.model';
import { Result } from '../models/result.model';
import { Observable } from 'rxjs';
import { environment } from 'src/Environments/environments';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = environment.BACK_URL;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Result<User[]>> {
    return this.http.get<Result<User[]>>(this.baseUrl);
  }

  getById(id: number): Observable<Result<User>> {
    return this.http.get<Result<User>>(`${this.baseUrl}/${id}`);
  }

  create(user: User): Observable<Result<boolean>> {
    return this.http.post<Result<boolean>>(this.baseUrl, user);
  }

  update(user: User): Observable<Result<boolean>> {
    return this.http.put<Result<boolean>>(this.baseUrl, user);
  }

  delete(id: number): Observable<Result<boolean>> {
    return this.http.delete<Result<boolean>>(`${this.baseUrl}/${id}`);
  }
}
