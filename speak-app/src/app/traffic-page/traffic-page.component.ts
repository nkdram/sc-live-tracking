import { Component, OnInit } from '@angular/core';
import { SciLogoutService } from '@speak/ng-sc/logout';
import { ActivatedRoute } from '@angular/router';
import {SciAuthService} from '@speak/ng-sc/auth';
import { AppService } from "../app.service";
//LeafLet map
import * as LeafLet from 'leaflet';

@Component({
  selector: 'app-traffic-page',
  templateUrl: './traffic-page.component.html',
  styleUrls: ['./traffic-page.component.css']
})
export class TrafficPageComponent implements OnInit {
  constructor(public authService: SciAuthService,
    public logoutService: SciLogoutService,
    private route: ActivatedRoute,
    private api : AppService) { }

  ngOnInit() {
    if (navigator)
    {
      navigator.geolocation.getCurrentPosition( pos => { this.initMap(+pos.coords.latitude,+pos.coords.longitude)});
    }
  }

  private map;
  // Country GeoJson
  url: string = "https://js.cit.datalens.api.here.com/datasets/here_country_low.json?";  

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
    this.api
      .getListOfGroup(this.url)
      .subscribe(
        data => {
          //Json returns Coutry data
          LeafLet.geoJson(data).addTo(this.map);
          
          // Api call to Sitecore to get xConnect visit based on countries and return


        },
        err => {
          console.log(err);
        }
      );
    
  }

    ///returns Color code for specific number of visits
    private getColor(d) {
      return d > 1000 ? '#800026' :
            d > 500  ? '#BD0026' :
            d > 200  ? '#E31A1C' :
            d > 100  ? '#FC4E2A' :
            d > 50   ? '#FD8D3C' :
            d > 20   ? '#FEB24C' :
            d > 10   ? '#FED976' :
                        '#FFEDA0';
  }

  ///Based on visit density color code is returned
  private style(feature, density) {
    return {
        fillColor: this.getColor(density),
        weight: 2,
        opacity: 1,
        color: 'white',
        dashArray: '3',
        fillOpacity: 0.7
    };
  }
}
