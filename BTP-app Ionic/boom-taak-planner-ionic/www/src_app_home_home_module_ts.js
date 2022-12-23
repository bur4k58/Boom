"use strict";
(self["webpackChunkapp"] = self["webpackChunkapp"] || []).push([["src_app_home_home_module_ts"],{

/***/ 2003:
/*!*********************************************!*\
  !*** ./src/app/home/home-routing.module.ts ***!
  \*********************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HomePageRoutingModule": () => (/* binding */ HomePageRoutingModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _home_page__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./home.page */ 2267);




const routes = [
    {
        path: '',
        component: _home_page__WEBPACK_IMPORTED_MODULE_0__.HomePage,
    }
];
let HomePageRoutingModule = class HomePageRoutingModule {
};
HomePageRoutingModule = (0,tslib__WEBPACK_IMPORTED_MODULE_1__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_2__.NgModule)({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule.forChild(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_3__.RouterModule]
    })
], HomePageRoutingModule);



/***/ }),

/***/ 3467:
/*!*************************************!*\
  !*** ./src/app/home/home.module.ts ***!
  \*************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HomePageModule": () => (/* binding */ HomePageModule)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _ionic_angular__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @ionic/angular */ 3819);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/forms */ 587);
/* harmony import */ var _home_page__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./home.page */ 2267);
/* harmony import */ var _home_routing_module__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./home-routing.module */ 2003);







let HomePageModule = class HomePageModule {
};
HomePageModule = (0,tslib__WEBPACK_IMPORTED_MODULE_2__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_3__.NgModule)({
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_4__.CommonModule,
            _angular_forms__WEBPACK_IMPORTED_MODULE_5__.FormsModule,
            _ionic_angular__WEBPACK_IMPORTED_MODULE_6__.IonicModule,
            _home_routing_module__WEBPACK_IMPORTED_MODULE_1__.HomePageRoutingModule
        ],
        declarations: [_home_page__WEBPACK_IMPORTED_MODULE_0__.HomePage]
    })
], HomePageModule);



/***/ }),

/***/ 2267:
/*!***********************************!*\
  !*** ./src/app/home/home.page.ts ***!
  \***********************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "HomePage": () => (/* binding */ HomePage)
/* harmony export */ });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! tslib */ 4929);
/* harmony import */ var _home_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./home.page.html?ngResource */ 3853);
/* harmony import */ var _home_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./home.page.scss?ngResource */ 1020);
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common */ 6362);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/core */ 3184);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! @angular/router */ 2816);
/* harmony import */ var _auth0_auth0_angular__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @auth0/auth0-angular */ 6437);
/* harmony import */ var _ionic_native_barcode_scanner_ngx__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @ionic-native/barcode-scanner/ngx */ 5684);
/* harmony import */ var _shared_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../shared.service */ 7482);









let HomePage = class HomePage {
    constructor(service, auth, doc, router, scanner) {
        this.service = service;
        this.auth = auth;
        this.doc = doc;
        this.router = router;
        this.scanner = scanner;
        this.profileJson = null;
        this.encodText = '';
        this.encodeData = {};
        this.scannedData = {};
    }
    ngOnInit() {
        this.auth.user$.subscribe((profile) => (this.profileJson) = JSON.stringify(profile, null, 2));
        /*if (localStorage.getItem('loggedIn') && this.auth.isAuthenticated$) {
          this.router.navigate(['/choice-page'])
        }*/
    }
    loginWithRedirect() {
        this.auth.loginWithRedirect({ appState: { target: '/choice-page' }
        });
        localStorage.setItem('loggedIn', 'true');
    }
    logout() {
        this.auth.logout({ returnTo: this.doc.location.origin });
        localStorage.removeItem('loggedIn');
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
    encode() {
        this.scanner.encode(this.scanner.Encode.TEXT_TYPE, this.encodText).then((data) => {
            this.encodeData = data;
        }, (err) => {
            console.log('Error:', err);
        });
    }
};
HomePage.ctorParameters = () => [
    { type: _shared_service__WEBPACK_IMPORTED_MODULE_3__.SharedService },
    { type: _auth0_auth0_angular__WEBPACK_IMPORTED_MODULE_4__.AuthService },
    { type: Document, decorators: [{ type: _angular_core__WEBPACK_IMPORTED_MODULE_5__.Inject, args: [_angular_common__WEBPACK_IMPORTED_MODULE_6__.DOCUMENT,] }] },
    { type: _angular_router__WEBPACK_IMPORTED_MODULE_7__.Router },
    { type: _ionic_native_barcode_scanner_ngx__WEBPACK_IMPORTED_MODULE_2__.BarcodeScanner }
];
HomePage = (0,tslib__WEBPACK_IMPORTED_MODULE_8__.__decorate)([
    (0,_angular_core__WEBPACK_IMPORTED_MODULE_5__.Component)({
        selector: 'app-home',
        template: _home_page_html_ngResource__WEBPACK_IMPORTED_MODULE_0__,
        styles: [_home_page_scss_ngResource__WEBPACK_IMPORTED_MODULE_1__]
    })
], HomePage);



/***/ }),

/***/ 1020:
/*!************************************************!*\
  !*** ./src/app/home/home.page.scss?ngResource ***!
  \************************************************/
