import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
//SC-Speak Modules
import { ScAccountInformationModule } from '@speak/ng-bcl/account-information';
import { ScActionBarModule } from '@speak/ng-bcl/action-bar';
import { ScApplicationHeaderModule } from '@speak/ng-bcl/application-header';
import { ScButtonModule } from '@speak/ng-bcl/button';
import { ScGlobalHeaderModule } from '@speak/ng-bcl/global-header';
import { ScGlobalLogoModule } from '@speak/ng-bcl/global-logo';
import { ScIconModule } from '@speak/ng-bcl/icon';
import { ScMenuCategory, ScMenuItem, ScMenuItemLink, ScMenuModule } from '@speak/ng-bcl/menu';
import { ScTableModule } from '@speak/ng-bcl/table';
import { ScPageModule } from '@speak/ng-bcl/page';
import { CONTEXT, DICTIONARY } from '@speak/ng-bcl';
import { NgScModule } from '@speak/ng-sc';
import { ScTabsModule } from '@speak/ng-bcl/tabs';
import { ScDropdownModule } from '@speak/ng-bcl/dropdown';

import { AppService } from "./app.service";


//Components -- Sc-Live-Traking
import { AppComponent } from './app.component';
import { DefaultLandingPageComponent } from './default-landing-page/default-landing-page.component';
import { TrafficPageComponent } from './traffic-page/traffic-page.component';
import { ChartPageComponent } from './chart-page/chart-page.component';

@NgModule({
  declarations: [
    AppComponent,
    DefaultLandingPageComponent,
    TrafficPageComponent,
    ChartPageComponent
  ],
  imports: [
    BrowserModule,
    ScAccountInformationModule,
    ScActionBarModule,
    ScApplicationHeaderModule,
    ScButtonModule,
    ScGlobalHeaderModule,
    ScGlobalLogoModule,
    ScIconModule,
    ScPageModule,
    ScMenuModule,
    ScTableModule,
    ScDropdownModule,
    ScTabsModule,    
    RouterModule.forRoot(
      [
        {path:'',component: DefaultLandingPageComponent,pathMatch:'full'},
        {path:'home',component: DefaultLandingPageComponent,pathMatch:'full'},
        { path: 'traffic-page', component: TrafficPageComponent, pathMatch: 'full' },
        { path: 'chart-page', component: ChartPageComponent, pathMatch: 'full' }
      ]

    ),
    NgScModule.forRoot({
      contextToken: CONTEXT, // Provide Sitecore context for SPEAK 3 Components (optional)
      dictionaryToken: DICTIONARY, // Provide translations for SPEAK 3 Components (optional)
      translateItemId: '716445D8-E4A9-4A8D-B500-3E87A7508D4F', // ItemId where your application stores translation items (optional)
      authItemId: 'B61A8925-360E-46F8-8FC8-24D0758396B1' // ItemId where your application stores user access authorization (optional)
    })
  ],
  providers: [AppService],
  bootstrap: [AppComponent]  
})



export class AppModule { }
