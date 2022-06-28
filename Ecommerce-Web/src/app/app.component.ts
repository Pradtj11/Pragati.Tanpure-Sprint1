import { Component, Input, InputDecorator } from '@angular/core';
import { AuthService } from './services/auth.service';
import { CartService } from './services/cart.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ecommerce-web';
  public totalItem : number = 0;
  constructor(private _auth:AuthService,private cartservice:CartService){ }

  ngOnInit(): void {
    this.cartservice.getProducts()
    .subscribe((res: string | any[])=>{
      this.totalItem = res.length;
    })
  }
  
  LoggedIn(input:boolean){
    if(input){
      return this._auth.loggedIn();
    }
    else{
      return !this._auth.loggedIn();
    }
  }
  LogOut(){
    this._auth.logoutUser();
  }
}


function IsAdmin(Input: InputDecorator, boolean: any) {
  throw new Error('Function not implemented.');
}
