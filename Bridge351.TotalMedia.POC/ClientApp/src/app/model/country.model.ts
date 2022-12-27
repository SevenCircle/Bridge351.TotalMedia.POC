export class countryModel{
    countryId: number;
    countryName:string;

    constructor(countryId:number, country:string){
        this.countryId = countryId;
        this.countryName = country;
    }
}
