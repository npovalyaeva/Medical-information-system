import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  photo = '../assets/authorize_img.png';
  show: boolean;
  iconName = 'visibility';
  invalidLogin: boolean;

  constructor(private router: Router, private http: HttpClient) {
    this.show = false;
  }
  password() {
    this.show = !this.show;
    this.iconName = this.show ? 'visibility_off' : 'visibility'
  }

  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);
    this.http.post("http://localhost:3000/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

  ngOnInit() {
  }
}
