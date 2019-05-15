import { Component, OnInit, Input } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

export interface SpecialistInfo {
  id: number;
  is_doctor: boolean;
  first_name: string;
  middle_name: string;
  last_name: string;
  birthday: string;
  education: string;
  diploma_speciality: string;
  position: string;
  admission_date: string;
  wage_rate: number;
  unit: string;
  subunit: string;
  parlour: number;
  qualification: number;
  post_number: number;
}

const ELEMENT_DATA: SpecialistInfo[] = [
  {id: 1, is_doctor: true, first_name: 'Анастасия', middle_name: 'Николаевна', last_name: 'Дайгод', birthday: '06.11.1998', education: 'БГУИР 2016-2019 :(', diploma_speciality: 'Врач-хирург', position: 'хз', admission_date: '01.01.2017', wage_rate: 1, unit: 'никакое', subunit: 'какое-то', parlour: 104, qualification: 1, post_number: 0},
  {id: 2, is_doctor: true, first_name: 'Надежда', middle_name: 'Игоревна', last_name: 'Поваляева', birthday: '07.04.1998', education: 'Белорусский государственный университет информатики и радиоэлектроники 2016-2020', diploma_speciality: 'Врач-хирург', position: 'Мед-сестёр', admission_date: '04.03.2019', wage_rate: 0.5, unit: 'ме', subunit: 'фе', parlour: 209, qualification: 0, post_number: 11},
  {id: 3, is_doctor: false, first_name: 'Игорь', middle_name: 'Дмитриевич', last_name: 'Шиманский', birthday: '06.07.1999', education: 'БГУИР 2016-2020', diploma_speciality: '', position: 'Мед-сестёр 2', admission_date: '02.04.2018', wage_rate: 1.5, unit: 'хм', subunit: 'хмммм', parlour: 108, qualification: 0, post_number: 9},
];


@Component({
  selector: 'app-specialist-profile',
  templateUrl: './specialist-profile.component.html',
  styleUrls: ['./specialist-profile.component.css']
})
export class SpecialistProfileComponent implements OnInit {
  @Input() id: number;
  photo = '../assets/nurse.png';
  emailFormControl = new FormControl('', [
    Validators.email,
  ]);

  constructor() { }

  specialist = ELEMENT_DATA[2];
  ngOnInit() {
    this.specialist = ELEMENT_DATA.find(x => x.id === 2);
  }

}
