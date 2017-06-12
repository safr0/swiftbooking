import { Component, OnInit, ViewChild, Inject, forwardRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { Observable } from 'rxjs/Rx';
import {BookingModel} from '../models/booking';
import { Global } from '../globals/global';
import { SwiftService } from '../services/swift.service';
import { BookingListComponent } from './booking-list.component';


@Component({
    selector: 'bm-addbooking',
    templateUrl: 'app/bookings/booking.component.html',
})
export class BookingComponent {

    bookingForm: FormGroup;
    swiftResultData: any[];   
    errorMessage: string;
    constructor(@Inject(forwardRef(() => BookingListComponent)) private _parent: BookingListComponent, private fb: FormBuilder, private _swiftService: SwiftService) { }
    ngOnInit(): void {
        this.bookingForm = this.fb.group({
            Name: ['', Validators.required],
            Address: ['', Validators.required],
            PickupAddress: [''],
            Phone: ['', Validators.required]
        });
    }
    onsubmit(formData: any): void {
    }
    saveBooking(formData: any): void {
        //this._parent.sayHello('hello');
        if (this.validate(formData)) {            
            this.errorMessage = "";

            this._swiftService.saveSwiftBooking(Global.api_swift_save, formData._value).subscribe((result) => {                                
                this._parent.bookings.push(result);                
            });
            
        } else {
            this.errorMessage = "validation errors...";
        }
    }
    validate(formData: any): boolean {
        return !!formData._value.Name && !!formData._value.Address && !!formData._value.Phone;
    }
}