import { Injectable, Input } from '@angular/core';
import { CanLoad, Route, Router, UrlSegment, UrlTree } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';
import { SharedService } from '../shared.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanLoad {
  
  constructor(private service:SharedService,public auth: AuthService,private router: Router){

  }
  
  profileJson: string;
  canLoad() {
    const isAuthenticated = localStorage.getItem('loggedIn');;
    if (isAuthenticated){
      console.log(isAuthenticated)
      console.log(localStorage.getItem('loggedIn'))
      console.log("trueeeee")

      return true;
    }else{
      console.log(isAuthenticated)
      console.log(localStorage.getItem('loggedIn'))
      console.log("falseeeeeeeee")
      const navigation = this.router.getCurrentNavigation();
      console.log('nav: ', navigation);

      let url = '/';
      if (navigation){
        url = navigation.extractedUrl.toString();
      }
      console.log('got url:', url)
      this.router.navigate(['/'], {queryParams: {returnto: url}});
      return false;
    }
  }
  
}
