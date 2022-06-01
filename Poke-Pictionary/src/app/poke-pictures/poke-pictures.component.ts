import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-poke-pictures',
  templateUrl: './poke-pictures.component.html',
  styleUrls: ['./poke-pictures.component.css']
})
export class PokePicturesComponent implements OnInit {

  pokedexMessage:string= "You made a decision!!"
  whoaMessage:string= "Page work in progress"

  constructor() { }

  ngOnInit(): void {
  }

}
