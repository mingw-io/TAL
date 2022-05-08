import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PremiumRequest } from '../requests/premium-request';
import TaskResponse from '../responses/task-response';
import OccupationResponse from '../responses/occupation-response';
import { OccupationService } from '../services/occupation.service';
import { TaskService } from '../services/task.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  newTaskString: string = '';
  tasks$: Observable<TaskResponse[]> | undefined;

  occupations: OccupationResponse[] | undefined;

  selectedOccupation = -1;
  isOccupationValid: boolean;
  isPremiumAvail: boolean;

  premiumValue: number;

  premiumRequest: PremiumRequest = {
    name: '',
    dob: '',
    occupation: -1,
    deathAmount: 0.00
  };

  // private occupationService: OccupationService = new Object() as OccupationService;

  constructor(private taskService: TaskService, private occupationService: OccupationService) { 
    this.isOccupationValid = false;
    this.isPremiumAvail = false;

    this.premiumValue = 0.00;
  }

  ngOnInit(): void {
    this.tasks$ = this.taskService.getTasks();

    this.occupations = this.occupationService.getOccupations();

    console.log(this.occupations);
  }

  onSubmit(): void {
    this.isPremiumAvail = false;

    console.log(this.premiumRequest);
    if (this.premiumRequest.name === '') return;
    if (this.premiumRequest.dob === '') return;

    if (this.selectedOccupation < 1) {
      this.isOccupationValid = false;
      return;
    }
    this.isOccupationValid = true;
    if (this.premiumRequest.deathAmount < 1.00) {
      return;
    }
    if (this.premiumRequest.deathAmount > 1000000) {
      return;
    }

    var isValidDate = this.checkIfValidDate(this.premiumRequest.dob);

    if (!isValidDate) {
      this.premiumRequest.dob = '';
      return;
    }

    var age = this.calculateAge(this.premiumRequest.dob);
    if (age < 1) return;

    var ratFactor = this.occupationService.getRatingFactor(this.selectedOccupation);
    if (ratFactor == -1) return;

    // Local calculation
    // this.premiumValue = this.calculatePremium(this.premiumRequest.deathAmount, ratFactor, age);
  
    // WebAPI service calculation
    this.premiumValue = this.calculatePremiumAPI(this.premiumRequest.deathAmount, ratFactor, age);
  
    this.isPremiumAvail = true;
  }

  

  update(e: any){
    if (e === null) return;

    var index = e.target.value as number;

    console.log(index);
    if (index < 1) { 
      this.isOccupationValid = false;
      return;
    }

    this.selectedOccupation = index;
    this.isOccupationValid = true;
  }

  checkIfValidDate(str: any): boolean {
    if (str === '') return false;
    if (str === undefined) return false;
    if (str === null) return false;

    // Regular expression to check if string is valid date
    const regexExp = /(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})/gi;
  
    return regexExp.test(str);
  }

  calculateAge(str: any): number {
    if (str === '') return -1;
    if (str === undefined) return -1;
    if (str === null) return -1;

    if (typeof str !== 'string') return -1;
    if (!str.includes('/')) return -1;

    const parts = str.split('/');
    if (parts.length != 3) return -1;

    if (parts[0].length !== 2) return -1;
    if (parts[1].length !== 2) return -1;
    if (parts[2].length !== 4) return -1;

    const year = Number(parts[2]);
    const month = Number(parts[1]) - 1;
    const day = Number(parts[0]);

    const bdate = new Date(year, month, day);
    if (bdate === undefined) return -1;
    if (bdate === null) return -1;

  const timeDiff = (Date.now() - bdate.getTime());
  
  if (timeDiff < 1) return -1;

  const timeDiffAbs = Math.abs(timeDiff);

  var age = Math.floor((timeDiffAbs / (1000 * 3600 * 24)) / 365);
  
    if ((age < 18) || (age > 75) ) return -1;

    return age;
  }

  // Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12
  calculatePremium(deathAmount: number, ratingFactor: number, age: number): number {

    var premium = (deathAmount * ratingFactor * age) / 1000 * 12;

    return premium;

  }

  /// This method here will contact a WebAPI service
  calculatePremiumAPI(deathAmount: number, ratingFactor: number, age: number): number {
    this.occupationService.calculatePremiumValue(deathAmount, ratingFactor, age).subscribe({
      next: data => {
        if (data) {
          return data.premium;
        }
        return -1;
      },
      error: err => {
        console.log(err);
      }
    });

    return -1;
  }
}