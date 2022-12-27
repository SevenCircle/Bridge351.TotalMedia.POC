import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from 'src/enviroment/enviroment';
import { countryModel } from '../model/country.model';

@Injectable({
  providedIn: 'root'
})
export class PocService {

  private path = enviroment.apiUrl;
  constructor(private httpClient: HttpClient) { }

  getCountries(): Observable<any>{
    return this.httpClient.get<any[]>(this.path + "/GetCountries",{headers: new HttpHeaders().append('Content-Type','application/json')});
  }
  
  getVatRates(countryName: string): Observable<any>{
    return this.httpClient.get<any[]>(this.path + "/GetVatRates/"+countryName,{headers: new HttpHeaders().append('Content-Type','application/json')});
  }
}

