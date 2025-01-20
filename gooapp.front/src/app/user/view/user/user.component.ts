import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../service/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'goapp-user-registerUser',
  standalone: false,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent {
  userService: UserService = inject(UserService);
  frmCreateUser: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.frmCreateUser = this.fb.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  registerUser(): void {
    this.userService
      .registerUser(
        this.frmCreateUser.value.name,
        this.frmCreateUser.value.email,
        this.frmCreateUser.value.password
      )
      .subscribe({
        next: (data) => {
          this.toastr.success('Usuario creado correctamente', 'GoApp');
          this.router.navigate(['/login']);
        },
        error: (data) => {
          this.toastr.error('No se pudo crear el usuario.', 'GoApp');
        },
      });
  }
}
