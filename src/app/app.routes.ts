import { Routes } from '@angular/router';

import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { TeamRegistrationComponent } from './team-registration/team-registration.component';
import { ProfileFormComponent } from './profile-form/profile-form.component';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { NewsComponent } from './news/news.component';
import { TrainingComponent } from './training/training.component';
import { TournmentComponent } from './tournment/tournment.component';
import { CommunityComponent } from './community/community.component';
import { SessionListComponent } from './session-list/session-list.component';
import { SessionDetailsComponent } from './session-details/session-details.component';

export const routes: Routes = [

  {path:'', redirectTo: '/home', pathMatch: 'full' }, // Default route
  {path:'home', component: HomeComponent },
  {path:'team', component: TeamRegistrationComponent }, // Non-lazy route
  {path:'profile', component: ProfileComponent },
  {path:'login',component:LoginComponent},
  {path:'about',component:AboutComponent},
  {path:'news',component:NewsComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:'invoice',component:InvoiceComponent},
  {path:'training',component:TrainingComponent},
  {path:'tournments',component:TournmentComponent},
  {path:'community',component:CommunityComponent},
  {path:'sessionList',component:SessionListComponent},
  {path:'sessionDetail',component:SessionDetailsComponent}



];
