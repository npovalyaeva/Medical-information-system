import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth-guard.service';
import { JwtHelperService } from '@auth0/angular-jwt';
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
  MatProgressSpinnerModule,
  MatTooltipModule,
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
import { MedicalHistoryComponent } from './components/medical-history/medical-history.component';


const appRoutes: Routes = [
  { path: '', redirectTo: 'sign-in', pathMatch: 'full'},
  { path: 'sign-in', component: SignInLayoutComponent,
    children: [
      {path: '', component: SignInComponent}
    ]
  },
  { path: 'main', component: HomeLayoutComponent, canActivate: [AuthGuard], 
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },
      { path: 'profile', component: SpecialistProfileComponent },
      { path: 'records', component: MedicalRecordsComponent },
      { path: 'records/:id', component: MedicalHistoryComponent },
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
    MedicalHistoryComponent,
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
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  providers: [JwtHelperService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
