import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-session-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './session-list.component.html',
  styleUrl: './session-list.component.css'
})
export class SessionListComponent implements OnInit{
 searchQuery:string='';
  // Start with all sessions
  sessions=[{
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

  }];

  filteredSessions = [...this.sessions];
  constructor(private router: Router) {}

  ngOnInit(): void {
    
  }
  viewDetails(sessionId: number) {
    this.router.navigate(['/session', sessionId]);
  }



   // Search sessions based on title or description
   searchSessions(query: string): void {
    if (!query) {
      this.filteredSessions = [...this.sessions];
    } else {
      this.filteredSessions = this.sessions.filter(session =>
        session.title.toLowerCase().includes(query.toLowerCase()) ||
        session.description.toLowerCase().includes(query.toLowerCase())
      );
    }
  }

  // Apply filters (based on categories)
  applyFilter(filterType: string): void {
    switch (filterType) {
      case 'all':
        this.filteredSessions = [...this.sessions];
        break;
      case 'group':
        this.filteredSessions = this.sessions.filter(session => session.ageGroup === '8-11'); // Example filter by group
        break;
      case 'status':
        this.filteredSessions = this.sessions.filter(session => parseInt(session.participants.split('/')[0]) < parseInt(session.participants.split('/')[1])); // Check available spots
        break;
      case 'time':
        // You can filter by time if you have a time field in the sessions.
        break;
     
      default:
        this.filteredSessions = [...this.sessions];
        break;
    }
  }

}
