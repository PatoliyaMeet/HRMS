import { Component } from '@angular/core';
import { LoginModel } from '../login-model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  email: string=""
  password: string =""

  constructor(private authService: AuthService, private route:Router) { }

  userModel=new LoginModel('','');

  ngSubmit(){

   this.email=this.userModel.Email;
   this.password=this.userModel.Password; 

   this.authService.loginUser(this.email, this.password).subscribe((response:any)=>{

    if(response=='Failure') {

      alert("LOGIN UNSUCCESSFUL");
      
    }
    else{

      alert("LOGIN SUCCESSFUL");
      localStorage.setItem('token',response.token)
      
      if(this.email=="hr@gmail.com" && this.password=="hr@123"){
   
         this.route.navigate(['/dashboard']);
      }
    }

   })

  }

}
