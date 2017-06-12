import { Component } from "@angular/core";

@Component({
    selector: 'swiftbooking-app', 
    template: `<div class="container">
              <h3>{{name}}</h3>
              <bm-bookings></bm-bookings> 
              </div>
              `
})

export class AppComponent{ name= 'GetSwift Code Test'}