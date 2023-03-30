import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { ViewContentComponent } from './view-content/view-content.component'
const routes: Routes = [
  //{
  //  path: "/",
  //  component: UploadFileComponent
  //},
  //{
  //  path: "/JsonView",
  //  component: ViewContentComponent
  //}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
