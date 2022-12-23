"use strict";
(self["webpackChunkapp"] = self["webpackChunkapp"] || []).push([["src_app_choice-page_choice-page_module_ts"],{

/***/ 9016:
/*!***********************************************************!*\
  !*** ./src/app/choice-page/choice-page-routing.module.ts ***!
  \***********************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ChoicePagePageRoutingModule": () => (/* binding */ ChoicePagePageRoutingModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _choice_page_page__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./choice-page.page */ 1819);




const routes = [
    {
        path: '',
        component: _choice_page_page__WEBPACK_IMPORTED_MODULE_0__.ChoicePagePage
    },
];
let ChoicePagePageRoutingModule = class ChoicePagePageRoutingModule {
};
ChoicePagePageRoutingModule = (0,tslib__WEBPACK_IMPORTED_MODULE_1__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.NgModule)({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule.forChild(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule],
    })
], ChoicePagePageRoutingModule);



/***/ }),

/***/ 7056:
/*!***************************************************!*\
  !*** ./src/app/choice-page/choice-page.module.ts ***!
  \***************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ChoicePagePageModule": () => (/* binding */ ChoicePagePageModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);
/* harmony import */ var _ionic_angular__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @ionic/angular */ 3819);
/* harmony import */ var _choice_page_routing_module__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./choice-page-routing.module */ 9016);
/* harmony import */ var _choice_page_page__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./choice-page.page */ 1819);







let ChoicePagePageModule = class ChoicePagePageModule {
};
ChoicePagePageModule = (0,tslib__WEBPACK_IMPORTED_MODULE_2__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.NgModule)({
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_4__.CommonModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormsModule,
            _ionic_angular__WEBPACK_IMPORTED_MODULE_6__.IonicModule,
            _choice_page_routing_module__WEBPACK_IMPORTED_MODULE_0__.ChoicePagePageRoutingModule
        ],
        declarations: [_choice_page_page__WEBPACK_IMPORTED_MODULE_1__.ChoicePagePage]
    })
], ChoicePagePageModule);



/***/ }),

/***/ 1819:
/*!*************************************************!*\
  !*** ./src/app/choice-page/choice-page.page.ts ***!
  \*************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "ChoicePagePage": () => (/* binding */ ChoicePagePage)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _choice_page_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./choice-page.page.html?ngResource */ 6829);
/* harmony import */ var _choice_page_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./choice-page.page.scss?ngResource */ 3069);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _auth0_auth0_angular__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @auth0/auth0-angular */ 6437);
/* harmony import */ var _shared_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shared.service */ 7482);
/* harmony import */ var _guards_auth_guard__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../guards/auth.guard */ 5107);









let ChoicePagePage = class ChoicePagePage {
    constructor(source, service, auth, doc, router, activatedRoute) {
        this.source = source;
        this.service = service;
        this.auth = auth;
        this.doc = doc;
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.id = '';
        this.query = '';
        this.currentDate = new Date();
    }
    dataUser() {
        let stringg = this.profileJson.slice(7, -1);
        this.service.getUser(stringg).subscribe(data => {
            console.log(data);
            data.forEach(function (value) {
                value.schedules.forEach(function (values) {
                    values.date = (0,_angular_common__WEBPACK_IMPORTED_MODULE_4__.formatDate)(values.date, 'yyyy-MM-dd hh:mm', 'en-US');
                });
            });
            this.liveData = data;
            console.log("jdedjk");
            console.log(data);
            console.log(stringg);
        });
    }
    dataNow() {
        let stringg = this.profileJson.slice(7, -1);
        this.service.getUserToday(stringg).subscribe(data => {
            data.forEach(function (value) {
                value.schedules.forEach(function (values) {
                    values.date = (0,_angular_common__WEBPACK_IMPORTED_MODULE_4__.formatDate)(values.date, 'YYYY-MM-dd hh:mm', 'en-UK');
                    return values;
                });
            });
            this.liveData = data;
            console.log(data);
            console.log("jdedjk");
        });
    }
    authUser() {
        this.auth.user$.subscribe((profile) => (this.profileJson) = JSON.stringify(profile.sub, null, 2));
    }
    ngOnInit() {
        this.auth.user$.subscribe((profile) => (this.profileJson) = JSON.stringify(profile.sub, null, 2));
        this.jsonTest = this.currentDate;
        this.jsonTest = (0,_angular_common__WEBPACK_IMPORTED_MODULE_4__.formatDate)(this.jsonTest, 'yyyy-MM-dd', 'en-US');
        console.log(typeof this.jsonTest);
        console.log(this.profileJson);
    }
    transform(value, ...args) {
        return Object.keys(value);
    }
    logout() {
        this.auth.logout({ returnTo: this.doc.location.origin });
        localStorage.removeItem('loggedIn');
    }
    changeStatus(id) {
        console.log(this.dataSource.Schedule[id]);
        if (status = "stop") {
        }
        else {
        }
    }
};
ChoicePagePage.ctorParameters = () => [
    { type: _guards_auth_guard__WEBPACK_IMPORTED_MODULE_3__.AuthGuard },
    { type: _shared_service__WEBPACK_IMPORTED_MODULE_2__.SharedService },
    { type: _auth0_auth0_angular__WEBPACK_IMPORTED_MODULE_5__.AuthService },
    { type: Document, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_6__.Inject, args: [_angular_common__WEBPACK_IMPORTED_MODULE_4__.DOCUMENT,] }] },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.Router },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.ActivatedRoute }
];
ChoicePagePage = (0,tslib__WEBPACK_IMPORTED_MODULE_8__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Injectable)({
        providedIn: 'any'
    }),
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Component)({
        selector: 'app-choice-page',
        template: _choice_page_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__,
        styles: [_choice_page_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__]
    }),
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_6__.Pipe)({
        name: 'keys',
    })
], ChoicePagePage);



