import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { LoginInterface, ResultInterface } from '../interface/result.interface';
import { environment } from '../../../environments/environment';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  // public obtenerClima() {
  //   return this.http.get<any>(this.UrlBase);
  // }

  //--------------------------------------------------------------

  private URL: string;
  private loginData: LoginInterface | null;

  constructor(private http: HttpClient) {
    this.URL = environment.apiURL;
    this.loginData = null;
  }

  public get loginInfo(): LoginInterface {
    return this.loginData!;
  }

  public startSession(
    email: string,
    password: string
  ): Observable<ResultInterface> {
    const body = { email, password };
    return this.http.post<ResultInterface>(`${this.URL}/Login`, body).pipe(
      tap((data) => {
        console.log('Usuario logueado:', data);
        localStorage.setItem('IdUserEncrypt', data.data.idUserEncrypt!);
      })
    );
  }

  public registerUser(
    name: string,
    email: string,
    password: string
  ): Observable<ResultInterface> {
    const body = { name, email, password };
    return this.http.post<ResultInterface>(`${this.URL}/User`, body).pipe(
      tap((data) => {
        console.log('Usuario registrado:', data);
      })
    );
  }
}
