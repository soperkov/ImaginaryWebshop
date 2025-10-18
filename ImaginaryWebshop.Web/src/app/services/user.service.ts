import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { RegistrationDto, UserDetailsDto, UserLoginDto } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private base = `${environment.apiBaseUrl}/user`;

  constructor(private http:HttpClient) {}

  register(user: RegistrationDto): Observable<string> {
    return this.http.post<string>(`${this.base}/register`, user);
  }

  login(user: UserLoginDto): Observable<string> {
    return this.http.post<string>(`${this.base}/login`, user);
  }

  getDetails(userId: string): Observable<UserDetailsDto> {
    return this.http.get<UserDetailsDto>(`${this.base}/${userId}`);
  }
}
