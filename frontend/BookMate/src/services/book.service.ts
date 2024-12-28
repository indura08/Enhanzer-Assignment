import { Injectable } from '@angular/core';
import { environment } from '../../Environment/environment';
import { Observable } from 'rxjs';
import { Book } from '../app/data-models/Book';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  public getBooks():Observable<Book[]>{

    return this.http.get<Book[]>(`${this.apiUrl}/Book/all`)
    //this is because i didnt use  any authorization ,authentication functionality for this project
    // if i used that i should pass the jwt toke (if jwt were used) with this request using headers

  }

  public getBookById(id:number):Observable<Book>{
    return this.http.get<Book>(`${this.apiUrl}/Book/${id}`)
  }

  public updateBookById(id:number, newBook:Book):Observable<string>{
    return this.http.put<string>(`${this.apiUrl}/Book/update/${id}` , newBook)
  }

  public createNewBook(newBook:Book):Observable<string>{
    return this.http.post<string>(`${this.apiUrl}/Book/create` , newBook)
  }

  public deleteBookById(id:number):Observable<string>{
    return this.http.delete<string>(`${this.apiUrl}/Book/delete/${id}`)
  }
}

