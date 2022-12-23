import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Router, CanLoad } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { BarcodeScanner, BarcodeScannerOptions } from '@ionic-native/barcode-scanner/ngx';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit {
  profileJson: string = null;
  options: BarcodeScannerOptions;
  encodText: string='';
  encodeData: any={};
  scannedData:  any={};
  constructor(private service:SharedService,public auth: AuthService, @Inject(DOCUMENT) private doc: Document, private router: Router, public scanner: BarcodeScanner) {}

  ngOnInit(): void {
    this.auth.user$.subscribe(
      (profile) => (this.profileJson) = JSON.stringify(profile, null, 2)
    )
    
    /*if (localStorage.getItem('loggedIn') && this.auth.isAuthenticated$) {
      this.router.navigate(['/choice-page'])
    }*/
  }

  loginWithRedirect(): void{
    this.auth.loginWithRedirect({appState: { target: '/choice-page' }
    }
    )
    localStorage.setItem('loggedIn', 'true');
  }
  logout(): void{
    this.auth.logout({returnTo: this.doc.location.origin});
    localStorage.removeItem('loggedIn');
  }
  scan(){
    this.options = {
      prompt: 'Scan you barcode'
    };
    this.scanner.scan().then((data) => {
      this.scannedData = data;
    }, (err) => {
      console.log('Error:', err);
    })
  }
  encode(){
    this.scanner.encode(this.scanner.Encode.TEXT_TYPE, this.encodText ).then((data) => {
      this.encodeData = data;
    }, (err) => {
      console.log('Error:', err)
    })
  }
}
