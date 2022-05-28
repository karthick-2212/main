import { Component, OnInit } from '@angular/core';
import { roleRequestModel, roleResponsemodel } from 'src/app/models/rolemodel';
import { RoleService } from 'src/app/services/role.service'
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  showMypronunciation: boolean = false;
  showMyTeam: boolean = false;
  showSearch: boolean = false;
  loggedinUserId: string;

  rolerequest: roleRequestModel;
  roleresponse: roleResponsemodel;

  constructor(private roleService: RoleService) { }

  ngOnInit(): void {
    this.loggedinUserId = sessionStorage.getItem('loggedUser');
    this.getUserRoles();
  }

  getUserRoles() {
    this.rolerequest =
    {
      loggedinId: this.loggedinUserId
    }
    this.roleService.GetUserRoles(this.rolerequest).subscribe(res => {
      this.roleresponse = res;
      sessionStorage.setItem('isadmin', (this.roleresponse.isAdmin) ? "true" : "false");

    });

  }

  menuclick(id: number) {
    switch (id) {
      case 1:
        this.showMyTeam = this.showSearch = false;
        this.showMypronunciation = true;
        break;
      case 2:
        this.showMypronunciation = this.showSearch = false;
        this.showMyTeam = true;
        break;
      case 3:
        this.showMypronunciation = this.showMyTeam = false;
        this.showSearch = true;
        break;
    }
  }
}
