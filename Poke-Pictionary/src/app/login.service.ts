import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  token:string = ""


  // Login Logic
  login(userName:string, password:string):Observable<any>{
    return this.http.post('https://vanquish-p2.azurewebsites.net/api/UserC/Authenticate?UserName='+ userName + '&password='+ password,
    // We need to add headers to specify content type
    {headers: {'Content-Type':'application/json'}}
    )
    .pipe(
      catchError((e) =>{
        return throwError(e)
      }
    ))
  }
  // Inject HttpClient into our service
  constructor(private http:HttpClient) { }
}