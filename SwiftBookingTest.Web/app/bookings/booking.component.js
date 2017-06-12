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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var global_1 = require("../globals/global");
var swift_service_1 = require("../services/swift.service");
var booking_list_component_1 = require("./booking-list.component");
var BookingComponent = (function () {
    function BookingComponent(_parent, fb, _swiftService) {
        this._parent = _parent;
        this.fb = fb;
        this._swiftService = _swiftService;
    }
    BookingComponent.prototype.ngOnInit = function () {
        this.bookingForm = this.fb.group({
            Name: ['', forms_1.Validators.required],
            Address: ['', forms_1.Validators.required],
            PickupAddress: [''],
            Phone: ['', forms_1.Validators.required]
        });
    };
    BookingComponent.prototype.onsubmit = function (formData) {
    };
    BookingComponent.prototype.saveBooking = function (formData) {
        var _this = this;
        //this._parent.sayHello('hello');
        if (this.validate(formData)) {
            this.errorMessage = "";
            this._swiftService.saveSwiftBooking(global_1.Global.api_swift_save, formData._value).subscribe(function (result) {
                _this._parent.bookings.push(result);
            });
        }
        else {
            this.errorMessage = "validation errors...";
        }
    };
    BookingComponent.prototype.validate = function (formData) {
        return !!formData._value.Name && !!formData._value.Address && !!formData._value.Phone;
    };
    return BookingComponent;
}());
BookingComponent = __decorate([
    core_1.Component({
        selector: 'bm-addbooking',
        templateUrl: 'app/bookings/booking.component.html',
    }),
    __param(0, core_1.Inject(core_1.forwardRef(function () { return booking_list_component_1.BookingListComponent; }))),
    __metadata("design:paramtypes", [booking_list_component_1.BookingListComponent, forms_1.FormBuilder, swift_service_1.SwiftService])
], BookingComponent);
exports.BookingComponent = BookingComponent;
//# sourceMappingURL=booking.component.js.map