/***/ }),

/***/ 3069:
/*!**************************************************************!*\
  !*** ./src/app/choice-page/choice-page.page.scss?ngResource ***!
  \**************************************************************/
/***/ ((module) => {

module.exports = ".container-login100 {\n  width: 100%;\n  min-height: 100vh;\n  display: flex;\n  flex-wrap: wrap;\n  justify-content: center;\n  align-items: center;\n  padding: 15px;\n  background-repeat: no-repeat;\n  background-position: center;\n  background-size: cover;\n  position: relative;\n  z-index: 1;\n}\n\n.container-login100::before {\n  content: \"\";\n  display: block;\n  position: absolute;\n  z-index: -1;\n  width: 100%;\n  height: 100%;\n  top: 0;\n  left: 0;\n  background-color: rgba(255, 255, 255, 0.9);\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImNob2ljZS1wYWdlLnBhZ2Uuc2NzcyIsIi4uXFwuLlxcLi5cXC4uXFwuLlxcLi5cXC4uXFwuLlxcLi5cXC4uXFxBUCUyMDIwMjIlMjAtJTIwMjAyM1xcQXBwbGllZCUyMHNvZnR3YXJlJTIwcHJvamVjdFxcUXJjb2RlcyUyMHNjYW5uZW4lMjB2YW4lMjBib29tc29vcnQlMjB0YWtlJTIwMlxcMjItMjMtQVNQLWFzcC1ncm9lcC1iXFxQcm9qZWN0ZW5cXEJUUC1hcHAlMjBJb25pY1xcYm9vbS10YWFrLXBsYW5uZXItaW9uaWNcXHNyY1xcYXBwXFxjaG9pY2UtcGFnZVxcY2hvaWNlLXBhZ2UucGFnZS5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsV0FBQTtFQUNBLGlCQUFBO0VBS0EsYUFBQTtFQUNBLGVBQUE7RUFDQSx1QkFBQTtFQUNBLG1CQUFBO0VBQ0EsYUFBQTtFQUVBLDRCQUFBO0VBQ0EsMkJBQUE7RUFDQSxzQkFBQTtFQUNBLGtCQUFBO0VBQ0EsVUFBQTtBQ0FGOztBREVBO0VBQ0UsV0FBQTtFQUNBLGNBQUE7RUFDQSxrQkFBQTtFQUNBLFdBQUE7RUFDQSxXQUFBO0VBQ0EsWUFBQTtFQUNBLE1BQUE7RUFDQSxPQUFBO0VBQ0EsMENBQUE7QUNDRiIsImZpbGUiOiJjaG9pY2UtcGFnZS5wYWdlLnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuY29udGFpbmVyLWxvZ2luMTAwIHtcclxuICB3aWR0aDogMTAwJTsgIFxyXG4gIG1pbi1oZWlnaHQ6IDEwMHZoO1xyXG4gIGRpc3BsYXk6IC13ZWJraXQtYm94O1xyXG4gIGRpc3BsYXk6IC13ZWJraXQtZmxleDtcclxuICBkaXNwbGF5OiAtbW96LWJveDtcclxuICBkaXNwbGF5OiAtbXMtZmxleGJveDtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGZsZXgtd3JhcDogd3JhcDtcclxuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcclxuICBhbGlnbi1pdGVtczogY2VudGVyO1xyXG4gIHBhZGRpbmc6IDE1cHg7XHJcblxyXG4gIGJhY2tncm91bmQtcmVwZWF0OiBuby1yZXBlYXQ7XHJcbiAgYmFja2dyb3VuZC1wb3NpdGlvbjogY2VudGVyO1xyXG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XHJcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gIHotaW5kZXg6IDE7ICBcclxufVxyXG4uY29udGFpbmVyLWxvZ2luMTAwOjpiZWZvcmUge1xyXG4gIGNvbnRlbnQ6IFwiXCI7XHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbiAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gIHotaW5kZXg6IC0xO1xyXG4gIHdpZHRoOiAxMDAlO1xyXG4gIGhlaWdodDogMTAwJTtcclxuICB0b3A6IDA7XHJcbiAgbGVmdDogMDtcclxuICBiYWNrZ3JvdW5kLWNvbG9yOiByZ2JhKDI1NSwyNTUsMjU1LDAuOSk7XHJcbn1cclxuIiwiLmNvbnRhaW5lci1sb2dpbjEwMCB7XG4gIHdpZHRoOiAxMDAlO1xuICBtaW4taGVpZ2h0OiAxMDB2aDtcbiAgZGlzcGxheTogLXdlYmtpdC1ib3g7XG4gIGRpc3BsYXk6IC13ZWJraXQtZmxleDtcbiAgZGlzcGxheTogLW1vei1ib3g7XG4gIGRpc3BsYXk6IC1tcy1mbGV4Ym94O1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LXdyYXA6IHdyYXA7XG4gIGp1c3RpZnktY29udGVudDogY2VudGVyO1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICBwYWRkaW5nOiAxNXB4O1xuICBiYWNrZ3JvdW5kLXJlcGVhdDogbm8tcmVwZWF0O1xuICBiYWNrZ3JvdW5kLXBvc2l0aW9uOiBjZW50ZXI7XG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcbiAgei1pbmRleDogMTtcbn1cblxuLmNvbnRhaW5lci1sb2dpbjEwMDo6YmVmb3JlIHtcbiAgY29udGVudDogXCJcIjtcbiAgZGlzcGxheTogYmxvY2s7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgei1pbmRleDogLTE7XG4gIHdpZHRoOiAxMDAlO1xuICBoZWlnaHQ6IDEwMCU7XG4gIHRvcDogMDtcbiAgbGVmdDogMDtcbiAgYmFja2dyb3VuZC1jb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjkpO1xufSJdfQ== */";

/***/ }),

