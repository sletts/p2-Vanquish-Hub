import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {



  // Login Logic
  register(userName:string, password:string, email:string, phone:string):Observable<any>{
    return this.http.post('https://vanquish-p2.azurewebsites.net/api/UserC/Add User?UserName=' + userName + '&password=' + password + '&PhoneNumber=' + phone + '&Email=' + email,
     //We need to add headers to specify content type
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
