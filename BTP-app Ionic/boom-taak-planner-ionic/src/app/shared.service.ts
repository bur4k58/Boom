import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AuthService } from '@auth0/auth0-angular';
import { Translation } from './shared/translation.model';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
  data: string

  constructor(private http:HttpClient, public auth: AuthService) { }

  readonly APIUrl= "https://localhost:44352/";
  getGrowSite(){
    
    return this.http.get(this.APIUrl + "api/v1/GrowSite")

  }
  

  throwData(liveData : string){
    this.data = liveData;
    return console.log(this.data)
    }
  getUser(authId:String){  
    console.log(authId)
    const headers = {headers: new HttpHeaders({'content-type': 'application/json'})} 
  
    return  this.http.get<any[]>(this.APIUrl + "api/v1/User/getbyauthid/"+ authId, headers )
  }
  getZone(Id:number){  
    console.log(Id)
    const headers = {headers: new HttpHeaders({'content-type': 'application/json'})} 
  
    return  this.http.get(this.APIUrl + "api/v1/Zone/"+ Id, headers )
  }
  getUserToday(authId:String){  
    console.log(authId)
    const headers = {headers: new HttpHeaders({'content-type': 'application/json'})} 
  
    return  this.http.get<any[]>(this.APIUrl + "api/v1/User/getbyauthidfiltered/"+ authId, headers )
  }
  translation = new Translation();
  putStatus(scheduleId:number,tasksId: number, status:number ){  
  
    const headers = { method: 'PUT',headers: new HttpHeaders({'content-type': 'application/json'})} 

    const params= 
    {
      scheduleId: scheduleId,
      tasksId: tasksId,
      status: status
    }
    console.log(params)
    return this.http.put(this.APIUrl + "api/v1/ScheduleTask/"+params.scheduleId +"/"+ params.tasksId,params, headers )
 
  }


}
