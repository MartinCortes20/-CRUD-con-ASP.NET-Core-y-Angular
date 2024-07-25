// src/app/app.module.ts (si aún lo tienes)

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule (remover si usas `ApplicationConfig`)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
