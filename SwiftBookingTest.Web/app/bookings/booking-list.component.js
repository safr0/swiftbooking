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
var core_1 = require("@angular/core");
var swift_service_1 = require("../services/swift.service");
var global_1 = require("../globals/global");
var BookingListComponent = (function () {
    function BookingListComponent(_swiftService) {
        this._swiftService = _swiftService;
        this.deliveryResult = "";
        this.pageTitle = 'Booking Management';
        this.bookings = [];
    }
    BookingListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._swiftService.getSwiftBookings(global_1.Global.api_swift_getbookings).subscribe(function (result) {
            _this.bookings = result.Data;
        });
    };
    BookingListComponent.prototype.swiftDelivery = function (deliveryRequest) {
        var _this = this;
        this._swiftService.deliverSwiftBooking(global_1.Global.api_swift_delivery, deliveryRequest).subscribe(function (result) {
            _this.deliveryResult += result;
        });
    };
    ;
    return BookingListComponent;
}());
BookingListComponent = __decorate([
    core_1.Component({
        selector: 'bm-bookings',
        templateUrl: 'app/bookings/booking-list.component.html'
    }),
    __metadata("design:paramtypes", [swift_service_1.SwiftService])
], BookingListComponent);
exports.BookingListComponent = BookingListComponent;
//# sourceMappingURL=booking-list.component.js.map