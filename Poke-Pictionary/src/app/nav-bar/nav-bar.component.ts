import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  // Create method to navigate to the login page
  navigateLogin(){
    this.router.navigate(['user']);
  }

  // Inject our router in the constructor to navigate
  constructor(private router:Router) { 
    console.log("Navbar constructed");
  }

  ngOnInit(): void {
    console.log("Navbar initialized");
  }

}
