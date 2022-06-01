import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-poke-pictures',
  templateUrl: './poke-pictures.component.html',
  styleUrls: ['./poke-pictures.component.css']
})
export class PokePicturesComponent implements OnInit {

  pokedexMessage:string= "You made a decision!!"
  whoaMessage:string= "Pokémon Available to paint"
  random:number = Math.floor(Math.random() * 1126) + 1; 

    image:string = ""
    name:string= ""
  constructor() { }

  ngOnInit(): void {
    this.image = 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/' + this.random + '.png'
  }


}
