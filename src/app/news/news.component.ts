import { Component } from '@angular/core';
import { BadmintonApiService } from '../api_services/badminton-api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-news',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent {

  newList: any[] = [];  // Store fetched news data

  constructor(private badmintonService: BadmintonApiService) {}  // Inject the service

  ngOnInit(): void {
    this.getNews();  // Fetch data when the component initializes
  }

  getNews(): void {
    this.badmintonService.getCountries().subscribe(
      (response) => {
        console.log(response);  // Debugging
        this.newList = response;  // Store the response data
      },
      (error) => {
        console.error('Error fetching news:', error);
      }
    );
  }

}
