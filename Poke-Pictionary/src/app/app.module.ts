import { NgModule,} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ArtWorkComponent } from './art-work/art-work.component';
import { PokePicturesComponent } from './poke-pictures/poke-pictures.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ArtworkService } from './artwork.service';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    
    AppComponent,
    UserComponent,
    ArtWorkComponent,
    PokePicturesComponent,
    NavBarComponent,
    HomePageComponent,
    LoginComponent,
    
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule
  ],
  exports:[
    NavBarComponent,
    ArtWorkComponent
  
  ],
  providers: [ArtworkService],
  bootstrap: [AppComponent]
})
export class AppModule { }
