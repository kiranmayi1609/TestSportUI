import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-session-details',
  standalone: true,
  imports: [],
  templateUrl: './session-details.component.html',
  styleUrl: './session-details.component.css'
})
export class SessionDetailsComponent implements OnInit {
session: any;
allSessions=[
  {
    id: 1,
    title: 'Fredags morgenfjer - Januar og Februar',
    participants: '7/12',
    ageGroup: '14-99',
    price: 150.00,
    instructor: 'Philip Stack',
    description: 'Tilmeld dig vores åbne morgentræning hver fredag morgen fra <strong>06:30-07:30</strong>.',
    imageUrl: 'https://via.placeholder.com/150'

  },
  {
    id: 2,
    title: 'Basis Barn - Mandag',
    participants: '23/27',
    ageGroup: '8-11',
    price: 500.00,
    instructor: 'Thor Percy Hinge Pedersen',
    description: 'Dette er tilmelding til Basis Barn - Mandag.',
    imageUrl: 'https://via.placeholder.com/150'
  }
];

constructor(private route: ActivatedRoute, private router: Router) {}

      ngOnInit() {
         const sessionId = this.route.snapshot.paramMap.get('id');
         //CONVERT SESSIONiD TO A NUMBER FOR COMPARISION 
         if(sessionId) {
          this.session = this.allSessions.find(S=>S.id===+sessionId);
         }
         
        }
 goBack(){
  this.router.navigate(['/']);
 }

}
