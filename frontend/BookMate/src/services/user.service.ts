import { Injectable } from '@angular/core';
import { environment } from '../../Environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../app/data-models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  public createUser(newUser:User):Observable<string>{
    return this.http.post<string>(`${this.apiUrl}/User/create` , newUser);
  }

  public deleteUser(id:number):Observable<string>{
    return this.http.delete<string>(`${this.apiUrl}/User/delete`);
  }

  // i didnt add much more user functionality since it hasnt mentioned as a requirement in the assignment pdf. 
  //how ever i just add some functionality to demonstrate that users can create user account , and those user account will be pass to the database successfully 
  // if i were to develop this to have good securitymeasurement s, iw ouldlike to add login - logout system, authentication and authorization with jwt 
  // you can see how i did those security measurements checking my previous project link :  "https://github.com/indura08/NourishNet-Web-Application"
}
