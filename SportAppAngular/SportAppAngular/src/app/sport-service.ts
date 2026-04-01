import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SportService {

  constructor(private http:HttpClient) { }
  
  getEvents(){
    return this.http.get<any[]>('https://localhost:7001/api/Sport')
  }

  getEvent(id:number){
    return this.http.get<any>(`https://localhost:7001/api/Sport/${id}`)
  }

  postEvent(event:any){
    return this.http.post<any>('https://localhost:7001/api/Sport', event)
  }
}
