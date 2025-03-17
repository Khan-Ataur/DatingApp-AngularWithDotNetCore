
import { Component, inject, Inject, OnInit } from '@angular/core';

import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'DatingApp';

  private accountService = inject(AccountService);
  
  /*ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (response: any) => this.users = response,
      error: (error: any) => console.log(error),
      complete: () => console.log('Request has completed.')
    });
  } */


  ngOnInit(): void { 
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if(!userString)
    {
      return;
    }

    const userLoginInfo = JSON.parse(userString);
    this.accountService.currentUser.set(userLoginInfo);

  }




}
