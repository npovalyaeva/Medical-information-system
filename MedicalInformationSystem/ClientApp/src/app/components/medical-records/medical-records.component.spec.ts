import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalRecordsComponent } from './medical-records.component';

describe('MedicalRecordsComponent', () => {
  let component: MedicalRecordsComponent;
  let fixture: ComponentFixture<MedicalRecordsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MedicalRecordsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicalRecordsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
