import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Record } from './models/record';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};
//const apiUrl = "http://localhost:3000/api/v1/records";
const apiUrl = "/api/records";
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getRecords(token: any): Observable<Record[]> {
    return this.http.get<Record[]>(apiUrl, {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Type": "application/json"
      })
    })
      .pipe(
        tap(records => console.log('Fetch records')),
        catchError(this.handleError('getRecords', []))
      );
  }

  getRecord(id: number): Observable<Record> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Record>(url).pipe(
      tap(_ => console.log(`fetched record id=${id}`)),
      catchError(this.handleError<Record>(`getRecord id=${id}`))
    );
  }

  addRecord (record): Observable<Record> {
    return this.http.post<Record>(apiUrl, record, httpOptions).pipe(
      tap((record: Record) => console.log(`added record w/ id=${record.RecordId}`)),
      catchError(this.handleError<Record>('addRecord'))
    );
  }

  updateRecord (id, record): Observable<any> {
    const url = `${apiUrl}/${id}`;
    return this.http.put(url, record, httpOptions).pipe(
      tap(_ => console.log(`updated record id=${id}`)),
      catchError(this.handleError<any>('updateRecord'))
    );
  }

  deleteRecord (id): Observable<Record> {
    const url = `${apiUrl}/${id}`;

    return this.http.delete<Record>(url, httpOptions).pipe(
      tap(_ => console.log(`deleted record id=${id}`)),
      catchError(this.handleError<Record>('deleteRecord'))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
