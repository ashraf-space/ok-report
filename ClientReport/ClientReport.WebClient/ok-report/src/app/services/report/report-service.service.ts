import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MfsSettingService } from '../mfs-setting.service';


@Injectable({
  providedIn: 'root'
})
export class ReportServiceService {
   
  constructor(private http: HttpClient, private settings: MfsSettingService) { }

  getMerchantKycInfoByMphone(mobileNo : string) {
    return this.http.get<any>(this.settings.reportApiServer + '/Kyc/getMerchantKycInfoByMphone?mphone='+mobileNo)
      .pipe(map(data => {
        return data;
      }));
  }
}
