import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ArtWorkComponent } from './art-work/art-work.component';
import { PokePicturesComponent } from './poke-pictures/poke-pictures.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginButtonComponent } from './login-button/login-button.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    ArtWorkComponent,
    PokePicturesComponent,
    NavBarComponent,
    HomePageComponent,
    LoginButtonComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
