import { Component, OnInit, NgZone } from '@angular/core';
import { SciLogoutService } from '@speak/ng-sc/logout';
import { ActivatedRoute } from '@angular/router';
import {SciAuthService} from '@speak/ng-sc/auth';
import { AppService } from "../app.service";
import { ContactMessageService  } from '../app.contactmessageservice';  

//LeafLet map
import * as LeafLet from 'leaflet';

@Component({
  selector: 'app-default-landing-page',
  templateUrl: './default-landing-page.component.html',
  styleUrls: ['./default-landing-page.component.css'],
  providers:[ContactMessageService]
})
export class DefaultLandingPageComponent implements OnInit {
  

  private map; 
  private isConnectionEstablished : Boolean;
  private allContacts : any[];
   
  constructor(
    public authService: SciAuthService,
    public logoutService: SciLogoutService,
    private route: ActivatedRoute,
    private api : AppService,
    private contactMessageService : ContactMessageService,
    private ngZone : NgZone
  ) { }

  ngOnInit() {
    //Set Map center to user location
    if (navigator)
    {
      navigator.geolocation.getCurrentPosition( pos => { this.initMap(+pos.coords.latitude,+pos.coords.longitude)});

      this.subscribeToEvents();  
      // this can check for conenction exist or not.  
      //this.isConnectionEstablished = this.contactMessageService.connectionExists;  
    }
  }
  private initMap(latitude,longitude): void {    
    var tiles = LeafLet.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 25,
      attribution: 'Module : Sitecore Live Tracking by &copy; <a href="http://www.thesitecorist.net">Ramkumar Dhinakaran</a> using &copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    this.map = LeafLet.map('map', {
      center: [ latitude, longitude ],
      zoom: 3
    });
    tiles.addTo(this.map);    
  }    

  
  private subscribeToEvents(): void {  
    // if connection exists it can call of method.  
    this.contactMessageService.connectionEstablished.subscribe((connection : boolean) => {  
        this.isConnectionEstablished = connection;  
    });  
    // finally our service method to call when response received from server event and transfer response to some variable to be shwon on the browser.  
    this.contactMessageService.messageReceived.subscribe((contactMessage: any) => {  
        this.ngZone.run(() => {  
            this.allContacts.push(contactMessage) ;  
        });  
    });  
}  
}
