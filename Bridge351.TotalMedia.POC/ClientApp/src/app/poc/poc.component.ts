import { Component, Inject, OnInit } from '@angular/core';
import { countryModel } from '../model/country.model';
import { vatRate } from '../model/vatRates.model';
import { PocService } from '../services/poc.service';

@Component({
  selector: 'app-poc',
  templateUrl: './poc.component.html',
  styleUrls: ['./poc.component.css']
})
export class PocComponent implements OnInit {
  countries: countryModel[] | undefined
  selectedCountry:string;
  selectedVatRate:number;
  vatRates:vatRate[] | undefined;
  PriceCat:number;
  Message:string;
  PriceWithTax:number| 0
  ValueAddedTax:number| 0
  PriceWithoutTax:number | 0

  constructor(private services: PocService){
    this.selectedCountry=""
    this.selectedVatRate=0;
    this.PriceCat=1;
    this.Message="";
    this.PriceWithTax=0;
    this.ValueAddedTax=0;
    this.PriceWithoutTax=0;

    this.services.getCountries().pipe().toPromise().then(data=>{
      this.countries=data;
    })

  }
  
  ngOnInit(): void {
    if(this.selectedCountry){
      this.services.getVatRates(this.selectedCountry).pipe().toPromise().then(data=>{
        this.vatRates = data
      })
    }
  }

  onCountrySelection(){
    this.services.getVatRates(this.selectedCountry).pipe().toPromise().then(data=>{
      this.vatRates = data
      if(this.vatRates)
      this.selectedVatRate = this.vatRates[0].vatNumber
    })
  }

  Calc(){
   this.CheckInput(this.PriceWithTax)

    this.PriceWithoutTax = this.PriceWithTax / (1+this.selectedVatRate/100)
    this.ValueAddedTax = this.PriceWithTax-this.PriceWithoutTax;
  }

  onVatRateChange(){
    this.Calc();
  }

  OnPriceWithTaxChange(){
    this.Calc()
  }
  OnPriceWithOutTaxChange(){
    this.CheckInput(this.PriceWithoutTax)

    this.PriceWithTax = this.PriceWithoutTax * (1+this.selectedVatRate/100)
    this.ValueAddedTax = this.PriceWithTax-this.PriceWithoutTax;
  }
  OnValueAddedTaxChange(){
    this.CheckInput(this.ValueAddedTax)
    
    this.PriceWithTax = (this.ValueAddedTax*100)/this.selectedVatRate
    this.PriceWithoutTax = this.PriceWithTax - this.ValueAddedTax;
  }

  CheckInput(value:any){
    if(isNaN(value))
    {
      this.Message = "Error on Input data, verify if there is any letters, comma or another symbol."
    }
    else{
      this.Message = ""
    }
  }
}