/***/ ((module) => {

module.exports = "a {\n  font-family: Poppins-Regular;\n  font-size: 14px;\n  line-height: 1.7;\n  color: #666666;\n  margin: 0px;\n  transition: all 0.4s;\n  -webkit-transition: all 0.4s;\n  -o-transition: all 0.4s;\n  -moz-transition: all 0.4s;\n}\n\na:focus {\n  outline: none !important;\n}\n\na:hover {\n  text-decoration: none;\n  color: #fff;\n}\n\n/*---------------------------------------------*/\n\nh1, h2, h3, h4, h5, h6 {\n  margin: 0px;\n}\n\np {\n  font-family: Poppins-Regular;\n  font-size: 14px;\n  line-height: 1.7;\n  color: #666666;\n  margin: 0px;\n}\n\nul, li {\n  margin: 0px;\n  list-style-type: none;\n}\n\nlabel {\n  margin: 0;\n  display: block;\n}\n\n/*---------------------------------------------*/\n\nbutton {\n  outline: none !important;\n  border: none;\n  background: transparent;\n}\n\nbutton:hover {\n  cursor: pointer;\n}\n\niframe {\n  border: none !important;\n}\n\n/*//////////////////////////////////////////////////////////////////\n[ Utility ]*/\n\n.txt1 {\n  font-family: Poppins-Regular;\n  font-size: 13px;\n  color: #e5e5e5;\n  line-height: 1.5;\n}\n\n/*//////////////////////////////////////////////////////////////////\n[ login ]*/\n\n.limiter {\n  width: 100%;\n  margin: 0 auto;\n}\n\n.container-login100 {\n  width: 100%;\n  min-height: 100vh;\n  display: flex;\n  flex-wrap: wrap;\n  justify-content: center;\n  align-items: center;\n  padding: 15px;\n  background-repeat: no-repeat;\n  background-position: center;\n  background-size: cover;\n  position: relative;\n  z-index: 1;\n}\n\n.container-login100::before {\n  content: \"\";\n  display: block;\n  position: absolute;\n  z-index: -1;\n  width: 100%;\n  height: 100%;\n  top: 0;\n  left: 0;\n  background-color: rgba(255, 255, 255, 0.9);\n}\n\n.wrap-login100 {\n  width: 500px;\n  border-radius: 10px;\n  overflow: hidden;\n  padding: 55px 55px 37px 55px;\n  background: rgb(13, 128, 62);\n}\n\n/*------------------------------------------------------------------\n[ Form ]*/\n\n.login100-form {\n  width: 100%;\n}\n\n.login100-form-logo {\n  font-size: 60px;\n  color: #333333;\n  display: flex;\n  justify-content: center;\n  align-items: center;\n  width: 120px;\n  height: 120px;\n  border-radius: 50%;\n  background-color: #fff;\n  margin: 0 auto;\n}\n\n.login100-form-title {\n  font-family: Poppins-Medium;\n  font-size: 30px;\n  color: #fff;\n  line-height: 1.2;\n  text-align: center;\n  text-transform: uppercase;\n  display: block;\n}\n\n/*---------------------------------------------*/\n\n.focus-input100 {\n  position: absolute;\n  display: block;\n  width: 100%;\n  height: 100%;\n  top: 0;\n  left: 0;\n  pointer-events: none;\n}\n\n.focus-input100::before {\n  content: \"\";\n  display: block;\n  position: absolute;\n  bottom: -2px;\n  left: 0;\n  width: 0;\n  height: 2px;\n  transition: all 0.4s;\n  background: #fff;\n}\n\n.focus-input100::after {\n  font-family: Material-Design-Iconic-Font;\n  font-size: 22px;\n  color: #fff;\n  content: attr(data-placeholder);\n  display: block;\n  width: 100%;\n  position: absolute;\n  top: 6px;\n  left: 0px;\n  padding-left: 5px;\n  transition: all 0.4s;\n}\n\n.input100:focus {\n  padding-left: 5px;\n}\n\n.input100:focus + .focus-input100::after {\n  top: -22px;\n  font-size: 18px;\n}\n\n.input100:focus + .focus-input100::before {\n  width: 100%;\n}\n\n.has-val.input100 + .focus-input100::after {\n  top: -22px;\n  font-size: 18px;\n}\n\n.has-val.input100 + .focus-input100::before {\n  width: 100%;\n}\n\n.has-val.input100 {\n  padding-left: 5px;\n}\n\n/*==================================================================\n[ Restyle Checkbox ]*/\n\n.contact100-form-checkbox {\n  padding-left: 5px;\n  padding-top: 5px;\n  padding-bottom: 35px;\n}\n\n.input-checkbox100 {\n  display: none;\n}\n\n.label-checkbox100 {\n  font-family: Poppins-Regular;\n  font-size: 13px;\n  color: #fff;\n  line-height: 1.2;\n  display: block;\n  position: relative;\n  padding-left: 26px;\n  cursor: pointer;\n}\n\n.label-checkbox100::before {\n  content: \"\\f26b\";\n  font-family: Material-Design-Iconic-Font;\n  font-size: 13px;\n  color: transparent;\n  display: flex;\n  justify-content: center;\n  align-items: center;\n  position: absolute;\n  width: 16px;\n  height: 16px;\n  border-radius: 2px;\n  background: #fff;\n  left: 0;\n  top: 50%;\n  transform: translateY(-50%);\n}\n\n.input-checkbox100:checked + .label-checkbox100::before {\n  color: #555555;\n}\n\n/*------------------------------------------------------------------\n[ Button ]*/\n\n.container-login100-form-btn {\n  width: 100%;\n  display: flex;\n  flex-wrap: wrap;\n  justify-content: center;\n}\n\n.login100-form-btn {\n  font-family: Poppins-Medium;\n  font-size: 16px;\n  color: #262626;\n  line-height: 1.2;\n  display: flex;\n  justify-content: center;\n  align-items: center;\n  padding: 0 20px;\n  min-width: 120px;\n  height: 50px;\n  border-radius: 25px;\n  background: #000000;\n  background: linear-gradient(bottom, #7579ff, #b224ef);\n  position: relative;\n  z-index: 1;\n  transition: all 0.4s;\n}\n\n.login100-form-btn::before {\n  content: \"\";\n  display: block;\n  position: absolute;\n  z-index: -1;\n  width: 100%;\n  height: 100%;\n  border-radius: 25px;\n  background-color: #ffffff;\n  top: 0;\n  left: 0;\n  opacity: 1;\n  transition: all 0.4s;\n}\n\n.login100-form-btn:hover {\n  color: #f6f6f6;\n}\n\n.login100-form-btn:hover:before {\n  opacity: 0;\n}\n\n/*------------------------------------------------------------------\n[ Responsive ]*/\n\n@media (max-width: 576px) {\n  .wrap-login100 {\n    padding: 55px 15px 37px 15px;\n  }\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhvbWUucGFnZS5zY3NzIiwiLi5cXC4uXFwuLlxcLi5cXC4uXFwuLlxcLi5cXC4uXFwuLlxcLi5cXEFQJTIwMjAyMiUyMC0lMjAyMDIzXFxBcHBsaWVkJTIwc29mdHdhcmUlMjBwcm9qZWN0XFxRcmNvZGVzJTIwc2Nhbm5lbiUyMHZhbiUyMGJvb21zb29ydCUyMHRha2UlMjAyXFwyMi0yMy1BU1AtYXNwLWdyb2VwLWJcXFByb2plY3RlblxcQlRQLWFwcCUyMElvbmljXFxib29tLXRhYWstcGxhbm5lci1pb25pY1xcc3JjXFxhcHBcXGhvbWVcXGhvbWUucGFnZS5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0MsNEJBQUE7RUFDQSxlQUFBO0VBQ0EsZ0JBQUE7RUFDQSxjQUFBO0VBQ0EsV0FBQTtFQUNBLG9CQUFBO0VBQ0EsNEJBQUE7RUFDQyx1QkFBQTtFQUNBLHlCQUFBO0FDQ0Y7O0FERUE7RUFDQyx3QkFBQTtBQ0NEOztBREVBO0VBQ0MscUJBQUE7RUFDQyxXQUFBO0FDQ0Y7O0FERUEsZ0RBQUE7O0FBQ0E7RUFDQyxXQUFBO0FDQ0Q7O0FERUE7RUFDQyw0QkFBQTtFQUNBLGVBQUE7RUFDQSxnQkFBQTtFQUNBLGNBQUE7RUFDQSxXQUFBO0FDQ0Q7O0FERUE7RUFDQyxXQUFBO0VBQ0EscUJBQUE7QUNDRDs7QURLQTtFQUNFLFNBQUE7RUFDQSxjQUFBO0FDRkY7O0FES0EsZ0RBQUE7O0FBQ0E7RUFDQyx3QkFBQTtFQUNBLFlBQUE7RUFDQSx1QkFBQTtBQ0ZEOztBREtBO0VBQ0MsZUFBQTtBQ0ZEOztBREtBO0VBQ0MsdUJBQUE7QUNGRDs7QURNQTtZQUFBOztBQUVBO0VBQ0UsNEJBQUE7RUFDQSxlQUFBO0VBQ0EsY0FBQTtFQUNBLGdCQUFBO0FDSEY7O0FET0E7VUFBQTs7QUFHQTtFQUNFLFdBQUE7RUFDQSxjQUFBO0FDTEY7O0FEUUE7RUFDRSxXQUFBO0VBQ0EsaUJBQUE7RUFLQSxhQUFBO0VBQ0EsZUFBQTtFQUNBLHVCQUFBO0VBQ0Es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QUNGIiwiZmlsZSI6ImhvbWUucGFnZS5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYSB7XHJcblx0Zm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcclxuXHRmb250LXNpemU6IDE0cHg7XHJcblx0bGluZS1oZWlnaHQ6IDEuNztcclxuXHRjb2xvcjogIzY2NjY2NjtcclxuXHRtYXJnaW46IDBweDtcclxuXHR0cmFuc2l0aW9uOiBhbGwgMC40cztcclxuXHQtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1vLXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1tb3otdHJhbnNpdGlvbjogYWxsIDAuNHM7XHJcbn1cclxuXHJcbmE6Zm9jdXMge1xyXG5cdG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcclxufVxyXG5cclxuYTpob3ZlciB7XHJcblx0dGV4dC1kZWNvcmF0aW9uOiBub25lO1xyXG4gIGNvbG9yOiAjZmZmO1xyXG59XHJcblxyXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSovXHJcbmgxLGgyLGgzLGg0LGg1LGg2IHtcclxuXHRtYXJnaW46IDBweDtcclxufVxyXG5cclxucCB7XHJcblx0Zm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcclxuXHRmb250LXNpemU6IDE0cHg7XHJcblx0bGluZS1oZWlnaHQ6IDEuNztcclxuXHRjb2xvcjogIzY2NjY2NjtcclxuXHRtYXJnaW46IDBweDtcclxufVxyXG5cclxudWwsIGxpIHtcclxuXHRtYXJnaW46IDBweDtcclxuXHRsaXN0LXN0eWxlLXR5cGU6IG5vbmU7XHJcbn1cclxuXHJcblxyXG5cclxuXHJcbmxhYmVsIHtcclxuICBtYXJnaW46IDA7XHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbn1cclxuXHJcbi8qLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tKi9cclxuYnV0dG9uIHtcclxuXHRvdXRsaW5lOiBub25lICFpbXBvcnRhbnQ7XHJcblx0Ym9yZGVyOiBub25lO1xyXG5cdGJhY2tncm91bmQ6IHRyYW5zcGFyZW50O1xyXG59XHJcblxyXG5idXR0b246aG92ZXIge1xyXG5cdGN1cnNvcjogcG9pbnRlcjtcclxufVxyXG5cclxuaWZyYW1lIHtcclxuXHRib3JkZXI6IG5vbmUgIWltcG9ydGFudDtcclxufVxyXG5cclxuXHJcbi8qLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vXHJcblsgVXRpbGl0eSBdKi9cclxuLnR4dDEge1xyXG4gIGZvbnQtZmFtaWx5OiBQb3BwaW5zLVJlZ3VsYXI7XHJcbiAgZm9udC1zaXplOiAxM3B4O1xyXG4gIGNvbG9yOiAjZTVlNWU1O1xyXG4gIGxpbmUtaGVpZ2h0OiAxLjU7XHJcbn1cclxuXHJcblxyXG4vKi8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vL1xyXG5bIGxvZ2luIF0qL1xyXG5cclxuLmxpbWl0ZXIge1xyXG4gIHdpZHRoOiAxMDAlO1xyXG4gIG1hcmdpbjogMCBhdXRvO1xyXG59XHJcblxyXG4uY29udGFpbmVyLWxvZ2luMTAwIHtcclxuICB3aWR0aDogMTAwJTsgIFxyXG4gIG1pbi1oZWlnaHQ6IDEwMHZoO1xyXG4gIGRpc3BsYXk6IC13ZWJraXQtYm94O1xyXG4gIGRpc3BsYXk6IC13ZWJraXQtZmxleDtcclxuICBkaXNwbGF5OiAtbW96LWJveDtcclxuICBkaXNwbGF5OiAtbXMtZmxleGJveDtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGZsZXgtd3JhcDogd3JhcDtcclxuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcclxuICBhbGlnbi1pdGVtczogY2VudGVyO1xyXG4gIHBhZGRpbmc6IDE1cHg7XHJcblxyXG4gIGJhY2tncm91bmQtcmVwZWF0OiBuby1yZXBlYXQ7XHJcbiAgYmFja2dyb3VuZC1wb3NpdGlvbjogY2VudGVyO1xyXG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XHJcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gIHotaW5kZXg6IDE7ICBcclxufVxyXG5cclxuLmNvbnRhaW5lci1sb2dpbjEwMDo6YmVmb3JlIHtcclxuICBjb250ZW50OiBcIlwiO1xyXG4gIGRpc3BsYXk6IGJsb2NrO1xyXG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcclxuICB6LWluZGV4OiAtMTtcclxuICB3aWR0aDogMTAwJTtcclxuICBoZWlnaHQ6IDEwMCU7XHJcbiAgdG9wOiAwO1xyXG4gIGxlZnQ6IDA7XHJcbiAgYmFja2dyb3VuZC1jb2xvcjogcmdiYSgyNTUsMjU1LDI1NSwwLjkpO1xyXG59XHJcblxyXG4ud3JhcC1sb2dpbjEwMCB7XHJcbiAgd2lkdGg6IDUwMHB4O1xyXG4gIGJvcmRlci1yYWRpdXM6IDEwcHg7XHJcbiAgb3ZlcmZsb3c6IGhpZGRlbjtcclxuICBwYWRkaW5nOiA1NXB4IDU1cHggMzdweCA1NXB4O1xyXG5cclxuICBiYWNrZ3JvdW5kOiByZ2JhKDEzLDEyOCw2Mik7XHJcbn1cclxuXHJcblxyXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLVxyXG5bIEZvcm0gXSovXHJcblxyXG4ubG9naW4xMDAtZm9ybSB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi5sb2dpbjEwMC1mb3JtLWxvZ28ge1xyXG4gIGZvbnQtc2l6ZTogNjBweDsgXHJcbiAgY29sb3I6ICMzMzMzMzM7XHJcblxyXG4gIGRpc3BsYXk6IC13ZWJraXQtYm94O1xyXG4gIGRpc3BsYXk6IC13ZWJraXQtZmxleDtcclxuICBkaXNwbGF5OiAtbW96LWJveDtcclxuICBkaXNwbGF5OiAtbXMtZmxleGJveDtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGp1c3RpZnktY29udGVudDogY2VudGVyO1xyXG4gIGFsaWduLWl0ZW1zOiBjZW50ZXI7XHJcbiAgd2lkdGg6IDEyMHB4O1xyXG4gIGhlaWdodDogMTIwcHg7XHJcbiAgYm9yZGVyLXJhZGl1czogNTAlO1xyXG4gIGJhY2tncm91bmQtY29sb3I6ICNmZmY7XHJcbiAgbWFyZ2luOiAwIGF1dG87XHJcbn1cclxuXHJcbi5sb2dpbjEwMC1mb3JtLXRpdGxlIHtcclxuICBmb250LWZhbWlseTogUG9wcGlucy1NZWRpdW07XHJcbiAgZm9udC1zaXplOiAzMHB4O1xyXG4gIGNvbG9yOiAjZmZmO1xyXG4gIGxpbmUtaGVpZ2h0OiAxLjI7XHJcbiAgdGV4dC1hbGlnbjogY2VudGVyO1xyXG4gIHRleHQtdHJhbnNmb3JtOiB1cHBlcmNhc2U7XHJcblxyXG4gIGRpc3BsYXk6IGJsb2NrO1xyXG59XHJcblxyXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSovIFxyXG4uZm9jdXMtaW5wdXQxMDAge1xyXG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcclxuICBkaXNwbGF5OiBibG9jaztcclxuICB3aWR0aDogMTAwJTtcclxuICBoZWlnaHQ6IDEwMCU7XHJcbiAgdG9wOiAwO1xyXG4gIGxlZnQ6IDA7XHJcbiAgcG9pbnRlci1ldmVudHM6IG5vbmU7XHJcbn1cclxuXHJcbi5mb2N1cy1pbnB1dDEwMDo6YmVmb3JlIHtcclxuICBjb250ZW50OiBcIlwiO1xyXG4gIGRpc3BsYXk6IGJsb2NrO1xyXG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcclxuICBib3R0b206IC0ycHg7XHJcbiAgbGVmdDogMDtcclxuICB3aWR0aDogMDtcclxuICBoZWlnaHQ6IDJweDtcclxuXHJcbiAgLXdlYmtpdC10cmFuc2l0aW9uOiBhbGwgMC40cztcclxuICAtby10cmFuc2l0aW9uOiBhbGwgMC40cztcclxuICAtbW96LXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIHRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG5cclxuICBiYWNrZ3JvdW5kOiAjZmZmO1xyXG59XHJcblxyXG4uZm9jdXMtaW5wdXQxMDA6OmFmdGVyIHtcclxuICBmb250LWZhbWlseTogTWF0ZXJpYWwtRGVzaWduLUljb25pYy1Gb250O1xyXG4gIGZvbnQtc2l6ZTogMjJweDtcclxuICBjb2xvcjogI2ZmZjtcclxuXHJcbiAgY29udGVudDogYXR0cihkYXRhLXBsYWNlaG9sZGVyKTtcclxuICBkaXNwbGF5OiBibG9jaztcclxuICB3aWR0aDogMTAwJTtcclxuICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgdG9wOiA2cHg7XHJcbiAgbGVmdDogMHB4O1xyXG4gIHBhZGRpbmctbGVmdDogNXB4O1xyXG5cclxuICAtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1vLXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1tb3otdHJhbnNpdGlvbjogYWxsIDAuNHM7XHJcbiAgdHJhbnNpdGlvbjogYWxsIDAuNHM7XHJcbn1cclxuXHJcbi5pbnB1dDEwMDpmb2N1cyB7XHJcbiAgcGFkZGluZy1sZWZ0OiA1cHg7XHJcbn1cclxuXHJcbi5pbnB1dDEwMDpmb2N1cyArIC5mb2N1cy1pbnB1dDEwMDo6YWZ0ZXIge1xyXG4gIHRvcDogLTIycHg7XHJcbiAgZm9udC1zaXplOiAxOHB4O1xyXG59XHJcblxyXG4uaW5wdXQxMDA6Zm9jdXMgKyAuZm9jdXMtaW5wdXQxMDA6OmJlZm9yZSB7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbn1cclxuXHJcbi5oYXMtdmFsLmlucHV0MTAwICsgLmZvY3VzLWlucHV0MTAwOjphZnRlciB7XHJcbiAgdG9wOiAtMjJweDtcclxuICBmb250LXNpemU6IDE4cHg7XHJcbn1cclxuXHJcbi5oYXMtdmFsLmlucHV0MTAwICsgLmZvY3VzLWlucHV0MTAwOjpiZWZvcmUge1xyXG4gIHdpZHRoOiAxMDAlO1xyXG59XHJcblxyXG4uaGFzLXZhbC5pbnB1dDEwMCB7XHJcbiAgcGFkZGluZy1sZWZ0OiA1cHg7XHJcbn1cclxuXHJcblxyXG4vKj09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PVxyXG5bIFJlc3R5bGUgQ2hlY2tib3ggXSovXHJcblxyXG4uY29udGFjdDEwMC1mb3JtLWNoZWNrYm94IHtcclxuICBwYWRkaW5nLWxlZnQ6IDVweDtcclxuICBwYWRkaW5nLXRvcDogNXB4O1xyXG4gIHBhZGRpbmctYm90dG9tOiAzNXB4O1xyXG59XHJcblxyXG4uaW5wdXQtY2hlY2tib3gxMDAge1xyXG4gIGRpc3BsYXk6IG5vbmU7XHJcbn1cclxuXHJcbi5sYWJlbC1jaGVja2JveDEwMCB7XHJcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcclxuICBmb250LXNpemU6IDEzcHg7XHJcbiAgY29sb3I6ICNmZmY7XHJcbiAgbGluZS1oZWlnaHQ6IDEuMjtcclxuXHJcbiAgZGlzcGxheTogYmxvY2s7XHJcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG4gIHBhZGRpbmctbGVmdDogMjZweDtcclxuICBjdXJzb3I6IHBvaW50ZXI7XHJcbn1cclxuXHJcbi5sYWJlbC1jaGVja2JveDEwMDo6YmVmb3JlIHtcclxuICBjb250ZW50OiBcIlxcZjI2YlwiO1xyXG4gIGZvbnQtZmFtaWx5OiBNYXRlcmlhbC1EZXNpZ24tSWNvbmljLUZvbnQ7XHJcbiAgZm9udC1zaXplOiAxM3B4O1xyXG4gIGNvbG9yOiB0cmFuc3BhcmVudDtcclxuXHJcbiAgZGlzcGxheTogLXdlYmtpdC1ib3g7XHJcbiAgZGlzcGxheTogLXdlYmtpdC1mbGV4O1xyXG4gIGRpc3BsYXk6IC1tb3otYm94O1xyXG4gIGRpc3BsYXk6IC1tcy1mbGV4Ym94O1xyXG4gIGRpc3BsYXk6IGZsZXg7XHJcbiAganVzdGlmeS1jb250ZW50OiBjZW50ZXI7XHJcbiAgYWxpZ24taXRlbXM6IGNlbnRlcjtcclxuICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgd2lkdGg6IDE2cHg7XHJcbiAgaGVpZ2h0OiAxNnB4O1xyXG4gIGJvcmRlci1yYWRpdXM6IDJweDtcclxuICBiYWNrZ3JvdW5kOiAjZmZmO1xyXG4gIGxlZnQ6IDA7XHJcbiAgdG9wOiA1MCU7XHJcbiAgLXdlYmtpdC10cmFuc2Zvcm06IHRyYW5zbGF0ZVkoLTUwJSk7XHJcbiAgLW1vei10cmFuc2Zvcm06IHRyYW5zbGF0ZVkoLTUwJSk7XHJcbiAgLW1zLXRyYW5zZm9ybTogdHJhbnNsYXRlWSgtNTAlKTtcclxuICAtby10cmFuc2Zvcm06IHRyYW5zbGF0ZVkoLTUwJSk7XHJcbiAgdHJhbnNmb3JtOiB0cmFuc2xhdGVZKC01MCUpO1xyXG59XHJcblxyXG4uaW5wdXQtY2hlY2tib3gxMDA6Y2hlY2tlZCArIC5sYWJlbC1jaGVja2JveDEwMDo6YmVmb3JlIHtcclxuICBjb2xvcjogIzU1NTU1NTtcclxufVxyXG5cclxuXHJcbi8qLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tXHJcblsgQnV0dG9uIF0qL1xyXG4uY29udGFpbmVyLWxvZ2luMTAwLWZvcm0tYnRuIHtcclxuICB3aWR0aDogMTAwJTtcclxuICBkaXNwbGF5OiAtd2Via2l0LWJveDtcclxuICBkaXNwbGF5OiAtd2Via2l0LWZsZXg7XHJcbiAgZGlzcGxheTogLW1vei1ib3g7XHJcbiAgZGlzcGxheTogLW1zLWZsZXhib3g7XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBmbGV4LXdyYXA6IHdyYXA7XHJcbiAganVzdGlmeS1jb250ZW50OiBjZW50ZXI7XHJcbn1cclxuXHJcbi5sb2dpbjEwMC1mb3JtLWJ0biB7XHJcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtTWVkaXVtO1xyXG4gIGZvbnQtc2l6ZTogMTZweDtcclxuICBjb2xvcjogIzI2MjYyNjtcclxuICBsaW5lLWhlaWdodDogMS4yO1xyXG5cclxuICBkaXNwbGF5OiAtd2Via2l0LWJveDtcclxuICBkaXNwbGF5OiAtd2Via2l0LWZsZXg7XHJcbiAgZGlzcGxheTogLW1vei1ib3g7XHJcbiAgZGlzcGxheTogLW1zLWZsZXhib3g7XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcclxuICBhbGlnbi1pdGVtczogY2VudGVyO1xyXG4gIHBhZGRpbmc6IDAgMjBweDtcclxuICBtaW4td2lkdGg6IDEyMHB4O1xyXG4gIGhlaWdodDogNTBweDtcclxuICBib3JkZXItcmFkaXVzOiAyNXB4O1xyXG5cclxuICBiYWNrZ3JvdW5kOiAjMDAwMDAwO1xyXG4gIGJhY2tncm91bmQ6IC13ZWJraXQtbGluZWFyLWdyYWRpZW50KGJvdHRvbSwgIzc1NzlmZiwgI2IyMjRlZik7XHJcbiAgYmFja2dyb3VuZDogLW8tbGluZWFyLWdyYWRpZW50KGJvdHRvbSwgIzc1NzlmZiwgI2IyMjRlZik7XHJcbiAgYmFja2dyb3VuZDogLW1vei1saW5lYXItZ3JhZGllbnQoYm90dG9tLCAjNzU3OWZmLCAjYjIyNGVmKTtcclxuICBiYWNrZ3JvdW5kOiBsaW5lYXItZ3JhZGllbnQoYm90dG9tLCAjNzU3OWZmLCAjYjIyNGVmKTtcclxuICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbiAgei1pbmRleDogMTtcclxuXHJcbiAgLXdlYmtpdC10cmFuc2l0aW9uOiBhbGwgMC40cztcclxuICAtby10cmFuc2l0aW9uOiBhbGwgMC40cztcclxuICAtbW96LXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIHRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG59XHJcblxyXG4ubG9naW4xMDAtZm9ybS1idG46OmJlZm9yZSB7XHJcbiAgY29udGVudDogXCJcIjtcclxuICBkaXNwbGF5OiBibG9jaztcclxuICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgei1pbmRleDogLTE7XHJcbiAgd2lkdGg6IDEwMCU7XHJcbiAgaGVpZ2h0OiAxMDAlO1xyXG4gIGJvcmRlci1yYWRpdXM6IDI1cHg7XHJcbiAgYmFja2dyb3VuZC1jb2xvcjogI2ZmZmZmZjtcclxuICB0b3A6IDA7XHJcbiAgbGVmdDogMDtcclxuICBvcGFjaXR5OiAxO1xyXG5cclxuICAtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1vLXRyYW5zaXRpb246IGFsbCAwLjRzO1xyXG4gIC1tb3otdHJhbnNpdGlvbjogYWxsIDAuNHM7XHJcbiAgdHJhbnNpdGlvbjogYWxsIDAuNHM7XHJcbn1cclxuXHJcbi5sb2dpbjEwMC1mb3JtLWJ0bjpob3ZlciB7XHJcbiAgY29sb3I6ICNmNmY2ZjY7XHJcbn1cclxuXHJcbi5sb2dpbjEwMC1mb3JtLWJ0bjpob3ZlcjpiZWZvcmUge1xyXG4gIG9wYWNpdHk6IDA7XHJcbn1cclxuXHJcblxyXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLVxyXG5bIFJlc3BvbnNpdmUgXSovXHJcblxyXG5AbWVkaWEgKG1heC13aWR0aDogNTc2cHgpIHtcclxuICAud3JhcC1sb2dpbjEwMCB7XHJcbiAgICBwYWRkaW5nOiA1NXB4IDE1cHggMzdweCAxNXB4O1xyXG4gIH1cclxufVxyXG4iLCJhIHtcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcbiAgZm9udC1zaXplOiAxNHB4O1xuICBsaW5lLWhlaWdodDogMS43O1xuICBjb2xvcjogIzY2NjY2NjtcbiAgbWFyZ2luOiAwcHg7XG4gIHRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtby10cmFuc2l0aW9uOiBhbGwgMC40cztcbiAgLW1vei10cmFuc2l0aW9uOiBhbGwgMC40cztcbn1cblxuYTpmb2N1cyB7XG4gIG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcbn1cblxuYTpob3ZlciB7XG4gIHRleHQtZGVjb3JhdGlvbjogbm9uZTtcbiAgY29sb3I6ICNmZmY7XG59XG5cbi8qLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tKi9cbmgxLCBoMiwgaDMsIGg0LCBoNSwgaDYge1xuICBtYXJnaW46IDBweDtcbn1cblxucCB7XG4gIGZvbnQtZmFtaWx5OiBQb3BwaW5zLVJlZ3VsYXI7XG4gIGZvbnQtc2l6ZTogMTRweDtcbiAgbGluZS1oZWlnaHQ6IDEuNztcbiAgY29sb3I6ICM2NjY2NjY7XG4gIG1hcmdpbjogMHB4O1xufVxuXG51bCwgbGkge1xuICBtYXJnaW46IDBweDtcbiAgbGlzdC1zdHlsZS10eXBlOiBub25lO1xufVxuXG5sYWJlbCB7XG4gIG1hcmdpbjogMDtcbiAgZGlzcGxheTogYmxvY2s7XG59XG5cbi8qLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tKi9cbmJ1dHRvbiB7XG4gIG91dGxpbmU6IG5vbmUgIWltcG9ydGFudDtcbiAgYm9yZGVyOiBub25lO1xuICBiYWNrZ3JvdW5kOiB0cmFuc3BhcmVudDtcbn1cblxuYnV0dG9uOmhvdmVyIHtcbiAgY3Vyc29yOiBwb2ludGVyO1xufVxuXG5pZnJhbWUge1xuICBib3JkZXI6IG5vbmUgIWltcG9ydGFudDtcbn1cblxuLyovLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy9cblsgVXRpbGl0eSBdKi9cbi50eHQxIHtcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcbiAgZm9udC1zaXplOiAxM3B4O1xuICBjb2xvcjogI2U1ZTVlNTtcbiAgbGluZS1oZWlnaHQ6IDEuNTtcbn1cblxuLyovLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy9cblsgbG9naW4gXSovXG4ubGltaXRlciB7XG4gIHdpZHRoOiAxMDAlO1xuICBtYXJnaW46IDAgYXV0bztcbn1cblxuLmNvbnRhaW5lci1sb2dpbjEwMCB7XG4gIHdpZHRoOiAxMDAlO1xuICBtaW4taGVpZ2h0OiAxMDB2aDtcbiAgZGlzcGxheTogLXdlYmtpdC1ib3g7XG4gIGRpc3BsYXk6IC13ZWJraXQtZmxleDtcbiAgZGlzcGxheTogLW1vei1ib3g7XG4gIGRpc3BsYXk6IC1tcy1mbGV4Ym94O1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LXdyYXA6IHdyYXA7XG4gIGp1c3RpZnktY29udGVudDogY2VudGVyO1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICBwYWRkaW5nOiAxNXB4O1xuICBiYWNrZ3JvdW5kLXJlcGVhdDogbm8tcmVwZWF0O1xuICBiYWNrZ3JvdW5kLXBvc2l0aW9uOiBjZW50ZXI7XG4gIGJhY2tncm91bmQtc2l6ZTogY292ZXI7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcbiAgei1pbmRleDogMTtcbn1cblxuLmNvbnRhaW5lci1sb2dpbjEwMDo6YmVmb3JlIHtcbiAgY29udGVudDogXCJcIjtcbiAgZGlzcGxheTogYmxvY2s7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgei1pbmRleDogLTE7XG4gIHdpZHRoOiAxMDAlO1xuICBoZWlnaHQ6IDEwMCU7XG4gIHRvcDogMDtcbiAgbGVmdDogMDtcbiAgYmFja2dyb3VuZC1jb2xvcjogcmdiYSgyNTUsIDI1NSwgMjU1LCAwLjkpO1xufVxuXG4ud3JhcC1sb2dpbjEwMCB7XG4gIHdpZHRoOiA1MDBweDtcbiAgYm9yZGVyLXJhZGl1czogMTBweDtcbiAgb3ZlcmZsb3c6IGhpZGRlbjtcbiAgcGFkZGluZzogNTVweCA1NXB4IDM3cHggNTVweDtcbiAgYmFja2dyb3VuZDogcmdiKDEzLCAxMjgsIDYyKTtcbn1cblxuLyotLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS1cblsgRm9ybSBdKi9cbi5sb2dpbjEwMC1mb3JtIHtcbiAgd2lkdGg6IDEwMCU7XG59XG5cbi5sb2dpbjEwMC1mb3JtLWxvZ28ge1xuICBmb250LXNpemU6IDYwcHg7XG4gIGNvbG9yOiAjMzMzMzMzO1xuICBkaXNwbGF5OiAtd2Via2l0LWJveDtcbiAgZGlzcGxheTogLXdlYmtpdC1mbGV4O1xuICBkaXNwbGF5OiAtbW96LWJveDtcbiAgZGlzcGxheTogLW1zLWZsZXhib3g7XG4gIGRpc3BsYXk6IGZsZXg7XG4gIGp1c3RpZnktY29udGVudDogY2VudGVyO1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICB3aWR0aDogMTIwcHg7XG4gIGhlaWdodDogMTIwcHg7XG4gIGJvcmRlci1yYWRpdXM6IDUwJTtcbiAgYmFja2dyb3VuZC1jb2xvcjogI2ZmZjtcbiAgbWFyZ2luOiAwIGF1dG87XG59XG5cbi5sb2dpbjEwMC1mb3JtLXRpdGxlIHtcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtTWVkaXVtO1xuICBmb250LXNpemU6IDMwcHg7XG4gIGNvbG9yOiAjZmZmO1xuICBsaW5lLWhlaWdodDogMS4yO1xuICB0ZXh0LWFsaWduOiBjZW50ZXI7XG4gIHRleHQtdHJhbnNmb3JtOiB1cHBlcmNhc2U7XG4gIGRpc3BsYXk6IGJsb2NrO1xufVxuXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSovXG4uZm9jdXMtaW5wdXQxMDAge1xuICBwb3NpdGlvbjogYWJzb2x1dGU7XG4gIGRpc3BsYXk6IGJsb2NrO1xuICB3aWR0aDogMTAwJTtcbiAgaGVpZ2h0OiAxMDAlO1xuICB0b3A6IDA7XG4gIGxlZnQ6IDA7XG4gIHBvaW50ZXItZXZlbnRzOiBub25lO1xufVxuXG4uZm9jdXMtaW5wdXQxMDA6OmJlZm9yZSB7XG4gIGNvbnRlbnQ6IFwiXCI7XG4gIGRpc3BsYXk6IGJsb2NrO1xuICBwb3NpdGlvbjogYWJzb2x1dGU7XG4gIGJvdHRvbTogLTJweDtcbiAgbGVmdDogMDtcbiAgd2lkdGg6IDA7XG4gIGhlaWdodDogMnB4O1xuICAtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtby10cmFuc2l0aW9uOiBhbGwgMC40cztcbiAgLW1vei10cmFuc2l0aW9uOiBhbGwgMC40cztcbiAgdHJhbnNpdGlvbjogYWxsIDAuNHM7XG4gIGJhY2tncm91bmQ6ICNmZmY7XG59XG5cbi5mb2N1cy1pbnB1dDEwMDo6YWZ0ZXIge1xuICBmb250LWZhbWlseTogTWF0ZXJpYWwtRGVzaWduLUljb25pYy1Gb250O1xuICBmb250LXNpemU6IDIycHg7XG4gIGNvbG9yOiAjZmZmO1xuICBjb250ZW50OiBhdHRyKGRhdGEtcGxhY2Vob2xkZXIpO1xuICBkaXNwbGF5OiBibG9jaztcbiAgd2lkdGg6IDEwMCU7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgdG9wOiA2cHg7XG4gIGxlZnQ6IDBweDtcbiAgcGFkZGluZy1sZWZ0OiA1cHg7XG4gIC13ZWJraXQtdHJhbnNpdGlvbjogYWxsIDAuNHM7XG4gIC1vLXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtbW96LXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICB0cmFuc2l0aW9uOiBhbGwgMC40cztcbn1cblxuLmlucHV0MTAwOmZvY3VzIHtcbiAgcGFkZGluZy1sZWZ0OiA1cHg7XG59XG5cbi5pbnB1dDEwMDpmb2N1cyArIC5mb2N1cy1pbnB1dDEwMDo6YWZ0ZXIge1xuICB0b3A6IC0yMnB4O1xuICBmb250LXNpemU6IDE4cHg7XG59XG5cbi5pbnB1dDEwMDpmb2N1cyArIC5mb2N1cy1pbnB1dDEwMDo6YmVmb3JlIHtcbiAgd2lkdGg6IDEwMCU7XG59XG5cbi5oYXMtdmFsLmlucHV0MTAwICsgLmZvY3VzLWlucHV0MTAwOjphZnRlciB7XG4gIHRvcDogLTIycHg7XG4gIGZvbnQtc2l6ZTogMThweDtcbn1cblxuLmhhcy12YWwuaW5wdXQxMDAgKyAuZm9jdXMtaW5wdXQxMDA6OmJlZm9yZSB7XG4gIHdpZHRoOiAxMDAlO1xufVxuXG4uaGFzLXZhbC5pbnB1dDEwMCB7XG4gIHBhZGRpbmctbGVmdDogNXB4O1xufVxuXG4vKj09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PVxuWyBSZXN0eWxlIENoZWNrYm94IF0qL1xuLmNvbnRhY3QxMDAtZm9ybS1jaGVja2JveCB7XG4gIHBhZGRpbmctbGVmdDogNXB4O1xuICBwYWRkaW5nLXRvcDogNXB4O1xuICBwYWRkaW5nLWJvdHRvbTogMzVweDtcbn1cblxuLmlucHV0LWNoZWNrYm94MTAwIHtcbiAgZGlzcGxheTogbm9uZTtcbn1cblxuLmxhYmVsLWNoZWNrYm94MTAwIHtcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtUmVndWxhcjtcbiAgZm9udC1zaXplOiAxM3B4O1xuICBjb2xvcjogI2ZmZjtcbiAgbGluZS1oZWlnaHQ6IDEuMjtcbiAgZGlzcGxheTogYmxvY2s7XG4gIHBvc2l0aW9uOiByZWxhdGl2ZTtcbiAgcGFkZGluZy1sZWZ0OiAyNnB4O1xuICBjdXJzb3I6IHBvaW50ZXI7XG59XG5cbi5sYWJlbC1jaGVja2JveDEwMDo6YmVmb3JlIHtcbiAgY29udGVudDogXCJcXGYyNmJcIjtcbiAgZm9udC1mYW1pbHk6IE1hdGVyaWFsLURlc2lnbi1JY29uaWMtRm9udDtcbiAgZm9udC1zaXplOiAxM3B4O1xuICBjb2xvcjogdHJhbnNwYXJlbnQ7XG4gIGRpc3BsYXk6IC13ZWJraXQtYm94O1xuICBkaXNwbGF5OiAtd2Via2l0LWZsZXg7XG4gIGRpc3BsYXk6IC1tb3otYm94O1xuICBkaXNwbGF5OiAtbXMtZmxleGJveDtcbiAgZGlzcGxheTogZmxleDtcbiAganVzdGlmeS1jb250ZW50OiBjZW50ZXI7XG4gIGFsaWduLWl0ZW1zOiBjZW50ZXI7XG4gIHBvc2l0aW9uOiBhYnNvbHV0ZTtcbiAgd2lkdGg6IDE2cHg7XG4gIGhlaWdodDogMTZweDtcbiAgYm9yZGVyLXJhZGl1czogMnB4O1xuICBiYWNrZ3JvdW5kOiAjZmZmO1xuICBsZWZ0OiAwO1xuICB0b3A6IDUwJTtcbiAgLXdlYmtpdC10cmFuc2Zvcm06IHRyYW5zbGF0ZVkoLTUwJSk7XG4gIC1tb3otdHJhbnNmb3JtOiB0cmFuc2xhdGVZKC01MCUpO1xuICAtbXMtdHJhbnNmb3JtOiB0cmFuc2xhdGVZKC01MCUpO1xuICAtby10cmFuc2Zvcm06IHRyYW5zbGF0ZVkoLTUwJSk7XG4gIHRyYW5zZm9ybTogdHJhbnNsYXRlWSgtNTAlKTtcbn1cblxuLmlucHV0LWNoZWNrYm94MTAwOmNoZWNrZWQgKyAubGFiZWwtY2hlY2tib3gxMDA6OmJlZm9yZSB7XG4gIGNvbG9yOiAjNTU1NTU1O1xufVxuXG4vKi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLVxuWyBCdXR0b24gXSovXG4uY29udGFpbmVyLWxvZ2luMTAwLWZvcm0tYnRuIHtcbiAgd2lkdGg6IDEwMCU7XG4gIGRpc3BsYXk6IC13ZWJraXQtYm94O1xuICBkaXNwbGF5OiAtd2Via2l0LWZsZXg7XG4gIGRpc3BsYXk6IC1tb3otYm94O1xuICBkaXNwbGF5OiAtbXMtZmxleGJveDtcbiAgZGlzcGxheTogZmxleDtcbiAgZmxleC13cmFwOiB3cmFwO1xuICBqdXN0aWZ5LWNvbnRlbnQ6IGNlbnRlcjtcbn1cblxuLmxvZ2luMTAwLWZvcm0tYnRuIHtcbiAgZm9udC1mYW1pbHk6IFBvcHBpbnMtTWVkaXVtO1xuICBmb250LXNpemU6IDE2cHg7XG4gIGNvbG9yOiAjMjYyNjI2O1xuICBsaW5lLWhlaWdodDogMS4yO1xuICBkaXNwbGF5OiAtd2Via2l0LWJveDtcbiAgZGlzcGxheTogLXdlYmtpdC1mbGV4O1xuICBkaXNwbGF5OiAtbW96LWJveDtcbiAgZGlzcGxheTogLW1zLWZsZXhib3g7XG4gIGRpc3BsYXk6IGZsZXg7XG4gIGp1c3RpZnktY29udGVudDogY2VudGVyO1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICBwYWRkaW5nOiAwIDIwcHg7XG4gIG1pbi13aWR0aDogMTIwcHg7XG4gIGhlaWdodDogNTBweDtcbiAgYm9yZGVyLXJhZGl1czogMjVweDtcbiAgYmFja2dyb3VuZDogIzAwMDAwMDtcbiAgYmFja2dyb3VuZDogLXdlYmtpdC1saW5lYXItZ3JhZGllbnQoYm90dG9tLCAjNzU3OWZmLCAjYjIyNGVmKTtcbiAgYmFja2dyb3VuZDogLW8tbGluZWFyLWdyYWRpZW50KGJvdHRvbSwgIzc1NzlmZiwgI2IyMjRlZik7XG4gIGJhY2tncm91bmQ6IC1tb3otbGluZWFyLWdyYWRpZW50KGJvdHRvbSwgIzc1NzlmZiwgI2IyMjRlZik7XG4gIGJhY2tncm91bmQ6IGxpbmVhci1ncmFkaWVudChib3R0b20sICM3NTc5ZmYsICNiMjI0ZWYpO1xuICBwb3NpdGlvbjogcmVsYXRpdmU7XG4gIHotaW5kZXg6IDE7XG4gIC13ZWJraXQtdHJhbnNpdGlvbjogYWxsIDAuNHM7XG4gIC1vLXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtbW96LXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICB0cmFuc2l0aW9uOiBhbGwgMC40cztcbn1cblxuLmxvZ2luMTAwLWZvcm0tYnRuOjpiZWZvcmUge1xuICBjb250ZW50OiBcIlwiO1xuICBkaXNwbGF5OiBibG9jaztcbiAgcG9zaXRpb246IGFic29sdXRlO1xuICB6LWluZGV4OiAtMTtcbiAgd2lkdGg6IDEwMCU7XG4gIGhlaWdodDogMTAwJTtcbiAgYm9yZGVyLXJhZGl1czogMjVweDtcbiAgYmFja2dyb3VuZC1jb2xvcjogI2ZmZmZmZjtcbiAgdG9wOiAwO1xuICBsZWZ0OiAwO1xuICBvcGFjaXR5OiAxO1xuICAtd2Via2l0LXRyYW5zaXRpb246IGFsbCAwLjRzO1xuICAtby10cmFuc2l0aW9uOiBhbGwgMC40cztcbiAgLW1vei10cmFuc2l0aW9uOiBhbGwgMC40cztcbiAgdHJhbnNpdGlvbjogYWxsIDAuNHM7XG59XG5cbi5sb2dpbjEwMC1mb3JtLWJ0bjpob3ZlciB7XG4gIGNvbG9yOiAjZjZmNmY2O1xufVxuXG4ubG9naW4xMDAtZm9ybS1idG46aG92ZXI6YmVmb3JlIHtcbiAgb3BhY2l0eTogMDtcbn1cblxuLyotLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS1cblsgUmVzcG9uc2l2ZSBdKi9cbkBtZWRpYSAobWF4LXdpZHRoOiA1NzZweCkge1xuICAud3JhcC1sb2dpbjEwMCB7XG4gICAgcGFkZGluZzogNTVweCAxNXB4IDM3cHggMTVweDtcbiAgfVxufSJdfQ== */";

/***/ }),

