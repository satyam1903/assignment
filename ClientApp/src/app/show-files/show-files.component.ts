import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http"
import * as XLSX from 'xlsx';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-show-files',
  templateUrl: './show-files.component.html',
  styleUrls: ['./show-files.component.css']
})
export class ShowFilesComponent {

  constructor(private http: HttpClient,
    private datepipe: DatePipe) { }

  fileList: any;
  fileData: any;

  onsubmit() {


    const url = (`https://localhost:44324/apiAllFilesJson`);



    this.http.post<any>(url,null)
      .subscribe(result => {
        this.fileList = result;
        console.log(result);
      });
  }
  showFileContent(fileName: string) {
    this.http.get<any>(`https://localhost:44324/apiFile/GetJsonData?fileName=${fileName}`)
      .subscribe(result => {
        this.fileData = result;
        console.log(result);
      });
    console.log("hello");
  }
}
