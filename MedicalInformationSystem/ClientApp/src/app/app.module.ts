import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import {
  MatIconModule,
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatSidenavModule,
  MatToolbarModule,
  MatListModule,
  MatCardModule,
  MatDividerModule,
  MatTableModule,
  MatButtonToggleModule,
} from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { SpecialistProfileComponent } from './components/specialist-profile/specialist-profile.component';
import { SignInLayoutComponent } from './layouts/sign-in-layout/sign-in-layout.component';
import { HomeLayoutComponent } from './layouts/home-layout/home-layout.component';
import { MedicalRecordsComponent } from './components/medical-records/medical-records.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'sign-in', pathMatch: 'full'},
  { path: 'sign-in', component: SignInLayoutComponent,
    children: [
      {path: '', component: SignInComponent}
    ]
  },
  { path: 'main', component: HomeLayoutComponent,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },
      { path: 'profile', component: SpecialistProfileComponent },
      { path: 'records', component: MedicalRecordsComponent },
    ]
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    PageNotFoundComponent,
    SidebarComponent,
    SpecialistProfileComponent,
    SignInLayoutComponent,
    HomeLayoutComponent,
    MedicalRecordsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatCardModule,
    MatDividerModule,
    MatTableModule,
    MatButtonToggleModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
