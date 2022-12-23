import { DOCUMENT, formatDate } from '@angular/common';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { SharedService } from '../shared.service';


@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.page.html',
  styleUrls: ['./navigation.page.scss'],
})


export class NavigationPage implements OnInit {
  profileJson: any;
  liveData: any[];



  constructor(private service:SharedService, public auth: AuthService, @Inject(DOCUMENT) private doc: Document, private router: Router, private activatedRoute: ActivatedRoute) { }

  dataUser(){
    let stringg: string = this.profileJson.slice(7,-1)
   this.service.getUser(stringg).subscribe(
      data => {    
       data.forEach(function (value) {   
        value.schedules.forEach(function(values){
          values.date= formatDate(values.date ,'yyyy-MM-dd','en-US')
        })
       })
       this.liveData = data;
       console.log("jdedjk")
       console.log(this.liveData)
       console.log(stringg)
      
       })
      }
  ngOnInit() {
    this.auth.user$.subscribe(
      (profile) => (this.profileJson) = JSON.stringify(profile.sub, null, 2)
      
    )
    this.auth.user$.forEach(function (value) {
      console.log(value)
    }); 
    console.log(this.liveData)    
  }
  

}
