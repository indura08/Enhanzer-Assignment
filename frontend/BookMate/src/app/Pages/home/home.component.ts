import { Component } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { FooterComponent } from '../../components/footer/footer.component';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { UserService } from '../../../services/user.service';
import { error } from 'console';
import { RouterModule } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'home',
  standalone: true,
  imports: [HeaderComponent, FooterComponent, CommonModule, FormsModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  // i didnt add much more user functionality since it hasnt mentioned as a requirement in the assignment pdf. 
  //how ever i just add some functionality to demonstrate that users can create user account , and those user account will be pass to the database successfully 
  // if i were to develop this to have good securitymeasurement s, iw ouldlike to add login - logout system, authentication and authorization with jwt 
  // you can see how i did those security measurements checking my previous project link :  "https://github.com/indura08/NourishNet-Web-Application"

  constructor(private userService:UserService){}

  public createProfile(profileForm:NgForm){
    this.userService.createUser(profileForm.value).subscribe(
      (response: string) => {
        alert("profile created")
        console.log(response);
      },

      (error:HttpErrorResponse) => {
        alert("Error occured")
        console.log(error) //this is for debugging purposes
      }


    )

  }
}
