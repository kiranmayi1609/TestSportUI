import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from "../navbar/navbar.component";
import { ViewChild,AfterViewInit } from '@angular/core';
import { appConfig } from '../app.config';
import { FooterComponent } from '../footer/footer.component';
import { Router, RouterLink,RouterOutlet } from '@angular/router';

declare var bootstrap:any;
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NavbarComponent,FooterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent  {

   constructor(private router:Router) { }
 
  
  navigateTo(route: string) {
    this.router.navigate([`/{training}`]);  // Navigate to the selected page
  }

  
  

}