/***/ 6829:
/*!**************************************************************!*\
  !*** ./src/app/choice-page/choice-page.page.html?ngResource ***!
  \**************************************************************/
/***/ ((module) => {

module.exports = "<div id=\"main-content\">\r\n  <ion-header>\r\n    <ion-toolbar class=\"headerTP\">\r\n      <ion-buttons slot=\"start\">\r\n        <ion-menu-button class=\"header-img\" *ngIf=\"auth.user$ | async as user\">      \r\n          <img src={{user.picture}} alt=\"\" style=\"width: 70px; border-radius: 30%;\" >\r\n        </ion-menu-button>\r\n      </ion-buttons >\r\n      <ion-title > Boom Taak Planner</ion-title>\r\n    </ion-toolbar>\r\n  </ion-header>\r\n  </div>\r\n  \r\n  <button (click)=\"dataUser()\">Save</button>\r\n  <button (click)=\"datas()\">put</button>\r\n  <ion-content>\r\n    \r\n  <ng-container *ngFor=\"let checkers of liveData;\">\r\n    <ng-container ngFor=\"let checker of checkers.schedules; let i=index\">\r\n          <ion-icon name=\"calendar\"></ion-icon>\r\n          <ion-label>Planning</ion-label>\r\n          <ion-badge>{{i}}</ion-badge>\r\n    </ng-container>\r\n  </ng-container>\r\n  <div [style.background-image]=\"'url(../../assets/boomen.jpg )'\">\r\n\r\n    \r\n    <ion-list>\r\n      <ion-accordion-group>\r\n          <ng-container *ngFor=\"let checkers of liveData;\">\r\n              <ng-container *ngFor=\"let checker of checkers.schedules; let i=index\">\r\n              <ion-accordion>\r\n                <ng-container *ngIf=\"!i || (checker.date) !== (checkers.schedules[i-1].date) \">\r\n                \r\n                  <ion-item slot=\"header\" color=\"light\">\r\n                    <ion-label>Date: {{checker.date | date:'longDate'}}</ion-label>\r\n                  </ion-item>\r\n                  <div class=\"ion-padding\" slot=\"content\">\r\n                    <ion-item-group *ngFor=\"let datas of liveData; let j=index\">             \r\n                     <ion-item-group *ngFor=\"let data of datas.schedules; let j=index\">\r\n                      <ion-item *ngIf=\"(data.date ) == (checker.date )\">\r\n                        <ion-label>\r\n                        <ion-label>Date: {{data.date | date:'shortTime'}}</ion-label>    \r\n                        <ion-label>Zone: {{data.zoneId}}</ion-label>\r\n                        <ng-container *ngFor=\"let datas of data.tasks\">\r\n                        <ion-label>Status: {{datas.status}}</ion-label>\r\n                        <div *ngIf=\"datas.status == 0\" class=\"col\"><ion-button class=\"button\" color=\"primary\" (click)=\"changeStatus(0)\">Aangemaakt</ion-button></div>\r\n                        <div *ngIf=\"datas.status == 1\" class=\"col\"><ion-button class=\"button\" color=\"success\" (click)=\"changeStatus(1)\">Taak gestart</ion-button></div>\r\n                        <div *ngIf=\"datas.status == 2\" class=\"col\"><ion-button class=\"button\" color=\"danger\" [disabled]=\"true\" (click)=\"changeStatus(2)\">Taak Stoppen</ion-button></div>\r\n                      \r\n                        <ion-label>Task: {{datas.title}}</ion-label>\r\n                        <ion-label>Description: {{datas.description}}</ion-label>\r\n                        </ng-container>\r\n                        </ion-label>\r\n                      </ion-item>\r\n                    </ion-item-group>\r\n                    </ion-item-group>\r\n                  </div>\r\n              </ng-container>\r\n              </ion-accordion>\r\n              \r\n            </ng-container>\r\n          </ng-container>\r\n      </ion-accordion-group>\r\n    </ion-list>\r\n  </div>\r\n    <ion-menu contentId=\"main-content\">\r\n      <ion-header>\r\n        <ion-toolbar *ngIf=\"auth.user$ | async as user\" style=\"text-align: center;\">\r\n          <h3>{{user.name}}</h3>\r\n          <p>{{user.role}}</p>\r\n        </ion-toolbar>\r\n      </ion-header>\r\n        <ion-list>\r\n          <ion-item (click)=\"dataUser()\" routerLink=\"/choice-page\" routerLinkActive=\"active\" ariaCurrentWhenActive=\"page\">\r\n            <ion-icon  name=\"calendar\" slot=\"start\"></ion-icon>\r\n            <ion-title>planning</ion-title>\r\n          </ion-item>\r\n        </ion-list>\r\n        <ion-item (click)=\"dataNow()\" routerLink=\"/choice-page\" routerLinkActive=\"active\" ariaCurrentWhenActive=\"page\">\r\n          <ion-icon name=\"calendar\" slot=\"start\"></ion-icon>\r\n          <ion-title >Vandaag</ion-title>\r\n        </ion-item>\r\n        <ion-item routerLink=\"/qrcode\" routerLinkActive=\"active\" ariaCurrentWhenActive=\"page\">\r\n          <ion-icon name=\"calendar\" slot=\"start\"></ion-icon>\r\n          <ion-label>QR code scannen</ion-label>\r\n        </ion-item>\r\n      <ion-button color=\"danger\" *ngIf=\"auth.isAuthenticated$ | async\" class=\"login100-form-btn\" (click)=\"logout()\">\r\n        logout\r\n      </ion-button>\r\n    </ion-menu>\r\n    \r\n  </ion-content>\r\n  <!-- <ion-toolbar>\r\n    <ng-container *ngFor=\"let value of dataSource | keyvalue\">\r\n      <ng-container *ngFor=\"let data of value.value; let i=index\"> \r\n      <ion-tabs>\r\n          <ion-tab-bar slot=\"bottom\">\r\n            <ion-tab-button tab=\"task\">\r\n              <ion-icon name=\"clipboard-outline\"></ion-icon>\r\n              <ion-label>Task</ion-label>\r\n            </ion-tab-button>\r\n            <ion-tab-button tab=\"planning\">\r\n              <ion-icon name=\"calendar\"></ion-icon>\r\n              <ion-label>Planning</ion-label>\r\n              <ion-badge>{{i+1}}</ion-badge>\r\n            </ion-tab-button>\r\n          </ion-tab-bar>\r\n      </ion-tabs>\r\n      </ng-container>\r\n    </ng-container> \r\n  </ion-toolbar> -->";

/***/ })

}]);
//# sourceMappingURL=src_app_choice-page_choice-page_module_ts.js.map