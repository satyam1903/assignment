import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { ShowFilesComponent } from './show-files/show-files.component';
const routes: Routes = [
  {
    path: "/",
    component: UploadFileComponent
  },
  {
    path: "/showAllFiles",
    component: ShowFilesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
