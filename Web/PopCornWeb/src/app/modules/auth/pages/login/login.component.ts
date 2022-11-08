import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  hide: boolean = true;
  form: FormGroup;

  constructor(
    private readonly service: AuthService,
    private readonly formBuilder: FormBuilder,
    private readonly router: Router
  ) {
    this.form = this.formBuilder.group({
      password: ['', [Validators.required, Validators.maxLength(255)]],
      email: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    if (this.service.token) {
      this.router.navigate(['/home']);
    }
  }
  submitForm() {
    const data = this.form.value;
    this.service.login(data.email, data.password).subscribe((response) => {
      response.data.token.email = data.email;
      this.service.storeUserToken(response.data.token);
      this.router.navigate(['/home']);
    });
  }
}
