import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  welcomeMessage:string= "Welcome to Poké - Pictionary !!"

  constructor() { console.log("Poké - Pictionary Started");}

  ngOnInit(): void { console.log("Poké - Pictionary Started");}

}