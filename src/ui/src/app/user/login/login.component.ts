import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

import { Observable } from 'rxjs';
import { WolfDenService } from '../../service/wolf-den.service';
import { ILoginForm } from './ilogin-form';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  userForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private userService: WolfDenService) {
    this.userForm = this.fb.group<ILoginForm>({
      email: new FormControl(
        '',
        [Validators.required, ]
      ),
      password: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    }
  }


