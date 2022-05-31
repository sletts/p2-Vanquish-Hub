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
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { TestingComponent } from './testing/testing.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    ArtWorkComponent,
    PokePicturesComponent,
    NavBarComponent,
    HomePageComponent,
    LoginButtonComponent,
    LoginComponent,
    TestingComponent,

   
    
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
