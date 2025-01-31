import { Component } from '@angular/core';


import { Router, RouterLink,RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  navigateTo(route:string){
    this.router.navigate(['/training']);
  }
  
  navigateToTeams() {
    this.router.navigate(['/team']);
  }
 
  

  backgroundImageUrl:string;



  constructor(private router:Router) {
    //Set the background image URL dynamically 
    this.backgroundImageUrl='https://assets.isu.pub/document-structure/231003115040-c415e10448fcaf2c3498d200b5d31b0d/v1/54152267c6f2994e02779bcf605d1d09.jpeg'

   
  }

}
