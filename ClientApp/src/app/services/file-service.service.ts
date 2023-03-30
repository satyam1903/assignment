import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class FileServiceService {

  constructor(private http: HttpClient) { }
  baseurl: string="http:localhost";


  //postFile() {
  //  this.http.post(`http://localhost:4200/`);
  //}
}
