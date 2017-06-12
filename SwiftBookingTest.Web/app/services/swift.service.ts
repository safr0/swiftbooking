///<reference path="../../node_modules/moment/moment.d.ts" />
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import {BookingModel} from '../models/booking';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class SwiftService {
    constructor(private _http: Http) { }

    getSwiftBookings(url: string): Observable<BookingModel[]> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.get(url, options).map((response: Response) =>
                <BookingModel[]>response.json()
            ).do((data) => {
                console.log("getAll: " + JSON.stringify(data))
            })
            .catch(this.handleError);
    }

    saveSwiftBooking(url: string, bookingRequest: any): Observable<any> {        
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(url, JSON.stringify(bookingRequest)
        , options).map((response: Response) =>
            <BookingModel[]>response.json()
            ).do(data => {
                console.log("All: " + JSON.stringify(data))
            })
            .catch(this.handleError);
    }

    deliverSwiftBooking(url: string, deliveryRequest: any): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(url, JSON.stringify(deliveryRequest)
            , options).map((response: Response) =>
                <BookingModel[]>response.json()
            ).do(data => {
                console.log("All: " + JSON.stringify(data))
            })
            .catch(this.handleError);

        //return "yes!!";
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}