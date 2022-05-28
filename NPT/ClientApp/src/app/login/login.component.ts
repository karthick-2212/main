import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

import { GlobalFunctions } from '../Global';
import { MsalService } from '@azure/msal-angular';
import { AuthenticationResult } from '@azure/msal-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private msalService: MsalService) { }

  ngOnInit(): void {

  }
  login() {
    this.msalService.loginPopup().subscribe((Response: AuthenticationResult) => {
      this.msalService.instance.setActiveAccount(Response.account);
      if (!GlobalFunctions.IsNullorEmpty(Response.account.username)) {
        sessionStorage.setItem('loggedUser', Response.account.username);
        this.router.navigate(["/home"]);
      }
    });
  }
}
