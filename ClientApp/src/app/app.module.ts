import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { UploadFileComponent } from './upload-file/upload-file.component';

import { ReactiveFormsModule } from '@angular/forms';
import * as XLSX from 'xlsx';
import { HttpClientModule } from '@angular/common/http';
import { FileInformation } from "./model/file-information";
import { CommonModule, DatePipe } from '@angular/common';
import { ShowFilesComponent } from './show-files/show-files.component';
import { Routes,RouterModule, ROUTES } from '@angular/router';


@NgModule({
  declarations: [
    AppComponent,
    UploadFileComponent,
    ShowFilesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    RouterModule.forRoot([
      {
        path: "/",
        component: UploadFileComponent
      },
      {
        path: "/showAllFiles",
        component: ShowFilesComponent
      }
    ])
    
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }
