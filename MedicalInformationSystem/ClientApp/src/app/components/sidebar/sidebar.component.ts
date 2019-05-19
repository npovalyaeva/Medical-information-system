import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  @Input() id: number;
  photo = '../assets/hospital.png';
  values = [
    {
      id: 1,
      first_name: 'Татьяна',
      last_name: 'Поваляева',
      position: 'Врач-терапевт'
    },
    {
      id: 2,
      first_name: 'Надежда',
      last_name: 'Поваляева',
      position: 'Мед-сестёр'
    },
  ];
  constructor() { }
  user = this.values[0];

  logOut() {
    localStorage.removeItem("jwt");
  }

  ngOnInit() {
    this.user = this.values.find(x => x.id === this.id);
  }

}
