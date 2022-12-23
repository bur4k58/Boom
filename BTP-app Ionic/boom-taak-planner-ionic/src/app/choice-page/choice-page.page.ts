import { Component, OnInit, Inject, NgModule, Pipe, PipeTransform, Injectable, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DOCUMENT, formatDate } from '@angular/common';
import { AuthService, User } from '@auth0/auth0-angular';
import { SharedService } from '../shared.service';
import { AuthGuard } from '../guards/auth.guard'
import { Translation } from '../shared/translation.model';


@Injectable({
  providedIn: 'any'
})
@Component({
  selector: 'app-choice-page',
  templateUrl: './choice-page.page.html',
  styleUrls: ['./choice-page.page.scss'],
})
@Pipe({
  name:'keys',
})
export class ChoicePagePage implements OnInit {
  id = '';
  query = '';
  dataSource: any;
  currentDate: Date = new Date();
  jsonTest: any;
  liveData: any;
  logUser: any;
  authId: any
  profileJson: any;
  
  Table: boolean = false;
  zone: boolean = false;

  filteredData:any


  constructor(private source:AuthGuard,private service:SharedService, public auth: AuthService, @Inject(DOCUMENT) private doc: Document, private router: Router, private activatedRoute: ActivatedRoute) { }
    dataUser(){
    
    let stringg: string = this.profileJson.slice(7,-1)
     this.service.getUser(stringg).subscribe(
      data => {   
        console.log(data) 
       data.forEach(function (value) {   
        value.schedules.forEach(function(values){
          values.date= formatDate(values.date ,'yyyy-MM-dd hh:mm','en-US')
          values.scheduleTask.forEach(function(valuess){
            console.log(valuess.tasks.title)
            
          })
        })
       })
      this.liveData = data;
       console.log("jdedjk")
       console.log(data)
       console.log(stringg)
       })
      }
      dataNow(){
        
        let stringg: string = this.profileJson.slice(7,-1)
        this.service.getUserToday(stringg).subscribe(
         data => {  

          data.forEach(function (value) {   
            value.schedules.forEach(function(values){
              values.date= formatDate(values.date ,'YYYY-MM-dd hh:mm','en-UK')   
              return values
            })
           })
           this.liveData = data
           console.log(data)
           console.log("jdedjk")
          })
             
          }
     authUser(){
      this.auth.user$.subscribe(
        (profile) => (this.profileJson) = JSON.stringify(profile.sub, null, 2)

      )
    }

  ngOnInit() {

      this.auth.user$.subscribe(
     
        (profile) => 
        
        (this.profileJson) = JSON.stringify(profile.sub, null, 2)
  
      )
  
    
  
  }
  zoneInfo :any
  moreInfo(Id:number){

  this.service.getZone(Id).subscribe(data =>{
    this.zoneInfo = data 
    console.log(Id)
    console.log(data)
    this.zone=  true;
  })
  }
  transform(value: any, ...args: any[]) {
        return Object.values(value);
    }
  logout(): void{
    this.auth.logout({returnTo: this.doc.location.origin});
    localStorage.removeItem('loggedIn');
  }
  put:any
  
  changeStatus(scheduleId:number,tasksId: number, status:number){
    this.service.putStatus(scheduleId,tasksId, status).subscribe(data => {
      data = this.put;
      console.log(this.put)
      this.dataNow();
    })

      
  }
}