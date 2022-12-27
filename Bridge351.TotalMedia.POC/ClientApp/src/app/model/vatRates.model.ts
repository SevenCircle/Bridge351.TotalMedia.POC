import { countryModel } from "./country.model";

export class vatRate{
    country:countryModel;
    vatNumberId:number;
    vatNumber:number;
    countryId:number;

    constructor(country:countryModel, vatNumberId:number, vatNumber:number, countryId:number){
        this.countryId= countryId;
        this.country = country;
        this.vatNumberId = vatNumberId;
        this.vatNumber=vatNumber ;
    }
}