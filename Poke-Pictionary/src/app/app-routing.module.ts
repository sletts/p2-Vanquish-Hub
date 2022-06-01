import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtWorkComponent } from './art-work/art-work.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginComponent } from './login/login.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { PokePicturesComponent } from './poke-pictures/poke-pictures.component';
import { RegisterComponent } from './register/register.component';
import { CanvasComponent } from './canvas/canvas.component';


const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomePageComponent},
  {path: 'pokemon', component: PokePicturesComponent},
  {path: 'nav-bar', component: NavBarComponent},
  {path: 'app-art-work', component: ArtWorkComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'canvas', component: CanvasComponent}
];

@NgModule({
  declarations:[],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
