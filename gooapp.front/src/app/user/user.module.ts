import { NgModule } from '@angular/core';
import { LoginComponent } from './view/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from './view/user/user.component';

@NgModule({
  declarations: [LoginComponent, UserComponent],
  imports: [HttpClientModule, ReactiveFormsModule],
  exports: [LoginComponent],
})
export class UserModule {}
