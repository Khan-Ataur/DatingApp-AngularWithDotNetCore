import { Component, input, output } from '@angular/core';
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
  
  cancelRegister = output<boolean>(); // now passing Child(register) to parent(Home) value when user press Cancel button
  
  model:any={}

  register(){
    console.log(this.model);
  }

  cancel()
  {
    this.cancelRegister.emit(false);
  }


}
