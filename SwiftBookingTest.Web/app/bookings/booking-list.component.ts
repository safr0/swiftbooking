import {Component,OnInit} from "@angular/core";
import {BookingModel} from '../models/booking';
import { SwiftService } from '../services/swift.service';
import { Global } from '../globals/global';

@Component({
    selector: 'bm-bookings',
    templateUrl: 'app/bookings/booking-list.component.html'
})

export class BookingListComponent {
    deliveryResult: string = "";
    pageTitle: string = 'Booking Management';
    bookings: BookingModel[] = []; 

    constructor(private _swiftService: SwiftService) { }

    ngOnInit(): void {        

        this._swiftService.getSwiftBookings(Global.api_swift_getbookings).subscribe((result:any) => {            
            this.bookings = result.Data;                        
        }); 
    }

    swiftDelivery(deliveryRequest: any): void {        
        this._swiftService.deliverSwiftBooking(Global.api_swift_delivery, deliveryRequest).subscribe((result) => {
            this.deliveryResult += result;
        });        
    };
}
