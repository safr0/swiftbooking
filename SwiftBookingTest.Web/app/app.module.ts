import {NgModule} from "@angular/core"
import { APP_BASE_HREF } from "@angular/common";
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent }  from './app.component';
import { HttpModule } from '@angular/http';
import { BookingListComponent } from './bookings/booking-list.component';
import {BookingComponent} from './bookings/booking.component';
import { SwiftService } from './services/swift.service';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule ], 
    declarations: [AppComponent,BookingListComponent,BookingComponent], 
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, SwiftService ],
    exports: [AppComponent],
    bootstrap: [AppComponent],    
})

export class AppModule{}