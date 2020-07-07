import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { LoginComponent } from './component/security/login/login.component';
import { ReportDetailsComponent } from './component/report/report-details/report-details.component';
import { AuthGuard } from './shared/_guards';
import { MerchantReportComponent } from './component/report/report-collection/merchant-report/merchant-report.component';
const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]  },
  { path: 'login', component: LoginComponent},
  { path: 'report-details', component: ReportDetailsComponent },
  { path: 'app-merchant-report', component: MerchantReportComponent, canActivate: [AuthGuard] },
  {
    path: "",
    pathMatch: "full",
    redirectTo: "home"
  },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      useHash: true,
      enableTracing: false,
      scrollPositionRestoration: 'enabled'
    }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
