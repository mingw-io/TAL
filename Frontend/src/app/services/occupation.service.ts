import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import OccupationResponse from '../responses/occupation-response';

@Injectable({
  providedIn: 'root'
})
export class OccupationService {

  occupations: OccupationResponse[] = [
{
      id: 1,
      name: 'Author',
      rating: 'White Collar',
      ratingFactor: 1.25
},    
{
    id: 2,
    name: 'Cleaner',
    rating: 'Light Manual',
    ratingFactor: 1.50
},
{
    id: 3,
    name: 'Doctor',
    rating: 'Professional',
    ratingFactor: 1.0 
},

{
  id: 4,
  name: 'Farmer',
  rating: 'Heavy Manual',
  ratingFactor: 1.75
},
{
  id: 5,
  name: 'Florist',
  rating: 'Light Manual',
  ratingFactor: 1.50
},
{
  id: 6,
  name: 'Mechanic',
  rating: 'Heavy Manual',
  ratingFactor: 1.75
}
];

  constructor(private httpClient: HttpClient) { }

  getOccupations(): OccupationResponse[] {
    return this.occupations;
  }

  getRatingFactor(id: number): number {
    if (id < 1) return -1;
    console.log(id);
    var item = this.occupations.filter(x => x.id == id);
    console.log(item);
    if (item === null) return -1;
    if (item.length !== 1) return -1;

    console.log(item[0].ratingFactor.toFixed(2));
    return item[0].ratingFactor;

  }

  
  calculatePremiumValue(deathAmount: number, ratingFactor: number, age: number): Observable<any> {
    let params = new HttpParams();
  
    params = params.append('amount', deathAmount);
    params = params.append('ratingFactor', ratingFactor);
    params = params.append('age', age);

    return this.httpClient.get<any>(`${environment.premiumUrl}/Premium/calculate`, { params: params });
  }

}