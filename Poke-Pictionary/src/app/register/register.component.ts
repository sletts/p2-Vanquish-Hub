import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterService } from '../register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
// Adding in defaults to store info
userName:string = "";
password:string = "";
phone:string = "";
email:string = "";

error:boolean = false;

 
  onSubmit():void{
    console.log(this.userName, this.password, this.email, this.password)
    this.registerService.register(this.userName, this.password, this.email, this.password)
    .subscribe((data) =>{
      console.log(data)
  },
  (error) =>{
    console.log(error)

    if(error.status == 400)
    {
      
    }
    else{
      this.router.navigate(["register"])
    }
    
    this.error = true;

    
  })
 

}
  
  constructor(private registerService:RegisterService, private router:Router) { }

  ngOnInit(): void {
  }
}
