import { Component } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'; // Import MatIconModule
import { ReactiveFormsModule } from '@angular/forms';
import { last } from 'rxjs';
import { NavbarComponent } from "../navbar/navbar.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile-form',
  standalone: true,
  imports: [MatFormFieldModule, // Angular Material modules
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,CommonModule],
  templateUrl: './profile-form.component.html',
  styleUrl: './profile-form.component.css'
})
export class ProfileFormComponent {
  profileForm:FormGroup;
  hidePassword=true;
  captchaResolved=false;

  constructor(private fb:FormBuilder){
    this.profileForm=this.fb.group({
      email:['',[Validators.required,Validators.email]],
      confirmEmail:['',[Validators.required,Validators.email]],
      password:['',[Validators.required,Validators.minLength(6)]],
      confirmPassword:['',[Validators.required]],
      newsletter:[false],
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      address:[''],
      dateOfBirth:[''],
      mobile: ['', [Validators.pattern(/^\d{8}$/)]],
      extraEmail1: [''],
      extraEmail2: [''],
      gender: ['female', Validators.required],
      terms: [false, Validators.requiredTrue],
      privacyPolicy: [false, Validators.requiredTrue],
    });
  }


  togglePasswordVisibility(){
    this.hidePassword=!this.hidePassword;
  }
  onSubmit() {
    if (this.profileForm.valid) {
      console.log('Form Submitted', this.profileForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

  resetForm(){
    this.profileForm.reset();
  }
  closeForm() {
    console.log('Form closed');
    // Optional: Reset the form or hide the form container
    this.profileForm.reset();
  }
  onCaptchaResolved(captchaResponse:string)
  {
    console.log('Captcha Resolved :',captchaResponse);
    this.captchaResolved=true;
  }
}
