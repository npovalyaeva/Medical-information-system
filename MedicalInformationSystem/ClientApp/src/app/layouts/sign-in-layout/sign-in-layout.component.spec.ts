import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SignInLayoutComponent } from './sign-in-layout.component';

describe('SignInLayoutComponent', () => {
  let component: SignInLayoutComponent;
  let fixture: ComponentFixture<SignInLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SignInLayoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SignInLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
