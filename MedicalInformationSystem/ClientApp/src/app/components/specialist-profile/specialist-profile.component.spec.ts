import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialistProfileComponent } from './specialist-profile.component';

describe('SpecialistProfileComponent', () => {
  let component: SpecialistProfileComponent;
  let fixture: ComponentFixture<SpecialistProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialistProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialistProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
