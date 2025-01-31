import { Component,NgModule } from '@angular/core';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-team-registration',
  standalone: true,
  imports: [MatIcon],
  templateUrl: './team-registration.component.html',
  styleUrl: './team-registration.component.css'
})
export class TeamRegistrationComponent {
  searchQuery:string='';

  classes=[{
    name:'Basis Barn -Mandag',
    registered:19,

  }]

}
