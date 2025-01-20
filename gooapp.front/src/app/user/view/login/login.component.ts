import { Component, inject } from '@angular/core';
import { UserService } from '../../service/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'goapp-user-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  userService: UserService = inject(UserService);
  public frmLogin: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.frmLogin = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  goRegisterUser() {
    this.router.navigate(['/register-user']);
  }

  startSession(): void {
    this.userService
      .startSession(this.frmLogin.value.email, this.frmLogin.value.password)
      .subscribe({
        next: (data) => {
          this.toastr.success('Inicio de sesión exitoso.', 'GoApp');
          this.router.navigate(['/shipping-quote']);
        },
        error: (err) => {
          if (err.error && err.error.errors && err.error.errors.length > 0) {
            this.toastr.error(err.error.errors[0], 'GoApp');
          }
        },
      });
  }
}
