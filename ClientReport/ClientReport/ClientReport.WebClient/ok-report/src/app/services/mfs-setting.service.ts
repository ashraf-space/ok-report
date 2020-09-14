import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MfsSettingService {
  securityApiServer: string = '../ClientReport.SecurityApiServer/api';
  reportApiServer: string = '../ClientReport.ReportApiServer/api';
  environmentApiServer: string = '../OneMFS.EnvironmentApiServer/api';
  distributionApiServer: string = '../OneMFS.DistributionApiServer/api';
  clientApiServer: string = '../OneMFS.ClientApiServer/api';
  transactionApiServer: string = '../OneMFS.TransactionApiServer/api';
  reportingApiServer: string = '../OneMFS.ReportingApiServer/api';
  
  constructor() { }
}
