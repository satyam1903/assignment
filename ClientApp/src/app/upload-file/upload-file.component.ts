import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http"
import * as XLSX from 'xlsx';
import { DatePipe } from '@angular/common';

type AOA = any[][];
export interface FileInformation {
  DeveloperName: string,
  fileData: any,
  timeStamp: any,
  timeZone: any,
  userAgent: string
}




@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent {

  constructor(private http: HttpClient,
    private datepipe: DatePipe  ) { }


  UploadForm = new FormGroup({
    DeveloperName: new FormControl(),
    FilePath: new FormControl()
  });
  timeStamp: any;
  timeZone: any;
  userAgent: any;
  data: AOA = [];
  fileName!: string;
  viewData: any;
  FileData: AOA = [];
 
  wopts: XLSX.WritingOptions = { bookType: 'xlsx', type: 'array' };


  onFileChange(evt: any) {
    /* wire up file reader */
     this.fileName=(evt.target.files[0].name);
    const target: DataTransfer = <DataTransfer>(evt.target);
    if (target.files.length !== 1) throw new Error('Cannot use multiple files');
    const reader: FileReader = new FileReader();
    reader.onload = (e: any) => {
      /* read workbook */
      const bstr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });

      /* grab first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* save data */
      this.FileData = <AOA>(XLSX.utils.sheet_to_json(ws, { header: 1 }));
      this.data = <AOA>(XLSX.utils.sheet_to_json(ws, { header: 2 }));
      console.log("this is " + this.FileData);
      var keys = this.data[0];

      //vacate keys from main array
      var newArr = this.data.slice(1, this.data.length);

      var formatted = [],
        data = newArr,
        cols = keys;
      for (var i = 0; i < data.length; i++) {
        var d = data[i],
          o = {};
       
        formatted.push(o);
      }
      console.log(JSON.stringify(this.data));
    };
    reader.readAsBinaryString(target.files[0]);
    this.timeStamp = this.datepipe.transform((new Date), 'MM/dd/yyyy h:mm:ss');
    this.timeZone = new Date().getTimezoneOffset();
    this.userAgent = window.navigator.userAgent;
    

  }





  submit() {

    let jsonData: FileInformation = {
      DeveloperName: this.UploadForm.value.DeveloperName,
      fileData: this.data,
      timeStamp: this.timeStamp,
      timeZone: this.timeZone,
      userAgent: this.userAgent
    }
    
    console.log(JSON.stringify(jsonData));

    const url = (`https://localhost:44324/apiFile/ParseFile?fileName=${this.fileName}`);
    
  

    this.http.post<any>(url, jsonData)
      .subscribe(result => {
        console.log(result);
      });
    this.http.get<any>('https://localhost:44324/apiFile/GetJsonData')
      .subscribe(result => {
        this.viewData = result;
        console.log(result);
      });
  }

}
