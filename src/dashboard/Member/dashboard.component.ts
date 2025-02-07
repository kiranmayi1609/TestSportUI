import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  user={
    name:'',
    email:'',
    phone:'',
    memershipStatus:'Active',
    validUntil:'',
    paymentHistory:[
      {
        date:'',amount:'',status:''
      },
      {
        date:'',amount:'',status:''
      },

    ]

  };
  userName=this.user.name;
  editProfile(){
    alert('Redirecting to edit Profile page');

  }
  renewMembership(){
    alert('Redirecting to Renew Membership Page');
  }

}
