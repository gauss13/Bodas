import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {
  public title = new BehaviorSubject('titulo');

  constructor() { }

  setTitle(titulo) {

    console.log(this.title);
    this.title.next(titulo);
    console.log(this.title);

  }
}