/***/ 3853:
/*!************************************************!*\
  !*** ./src/app/home/home.page.html?ngResource ***!
  \************************************************/
/***/ ((module) => {

module.exports = "<ion-header [translucent]=\"true\">\r\n  <ion-toolbar>\r\n    <ion-title>\r\n      BoomTaakPlanner\r\n    </ion-title>\r\n  </ion-toolbar>\r\n \r\n</ion-header>\r\n\r\n<ion-content [fullscreen]=\"true\">\r\n  <ion-header collapse=\"condense\">\r\n    <ion-toolbar>\r\n      <ion-title size=\"large\">BoomTaakPlanner</ion-title>\r\n    </ion-toolbar>\r\n    <div *ngIf=\"auth.user$ | async as user\">\r\n      <div>{{user.name}}</div>\r\n    </div>\r\n  </ion-header>\r\n\r\n  <div id=\"container\">\r\n    \r\n    <div class=\"limiter\">\r\n      <div class=\"container-login100\" style=\"background-image: url('../../assets/boomen.jpg');\">\r\n        <div class=\"wrap-login100\">\r\n          <form class=\"login100-form validate-form\">\r\n            <span class=\"login100-form-logo\">\r\n              <i class=\"zmdi zmdi-landscape\"></i>\r\n              <img src=\"../../assets/tree.png\" alt=\"icon\">\r\n            </span>\r\n  \r\n            <span class=\"login100-form-title p-b-34 p-t-27\">\r\n              Log in\r\n            </span>\r\n  \r\n            <div class=\"container-login100-form-btn\">\r\n                <button *ngIf=\"(auth.isAuthenticated$ | async) === false\" class=\"login100-form-btn\" (click)=\"loginWithRedirect()\">\r\n                  login\r\n                </button>\r\n                <button *ngIf=\"auth.isAuthenticated$ | async\" class=\"login100-form-btn\" (click)=\"logout()\">\r\n                  logout\r\n                </button>\r\n            </div>\r\n          </form>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <ion-input style=\"background-color: gray;\" type=\"text\" [(ngModel)]=\"encodeText\"></ion-input>\r\n  <ion-button ion-button block (click)=\"encode()\">Encode</ion-button>\r\n</div>\r\n<div>\r\n  <ion-button style=\"position: fixed;\r\n  left: 0;\r\n  bottom: 10px;\r\n  right: 0;\r\n  width: 100%;\" (click)=\"scan()\">Scan</ion-button>\r\n  <div *ngIf=\"scannedData.text\">\r\n    <label>Your barcode is</label>\r\n    <br>\r\n    <span>{{scannedData.text}}</span>\r\n  </div>\r\n    \r\n  \r\n    <div id=\"dropDownSelect1\"></div>\r\n  </div>\r\n  \r\n</ion-content>";

/***/ })

}]);
//# sourceMappingURL=src_app_home_home_module_ts.js.map