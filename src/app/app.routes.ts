import { Routes } from '@angular/router';

import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { TeamRegistrationComponent } from './team-registration/team-registration.component';
import { ProfileFormComponent } from './profile-form/profile-form.component';
import { AboutComponent } from './about/about.component';

import { InvoiceComponent } from './invoice/invoice.component';
import { NewsComponent } from './news/news.component';

import { TournmentComponent } from './tournment/tournment.component';
import { CommunityComponent } from './community/community.component';
import { SessionListComponent } from './training/session-list/session-list.component';
import { SessionDetailsComponent } from './training/session-details/session-details.component';
import { ProfileComponent } from './auth/profile/profile.component';
import { LoginComponent } from './auth/login/login.component';
import { DashboardComponent } from '../dashboard/Member/dashboard.component';
import { AdminDashboardComponent } from '../dashboard/admin-dashboard/admin-dashboard.component';


export const routes: Routes = [

  {path:'', redirectTo: '/home', pathMatch: 'full' }, // Default route
  {path:'home', component: HomeComponent },
  {path:'team', component: TeamRegistrationComponent }, // Non-lazy route
  {path:'profile', component: ProfileComponent },
  {path:'login',component:LoginComponent},
  {path:'about',component:AboutComponent},
  {path:'news',component:NewsComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:'admin',component:AdminDashboardComponent},
  {path:'invoice',component:InvoiceComponent},
  
  {path:'tournments',component:TournmentComponent},
  {path:'community',component:CommunityComponent},
  {path:'sessionList',component:SessionListComponent},
  {path:'sessionDetail',component:SessionDetailsComponent}



];
