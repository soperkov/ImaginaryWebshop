import { Component } from '@angular/core';
import { FormBuilder, Validators, AbstractControl, ValidationErrors, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistrationDto, UserDetailsDto, UserLoginDto } from '../../models/user.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  mode: 'login' | 'register' = 'login';
  loading = false;
  errorMessage = '';
  loginForm: FormGroup;
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private us: UserService) {
    this.loginForm = this.fb.nonNullable.group({
    usernameOrEmail: ['', [Validators.required]],
    password: ['', [Validators.required]]
  });

  this.registerForm = this.fb.nonNullable.group({
    username: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).*$/)]],
    confirmPassword: ['', [Validators.required]],
  },
    {validators: this.comparePasswords}
);
  }

  setMode(m: 'login' | 'register') {
    this.mode = m;
    this.errorMessage = '';
  }

  submitLogin() {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    this.errorMessage = '';
    const dto: UserLoginDto = this.loginForm.getRawValue();
    this.us.login(dto).subscribe({
      next: (id: string) => {
        localStorage.setItem('userId', id);
        this.router.navigateByUrl('/products');
      },
      error: (err) => {
        this.errorMessage = 'Login failed. Check your credentials.';
        console.error(err);
      }
    });
  }

  submitRegister() {
    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }
    this.errorMessage = '';
    const dto: RegistrationDto = this.registerForm.getRawValue();
    this.us.register(dto).subscribe({
      next: (_id: string) => {
        this.setMode('login');
      },
      error: (err) => {
        this.errorMessage = 'Registration failed.';
        console.error(err);
      }
    });
  }  

  private comparePasswords = (group: AbstractControl): ValidationErrors | null => {
    const p = group.get('password')?.value;
    const c = group.get('confirmPassword')?.value;
    return p && c && p !== c ? { mismatch: true } : null;
  };
}
