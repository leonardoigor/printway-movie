import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { catchError, Observable, of, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class AuthLoginInterceptor implements HttpInterceptor {
  constructor(
    private readonly router: Router,
    private readonly auth: AuthService,
    private readonly snackbar: MatSnackBar
  ) {}
  private handleAuthError(err: HttpErrorResponse): Observable<any> {
    //handle your auth error or rethrow
    if (err.status === 401 || err.status === 403) {
      this.auth.logout();
      this.router.navigateByUrl(`/auth/login`); // if you're using angular router
      // if you've caught / handled the error, you don't want to rethrow it unless you also want downstream consumers to have to handle it as well.
      return of(err.message); // or EMPTY may be appropriate here
    } else {
      const erros = err.error.errors || [];
      for (const key in erros) {
        if (Object.prototype.hasOwnProperty.call(erros, key)) {
          const element = erros[key];
          this.snackbar.open(element, 'Close');
        }
      }
    }
    return throwError(err);
  }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Clone the request to add the new header.
    const { token } = this.auth;

    const authReq = req.clone({
      headers: req.headers.set(
        'Authorization',
        'Bearer ' + token?.tokenString || ''
      ),
    });
    // catch the error, make specific functions for catching specific errors and you can chain through them with more catch operators
    return next
      .handle(authReq)
      .pipe(catchError((x) => this.handleAuthError(x))); //here use an arrow function, otherwise you may get "Cannot read property 'navigate' of undefined" on angular 4.4.2/net core 2/webpack 2.70
  }
}
