import { Component, OnInit } from '@angular/core'; 

@Component({
  selector: 'art-work',
  templateUrl: './art-work.component.html',
  styleUrls: ['./art-work.component.css']
})
export class ArtWorkComponent implements OnInit {

  constructor() { console.log("Poké - Pictionary Started");}

  ngOnInit(): void {
  }

}