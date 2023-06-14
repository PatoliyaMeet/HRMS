import { Component } from '@angular/core';
import { RegisterModel } from '../register-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  userModel=new RegisterModel('','','','','');

  ngSubmit(){
    
  }
  

}
