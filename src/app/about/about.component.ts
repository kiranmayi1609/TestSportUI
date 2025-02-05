import { Component } from '@angular/core';
import { trigger, transition, style, animate, keyframes } from '@angular/animations';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.css',
  animations:[
    trigger('shuttleSplitLeft', [
      transition(':enter', [
        animate('1200ms ease-in-out', keyframes([
          style({ transform: 'translateX(-100%)', offset: 0 }),
          style({ transform: 'translateX(10%)', offset: 0.7 }),
          style({ transform: 'translateX(0)', offset: 1 })
        ]))
      ])
    ]),
    trigger('shuttleSplitRight', [
      transition(':enter', [
        animate('1200ms ease-in-out', keyframes([
          style({ transform: 'translateX(100%)', offset: 0 }),
          style({ transform: 'translateX(-10%)', offset: 0.7 }),
          style({ transform: 'translateX(0)', offset: 1 })
        ]))
      ])
    ])
  ]
})

export class AboutComponent {

}
