import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalModule, MsalService, MSAL_INSTANCE } from '@azure/msal-angular';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { MenuComponent } from 'src/app/menu/menu.component';
import { LoginComponent } from 'src/app/login/login.component'
import { MypronunciationComponent } from './mypronunciation/mypronunciation.component';
import { SearchComponent } from './search/search.component'
import { MyteamComponent } from './myteam/myteam.component';
import { Pronunciationservice } from './services/pronunciation.service';
import { Searchservice } from './services/search.servics';
import { RoleService } from 'src/app/services/role.service'
import { IPublicClientApplication, PublicClientApplication } from '@azure/msal-browser';

export function MSALInstanceFactory(): IPublicClientApplication {

  return new PublicClientApplication({
    auth:
    {
      clientId: '10c7ee7f-d6c4-4a51-a596-00366271b85d',
      redirectUri: 'http://localhost:8818/'
    }
  })
}
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    LoginComponent,
    MyteamComponent,
    MypronunciationComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MsalModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent }
    ], { useHash: true, onSameUrlNavigation: 'reload' })
  ],
  providers: [Pronunciationservice, Searchservice,
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    MsalService,
    RoleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
