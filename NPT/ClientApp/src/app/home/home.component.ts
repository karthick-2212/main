import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import { roleRequestModel, roleResponsemodel } from 'src/app/models/rolemodel';
import { RoleService } from 'src/app/services/role.service'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  public loggedinUsername: string = '';
  public username: string = '';
  rolerequest: roleRequestModel;
  roleresponse: roleResponsemodel;
  isAdmin: boolean = false;
  constructor(private router: Router, private msalService: MsalService, private roleService: RoleService) { }

  ngOnInit(): void {
    this.loggedinUsername = sessionStorage.getItem('loggedUser');
    console.log(this.loggedinUsername);
    this.getUserRoles();
  }

  getUserRoles() {
    this.rolerequest =
    {
      loggedinId: this.loggedinUsername
    }
    this.roleService.GetUserRoles(this.rolerequest).subscribe(res => {
      this.roleresponse = res;
      this.isAdmin = this.roleresponse.isAdmin;
      sessionStorage.setItem('isadmin', (this.roleresponse.isAdmin) ? "true" : "false");

    });
  }
  
  logout() {
    if (confirm("Are you sure to Sign-Out ?"))
      this.msalService.logout();
    this.router.navigate(['/'])
  }
}
