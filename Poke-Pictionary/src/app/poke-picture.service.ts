// Inject HttpClient into our service
import { Injectable, ValueProvider } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { HttpClientModule, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, catchError } from 'rxjs';
import { map } from 'rxjs/operators';
  
  let min= 1;
  let max= 898;
  const pokeD= Math.floor(Math.random() * (max - min + 1)) + min; 
  const endpoint= 'https://pokeapi.co/api/v2/pokemon/'+ {pokeD} +'/';


  @Injectable({
      providedIn: 'root'
  })
  export class PokePictureService {
    
    getProduct(id:string): Observable<any> {
      return this.http.get(endpoint + 'name/'+ id);/**.pipe(
        map(this.extractData),
        catchError(this.handleError)
      );**/
    }
    constructor(private http: HttpClient) { }

    private handleError(error: HttpErrorResponse): any {
      if (error.error instanceof ErrorEvent) {
        console.error('An error occurred:', error.error.message);
      } else {
        console.error(
          `Backend returned code ${error.status}, ` +
          `body was: ${error.error}`);
      }
      return throwError(
            'Something bad happened; please try again later.');
    }
    private extractData(res: Response): any {
        const body = res;
        return body || { };
    }

 }