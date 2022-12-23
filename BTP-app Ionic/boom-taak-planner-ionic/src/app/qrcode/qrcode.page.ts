import { Component, OnInit } from '@angular/core';
import { BarcodeScanner, BarcodeScannerOptions } from '@ionic-native/barcode-scanner/ngx';

@Component({
  selector: 'app-qrcode',
  templateUrl: './qrcode.page.html',
  styleUrls: ['./qrcode.page.scss'],
})
export class QrcodePage implements OnInit {
  options: BarcodeScannerOptions;
  encodText: string='';
  encodeData: any={};
  scannedData:  any={};
  constructor(public scanner: BarcodeScanner) { }

  ngOnInit() {
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
}
