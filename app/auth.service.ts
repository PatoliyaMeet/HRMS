import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  loginUser(email:string, password:string ){

    console.log(email,password)

   return this.http.post("https://localhost:7218/api/Auth/Login",{
      EmailOrUserName:email,
      Password:password
    },{
      responseType:'text'
    })
  }
}
