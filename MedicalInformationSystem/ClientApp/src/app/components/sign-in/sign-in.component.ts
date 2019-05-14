import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  photo = '../assets/authorize_img.png';
  show: boolean;
  iconName = 'visibility';

  constructor() {
    this.show = false;
  }
  password() {
    this.show = !this.show;
    this.iconName = this.show ? 'visibility_off' : 'visibility'
  }

  ngOnInit() {
  }
}
