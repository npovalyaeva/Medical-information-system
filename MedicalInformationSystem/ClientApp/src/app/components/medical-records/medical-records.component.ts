import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import {Record} from '../record';

export interface MedicalRecordInfoForArchieve {
  record_id: number;
  first_name: string;
  last_name: string;
  patient_id: number;
  icd10: string;
  year: number;
  charge_date: string;
  discharge_date: string;
}

// const CURRENT_DATA: Record[] = [
//   {record_id: 1, first_name: 'Анастасия', last_name: 'Дайгод', patient_id: 1012, icd10: 'E50.0', year: 2019, charge_date: '01.01.2019'},
//   {record_id: 2, first_name: 'Надежда', last_name: 'Поваляева', patient_id: 3409, icd10: 'E60.0', year: 2019, charge_date: '01.04.2019'},
//   {record_id: 2, first_name: 'Игорь', last_name: 'Шиманский', patient_id: 3029, icd10: 'E70.0', year: 2019, charge_date: '29.02.2019'},
//   {record_id: 2, first_name: 'Надежда', last_name: 'Поваляева', patient_id: 3409, icd10: 'E60.0', year: 2019, charge_date: '01.04.2019'},
//   {record_id: 2, first_name: 'Игорь', last_name: 'Шиманский', patient_id: 3029, icd10: 'E70.0', year: 2019, charge_date: '29.02.2019'},
//   {record_id: 1, first_name: 'Анастасия', last_name: 'Дайгод', patient_id: 1012, icd10: 'E50.0', year: 2019, charge_date: '01.01.2019'},
//   {record_id: 2, first_name: 'Надежда', last_name: 'Поваляева', patient_id: 3409, icd10: 'E60.0', year: 2019, charge_date: '01.04.2019'},
// ];

const ARCHIEVE_DATA: MedicalRecordInfoForArchieve[] = [
  {record_id: 1, first_name: 'Анастасия', last_name: 'Дайгод', patient_id: 1012, icd10: 'E50.0', year: 2019, charge_date: '01.01.2019', discharge_date: '02.01.2019'},
  {record_id: 2, first_name: 'Надежда', last_name: 'Поваляева', patient_id: 3409, icd10: 'E60.0', year: 2019, charge_date: '01.04.2019', discharge_date: '06.04.2019'},
  {record_id: 2, first_name: 'Игорь', last_name: 'Шиманский', patient_id: 3029, icd10: 'E70.0', year: 2019, charge_date: '29.02.2019', discharge_date: '31.02.2019'},
];


@Component({
  selector: 'app-medical-records',
  templateUrl: './medical-records.component.html',
  styleUrls: ['./medical-records.component.css'],
  providers: [ApiService]
})
export class MedicalRecordsComponent implements OnInit {

  displayedColumnsForArchive: string[] = ['year/record', 'name', 'charge_date', 'discharge_date', 'icd10'];
  displayedColumnsForCurrent: string[] = ['year/record', 'name', 'charge_date', 'icd10'];
  currentDataSource: Record[] = [];
  archieveDataSource = ARCHIEVE_DATA;
  isLoadingResults = true;

  constructor(private api: ApiService) { }

  ngOnInit() {
    console.log('before ' + this.currentDataSource);
    this.api.getRecords()
    .subscribe((res: Record[]) => {
      this.currentDataSource = res;
      console.log(this.currentDataSource);
      this.isLoadingResults = false;
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
    });
  }

}
