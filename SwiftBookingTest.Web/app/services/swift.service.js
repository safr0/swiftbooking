"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
///<reference path="../../node_modules/moment/moment.d.ts" />
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
var SwiftService = (function () {
    function SwiftService(_http) {
        this._http = _http;
    }
    SwiftService.prototype.getSwiftBookings = function (url) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.get(url, options).map(function (response) {
            return response.json();
        }).do(function (data) {
            console.log("getAll: " + JSON.stringify(data));
        })
            .catch(this.handleError);
    };
    SwiftService.prototype.saveSwiftBooking = function (url, bookingRequest) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(url, JSON.stringify(bookingRequest), options).map(function (response) {
            return response.json();
        }).do(function (data) {
            console.log("All: " + JSON.stringify(data));
        })
            .catch(this.handleError);
    };
    SwiftService.prototype.deliverSwiftBooking = function (url, deliveryRequest) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(url, JSON.stringify(deliveryRequest), options).map(function (response) {
            return response.json();
        }).do(function (data) {
            console.log("All: " + JSON.stringify(data));
        })
            .catch(this.handleError);
        //return "yes!!";
    };
    SwiftService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    return SwiftService;
}());
SwiftService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], SwiftService);
exports.SwiftService = SwiftService;
//# sourceMappingURL=swift.service.js.map