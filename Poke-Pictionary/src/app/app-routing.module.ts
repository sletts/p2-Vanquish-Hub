import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginComponent } from './login/login.component';
import { PokePicturesComponent } from './poke-pictures/poke-pictures.component';
import { TestingComponent } from './testing/testing.component';
import { ArtWorkComponent } from './art-work/art-work.component';


const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomePageComponent},
  {path: 'pokemon', component: PokePicturesComponent},
  {path: 'testing', component: TestingComponent},
  {path: 'art-work', component: ArtWorkComponent}

  
];

@NgModule({
  declarations:[],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
