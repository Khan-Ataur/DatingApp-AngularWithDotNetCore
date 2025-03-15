import { Component, input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  usersFromHomeComponent= input.required<any>(); 
  // here getting data from home.component.ts as --> home(parent) is using register(child) components; there is a child parent relationship between two components
  model:any={}

  register(){
    console.log(this.model);
  }

  cancel()
  {
    console.log('Cancelled');
  }


}
