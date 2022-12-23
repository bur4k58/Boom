"use strict";
(self["webpackChunkapp"] = self["webpackChunkapp"] || []).push([["src_app_qrcode_qrcode_module_ts"],{

/***/ 8717:
/*!*************************************************!*\
  !*** ./src/app/qrcode/qrcode-routing.module.ts ***!
  \*************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "QrcodePageRoutingModule": () => (/* binding */ QrcodePageRoutingModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _qrcode_page__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./qrcode.page */ 6559);




const routes = [
    {
        path: '',
        component: _qrcode_page__WEBPACK_IMPORTED_MODULE_0__.QrcodePage
    }
];
let QrcodePageRoutingModule = class QrcodePageRoutingModule {
};
QrcodePageRoutingModule = (0,tslib__WEBPACK_IMPORTED_MODULE_1__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.NgModule)({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule.forChild(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule],
    })
], QrcodePageRoutingModule);



/***/ }),

/***/ 7076:
/*!*****************************************!*\
  !*** ./src/app/qrcode/qrcode.module.ts ***!
  \*****************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "QrcodePageModule": () => (/* binding */ QrcodePageModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);
/* harmony import */ var _ionic_angular__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @ionic/angular */ 3819);
/* harmony import */ var _qrcode_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./qrcode-routing.module */ 8717);
/* harmony import */ var _qrcode_page__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./qrcode.page */ 6559);







let QrcodePageModule = class QrcodePageModule {
};
QrcodePageModule = (0,tslib__WEBPACK_IMPORTED_MODULE_2__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.NgModule)({
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_4__.CommonModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormsModule,
            _ionic_angular__WEBPACK_IMPORTED_MODULE_6__.IonicModule,
            _qrcode_routing_module__WEBPACK_IMPORTED_MODULE_0__.QrcodePageRoutingModule
        ],
        declarations: [_qrcode_page__WEBPACK_IMPORTED_MODULE_1__.QrcodePage]
    })
], QrcodePageModule);



/***/ }),

/***/ 6559:
/*!***************************************!*\
  !*** ./src/app/qrcode/qrcode.page.ts ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "QrcodePage": () => (/* binding */ QrcodePage)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _qrcode_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./qrcode.page.html?ngResource */ 9767);
/* harmony import */ var _qrcode_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./qrcode.page.scss?ngResource */ 6291);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _ionic_native_barcode_scanner_ngx__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @ionic-native/barcode-scanner/ngx */ 5684);





let QrcodePage = class QrcodePage {
    constructor(scanner) {
        this.scanner = scanner;
        this.encodText = '';
        this.encodeData = {};
        this.scannedData = {};
    }
    ngOnInit() {
    }
    scan() {
        this.options = {
            prompt: 'Scan you barcode'
        };
        this.scanner.scan().then((data) => {
            this.scannedData = data;
        }, (err) => {
            console.log('Error:', err);
        });
    }
};
QrcodePage.ctorParameters = () => [
    { type: _ionic_native_barcode_scanner_ngx__WEBPACK_IMPORTED_MODULE_2__.BarcodeScanner }
];
QrcodePage = (0,tslib__WEBPACK_IMPORTED_MODULE_3__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_4__.Component)({
        selector: 'app-qrcode',
        template: _qrcode_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__,
        styles: [_qrcode_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__]
    })
], QrcodePage);



/***/ }),

/***/ 6291:
/*!****************************************************!*\
  !*** ./src/app/qrcode/qrcode.page.scss?ngResource ***!
  \****************************************************/
/***/ ((module) => {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJxcmNvZGUucGFnZS5zY3NzIn0= */";

/***/ }),

/***/ 9767:
/*!****************************************************!*\
  !*** ./src/app/qrcode/qrcode.page.html?ngResource ***!
  \****************************************************/
/***/ ((module) => {

module.exports = "<ion-header>\n  <ion-toolbar>\n    <ion-buttons slot=\"start\">\n      <ion-back-button></ion-back-button>\n    </ion-buttons>\n    <ion-title>qrcode</ion-title>\n  </ion-toolbar>\n</ion-header>\n\n<ion-content>\n\n  <div>\n    <div *ngIf=\"scannedData.text\">\n      <label>Your barcode is</label>\n      <br>\n      <span>{{scannedData.text}}</span>\n    </div>\n      <ion-button style=\"position: fixed;\n      left: 0;\n      bottom: 10px;\n      right: 0;\n      width: 100%;\" (click)=\"scan()\" >Scan QR code</ion-button>\n    </div>\n</ion-content>\n";

/***/ })

}]);
//# sourceMappingURL=src_app_qrcode_qrcode_module_ts.js.map